using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	[SerializeField]
	private float speed = 1.5f;

	private void Update()
	{
		Vector2 offset = Vector2.zero;
		if (Input.GetKey(KeyCode.A))
		{
			offset.x += -speed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			offset.x += speed;
		}
		transform.position += (Vector3)offset * Time.deltaTime;
	}

}
