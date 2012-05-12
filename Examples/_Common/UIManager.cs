using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//todo - views should be assigned to a set.
//sets can be toggled off and on.

public class UIManager : MonoSingleton<UIManager>
{	
	public Font font;
	protected bool setFont = false;
	
	public delegate void OnGUIImplementation();

    protected string currentView = "";
    protected Dictionary<string, OnGUIImplementation> views = new Dictionary<string, OnGUIImplementation> ();
	
	protected Rect rectInstructions = new Rect(Screen.width-160, 100, 150, Screen.height);
	protected Rect rectCredits      = new Rect(Screen.width-160, 10, 150, Screen.height);
	protected bool showInstructions = true;
	
	public void AddView(string key, OnGUIImplementation view)
	{
		views[key] = view;
	}
	
	public void SetView(string key)
	{
		if(views.ContainsKey(key))
		{
			currentView = key;
		}
		else
		{
			Debug.Log ("no key");
		}
	}
	
	protected void InitGUI()
	{
		//ArgumentException: You can only call GUI functions from inside OnGUI.
		if(!setFont && font != null)
		{
			GUI.skin.font = font;
			setFont = true;
		}
		
		if(views.ContainsKey(currentView))
		{
			views[currentView]();
		}
		
			
		Instructions();
		Credits();
	}
		
	void Instructions()
	{
		GUILayout.BeginArea (rectInstructions);
		GUILayout.BeginVertical ();
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button((showInstructions ? "Hide " : "Show")+" Instructions"))
		{
			showInstructions = !showInstructions;
		}
		
		GUILayout.EndHorizontal ();
		if(showInstructions)
		{
			ViewInstructions();
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
		
	protected virtual void ViewInstructions() {}
	
	void Credits()
	{
		GUILayout.BeginArea (rectCredits);
		GUILayout.BeginVertical ();
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button("by Nick Breslin"))
		{
			Application.OpenURL ("http://etiquettestudio.com/");
		}
		
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button("Get Griddy Library"))
		{
			Application.OpenURL ("https://github.com/nickbreslin/Griddy/");
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();
		GUILayout.FlexibleSpace ();
		if(GUILayout.Button("Follow @etiquettestudio"))
		{
			Application.OpenURL ("https://twitter.com/#!/EtiquetteStudio");
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
}