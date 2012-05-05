using UnityEngine;
using System.Collections;

public class CameraClick : MonoSingleton<CameraClick>
{
	public bool isActive = false;
	GridInteractable gi = null;
	
	
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
		
		if(gi != null)
		{
			gi.StopHover();
			gi = null;
		}
		
    	if (Physics.Raycast (ray, out hit, 1000)) 
		{
			gi = hit.collider.gameObject.GetComponent<GridInteractable>();
			
			if(!gi)
			{
				return;
			}
			
			//todo - set hover.
			
			gi.StartHover();
			
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
