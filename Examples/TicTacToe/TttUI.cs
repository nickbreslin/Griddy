using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//todo - views should be assigned to a set.
//sets can be toggled off and on.

public class TttUI : UIManager
{	
	void Start()
	{
		AddView("default", ViewDefault);
		SetView("default");
	}
	void OnGUI()
	{
		InitGUI();
		
	}
	
	void ViewDefault()
	{
		GUILayout.BeginArea (new Rect(10, Screen.height - 40, Screen.width-20, Screen.height-50));
		GUILayout.BeginVertical ();
		GUILayout.Label ("It is [] Player's Turn.");
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
	
	protected override void ViewInstructions()
	{
		GUILayout.Label ("Default View");
	}
}