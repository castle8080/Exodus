using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Exodus.Model;

public class MouseController : MonoBehaviour
{
	public float TurnSpeed = 180;

	public World World;

	void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			World.Runner.Turn(TurnSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			World.Runner.Turn(-TurnSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			World.Runner.Turn(0, -TurnSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			World.Runner.Turn(0, TurnSpeed * Time.deltaTime);
		}
	}
}
