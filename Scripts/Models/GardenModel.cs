using UnityEngine;
using System.Collections;

public class GardenModel : GridModel {
	
	//enum gardenState;
	bool isActive = true;
	public GameObject plant;
	public GridController controller;
	
	// Use this for initialization
	public void Plant ()
	{
		if(isActive)
		{
			Instantiate(plant, controller.view.origin, Quaternion.identity);
			isActive = false;
		}
	}

	public void StartHover ()
	{
		if(isActive)
		{
			controller.view.state = ViewState.Valid;
		}
		else
		{
			controller.view.state = ViewState.Invalid;
		}
	}
	
	public void StopHover()
	{
		controller.view.state = ViewState.Inactive;
	}
}
