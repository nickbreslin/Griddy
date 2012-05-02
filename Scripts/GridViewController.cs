using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//todo - views should be assigned to a set.
//sets can be toggled off and on.

public class GridViewController : MonoSingleton<GridViewController>
{	
	public Font font;
	private bool setFont = false;
	
	public delegate void OnGUIImplementation();

    private string currentView = "";
    protected Dictionary<string, OnGUIImplementation> views;
	
	protected override void Init ()
    {
        views = new Dictionary<string, OnGUIImplementation> ();
        AddView("default", ViewDefault);
		SetView ("default");
    }
	
	public void AddView(string key, OnGUIImplementation view)
	{
		views[key] = view;
		Debug.Log (views.Count);
	}
	
	public void SetView(string key)
	{
		if(views.ContainsKey(key))
		{
			currentView = key;
			Debug.Log (currentView);
		}
		else
		{
			Debug.Log ("no key");
		}
	}
	
	void ViewDefault()
	{
		GUILayout.BeginArea (new Rect(10, 10, Screen.width, Screen.height));
		GUILayout.BeginVertical ();
		GUILayout.Label ("Default View");
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
	
	void OnGUI()
	{
		if(!setFont && font != null)
		{
			GUI.skin.font = font;
			setFont = true;
		}
		
		if(views.ContainsKey(currentView))
		{
			views[currentView]();
		}
	}
}