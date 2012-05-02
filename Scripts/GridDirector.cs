using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector> {
	
	void Start()
	{
		GridViewController.instance.AddView("test", ViewDirector);
		GridViewController.instance.SetView("fake");
		//GridViewController.instance.SetView("test");
	}
	
	void ViewDirector()
	{
		GUILayout.Label("Moo");
	}
}
