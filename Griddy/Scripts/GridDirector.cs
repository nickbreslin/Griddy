using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector>
{
	public bool isDebugMode;
	
	void Start()
	{
	}
	
	void OnGUI()
	{
		if(GUILayout.Button ("Generate Square Grid"))
		{
			GridGenerator.instance.Generate(Vector3.zero, 5, 5);
		}
		if(GUILayout.Button ("Generate Hex Grid"))
		{
			GridGenerator.instance.GenerateHex(Vector3.zero, 5, 5);
		}
	}
}