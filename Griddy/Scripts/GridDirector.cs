using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector>
{
	public bool isDebugMode;
	
	void Start()
	{
		GridViewController.instance.AddView("test", ViewDirector);
		//GridViewController.instance.SetView("fake");
		GridViewController.instance.SetView("test");
	}
	
	void ViewDirector()
	{
		GUILayout.Label("Director");
		if(GUILayout.Button ("Generate"))
		{
			GridGenerator.instance.Generate(Vector3.zero, 5, 5);
		}
	}
}