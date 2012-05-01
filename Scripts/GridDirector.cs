using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector> {
	
	protected override void Init()
	{
		GridViewController.instance.AddView("test", ViewDirector);
		GridViewController.instance.SetView("fake");
		GridViewController.instance.SetView("test");
	}
	
	void ViewDirector()
	{
		GUILayout.Label("Moo");
	}
}
