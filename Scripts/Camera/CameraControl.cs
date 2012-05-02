using UnityEngine;
using System.Collections;

public class CameraControl : MonoSingleton<CameraControl>
{
	
	public Transform target;
	
	Vector2 velocity = new Vector2(0,0);
	Vector2 acceleration = new Vector2(50,50);
		
	float maxVel = 100;
	float deAccel = 0.5f;

	void Start()
	{
		SetTarget(target);
	}
	
	void SetTarget(Transform _target)
	{
		transform.LookAt(_target);
	}
	
	void Update () {
		
		// Adjust Velocity by Acceleration by Input
		GetInput ();
		
		// Reduce to within Bounds
		// Reduce Velocity
		velocity.x = LimitVelocity(velocity.x);
		velocity.y = LimitVelocity(velocity.y);
		
		// Rotate
		velocity *= Time.deltaTime;
		transform.RotateAround (target.position, transform.right, velocity.y);
		transform.RotateAround (target.position, Vector3.up,      velocity.x);
		
		// Reduce Velocity
		velocity.x = ReduceVelocity(velocity.x);
		velocity.y = ReduceVelocity(velocity.y);
	}

	
			
	void GetInput()
	{
		if(Input.GetKey(KeyCode.UpArrow))
		{
			velocity.y += acceleration.y;
		}
		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			velocity.y -= acceleration.y;
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			velocity.x -= acceleration.x;
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			velocity.x += acceleration.x;
		}
		
		// Right-Click
		if (Input.GetMouseButton(1))
		{
			velocity.x += Input.GetAxis("Mouse X") * acceleration.x * 5;
			velocity.y += Input.GetAxis("Mouse Y") * -acceleration.y  * 5;
		}
	}
	
	float LimitVelocity(float velocity)
	{
		return Mathf.Clamp(velocity, -maxVel, maxVel);
	}
	
	
	float ReduceVelocity(float velocity)
	{
		float deltaVelocity = deAccel * Time.deltaTime;
		
		if (velocity > 0)
		{
			if (velocity > deltaVelocity)
			{
				velocity -= deltaVelocity;
			}
			else if (velocity <= deltaVelocity)
			{
				velocity = 0;
			}
		} else if (velocity < 0) {
		
			if (velocity < -deltaVelocity)
			{
				velocity += deltaVelocity;
			}
			else if (velocity >= -deltaVelocity)
			{
				velocity = 0;
			}
		}
		
		return velocity;
	}
}