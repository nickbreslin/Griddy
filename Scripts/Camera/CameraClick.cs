using UnityEngine;
using System.Collections;

public class CameraClick : MonoSingleton<CameraClick>
{
	public bool isActive = false;
	public bool debugMode = false; // refactor to Debug Class
	
	
	void Start()
	{
		//todo - a manager should trigger this to active.
		// On scene switch, this should be changed to inactive.
		isActive = true;
	}
	
	void Update()
	{
		if(!isActive)
		{
			return;
		}
		
		
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        
		if(debugMode)
		{
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		}
		
		RaycastHit hit = new RaycastHit();
		
		//togo - clear hover
    	if (Physics.Raycast (ray, out hit, 1000)) 
		{
			GridInteractable gi = hit.collider.gameObject.GetComponent<GridInteractable>();
			
			if(!gi)
			{
				return;
			}
			
			//todo - set hover.
			
			//todo - define in settings
			//if(Player.instance.mode == ClickMode.Single)
			//{
				if(Input.GetMouseButtonDown(0))
				{
					//gi.MouseButtonDown(0);
				}
			//}
		}
    }
}
