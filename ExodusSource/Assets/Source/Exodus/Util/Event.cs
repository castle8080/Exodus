using System;
using System.Collections.Generic;

namespace Exodus.Util
{
    public class Event<T>
    {
        private List<Action<T>> mListeners = new List<Action<T>>();

        public void AddListener(Action<T> listener)
        {
            mListeners.Add(listener);
        }

        public void RemoveListener(Action<T> listener)
        {
            mListeners.Remove(listener);
        }

        public void Fire(T e)
        {
            foreach (var listener in mListeners)
            {
                listener(e);
            }
        }
    }
}
