using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
	#region Fields
	float speed;
	Vector3 direction;
	bool ready = false;
	CharacterController controller;
	#endregion

	#region Methods
	public void Initilize(float Speed,Vector3 Direction)
	{
		speed = Speed;
		direction = Direction;
		if(direction == Vector3.zero)
		{
			Debug.LogWarning("Direction vector is 0, passing direction (1,1,1) instead");
			direction = Vector3.one;
		}
		if(!TryGetComponent<CharacterController>(out controller))
		{
			controller = gameObject.AddComponent<CharacterController>();
		}
		ready = true;
	}
	private void Update()
	{
		if(ready)
		{
			controller.Move(direction.normalized * speed * Time.deltaTime);
		}
	}
	#endregion
}
