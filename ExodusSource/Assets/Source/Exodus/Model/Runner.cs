using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Exodus.Model
{
	public class Runner : MonoBehaviour
	{
		public GameObject Camera;
		public float MovementSpeed = 3f;
	
		public void Turn(float xTheta, float yTheta)
		{
			Debug.Log(string.Format("xTheta={0} yTheta={1}", xTheta, yTheta));
			transform.localRotation =
				Quaternion.AngleAxis(xTheta, transform.right) *
				Quaternion.AngleAxis(yTheta, transform.up) *
				transform.localRotation;
		}

		void Update()
		{
			var delta = MovementSpeed * Time.deltaTime;
			var nPos = transform.localPosition + (transform.forward * delta);

			//Debug.Log(string.Format("td={0} delta={1} nPos={2}", Time.deltaTime, delta, nPos));

			transform.localPosition = nPos;

			Camera.transform.localRotation = transform.localRotation;
			Camera.transform.localPosition = transform.localPosition;
		}
	}
}
