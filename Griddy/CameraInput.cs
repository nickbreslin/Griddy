using UnityEngine;
using System.Collections;

public class CameraInput : MonoSingleton<CameraInput>
{
	public bool isActive = false;
	GridTrigger trigger = null;
	
	void Update()
	{
		if(!isActive)
		{
			return;
		}
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if(GridDirector.instance.isDebugMode)
		{
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		}
		
		RaycastHit hit = new RaycastHit();
		
		if(trigger != null)
		{
			trigger.StopHover();
			trigger = null;
		}
		
    	if (Physics.Raycast (ray, out hit, 1000)) 
		{
			trigger = hit.collider.gameObject.GetComponent<GridTrigger>();
			
			if(!trigger)
			{
				return;
			}
			
			trigger.StartHover();
			
			if(Input.GetMouseButtonDown(0))
			{
				trigger.OnLeftClick();
			}
			if(Input.GetMouseButtonDown(1))
			{
				trigger.OnRightClick();
			}
		}
    }
}
