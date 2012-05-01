using UnityEngine;
using System.Collections;

public enum ClickMode
{
	Single,
	Automatic
}

public class CameraClick : MonoBehaviour {
	
	/*
	RaycastHit gHit = new RaycastHit();

	public static CameraClick instance;
	void Awake()
	{
		if(CameraClick.instance == null)
		{
			CameraClick.instance = this;
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	void Update() {
		if(!Game.instance.isReady)
			return;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		
		RaycastHit hit = new RaycastHit();
		UI.instance.ClearHover();
    	if (Physics.Raycast (ray, out hit, 1000)) 
		{
			gHit = hit;
			
			GameObject go = gHit.collider.gameObject;
			Cube cube = go.GetComponent<Cube>();
			
			if(cube != null)
			{
				UI.instance.SetHover(cube);
				
				if(Player.instance.mode == ClickMode.Single)
				{
					if(Input.GetMouseButtonDown(0))
					{
						cube.Hit();
					}
				}
				else if(Player.instance.mode == ClickMode.Automatic)
				{
					if(Input.GetMouseButton (0))
					{
						cube.Hit();
					}
				}
			}
		}
				

    }
    */
}
