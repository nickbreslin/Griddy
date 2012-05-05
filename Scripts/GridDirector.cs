using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector>
{
	public bool isDebugMode;
	
	void Start()
	{
		//GridViewController.instance.AddView("test", ViewDirector);
		//GridViewController.instance.SetView("fake");
		//GridViewController.instance.SetView("test");
	}
	
	void ViewDirector()
	{
		GUILayout.Label("Director");
	}
}
