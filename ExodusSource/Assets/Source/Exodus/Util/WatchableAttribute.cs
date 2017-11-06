using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exodus.Util
{
    public class WatchableAttribute<T>
    {
        private T mValue;
        private List<Action<T, T>> mListeners = new List<Action<T, T>>();

        private bool _enabled = true;

        public WatchableAttribute(T value)
        {
            mValue = value;
        }

        public T Value
        {
            get { return mValue; }
            set
            {
                if (_enabled)
                {
                    _enabled = false;
                    try
                    {
                        if (!ValuesEqual(mValue, value))
                        {
                            T oldValue = mValue;
                            mValue = value;
                            foreach (var listener in mListeners)
                            {
                                listener(oldValue, mValue);
                            }
                        }
                    }
                    finally
                    {
                        _enabled = true;
                    }
                }
            }
        }

        public void AddListener(Action<T, T> listener)
        {
            mListeners.Add(listener);
        }

        public void RemoveListener(Action<T, T> listener)
        {
            mListeners.Remove(listener);
        }

        private bool ValuesEqual(T v1, T v2)
        {
            if (v1 == null)
            {
                return v2 == null;
            }
            else
            {
                return v1.Equals(v2);
            }
        }
    }
}
