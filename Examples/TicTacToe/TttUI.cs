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
		string label = "";
		string player = (TttGame.instance.player == Player.Player1)
						? "1" : "2";
		
		if(TttGame.instance.state == GameState.None)
		{
			label = "Ready to Begin";
		}
		else if (TttGame.instance.state == GameState.Complete)
		{
			label = "Congratulations Player "+player+"!";
		}
		else if (TttGame.instance.state == GameState.Draw)
		{
			label = "This game is a draw!";
		}
		else if(TttGame.instance.state == GameState.Playing)
		{
			label = "It is Player "+player+"'s turn.";
		}
			
		GUILayout.BeginArea (new Rect(10, Screen.height - 40, Screen.width-20, Screen.height-50));
		GUILayout.BeginVertical ();
		GUILayout.Label (label);
		if(TttGame.instance.state != GameState.Playing)
		{
			if(GUILayout.Button("Start Game!"))
			{
				TttGame.instance.GameInit();
			}
		}
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
	

	
	// game start (restart) view. should be hidden if game is being played.
	
	// view default should show game state (waiting to begin, who's turn it is, who won).
	
	protected override void ViewInstructions()
	{
		GUILayout.Label ("Default View");
	}
}