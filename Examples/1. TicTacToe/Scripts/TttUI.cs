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
		GUILayout.BeginHorizontal ();
		GUILayout.Label (label);
		GUILayoutOption[] options = new GUILayoutOption[2];
		options[0] = GUILayout.Height(30);
		options[1] = GUILayout.Width(200);
		if(TttGame.instance.state != GameState.Playing)
		{
			GUILayout.Space (20);
			GUI.color = Color.Lerp (Color.cyan, Color.yellow, Time.time % 1f);
			if(GUILayout.Button("Start Game!", options))
			{
				TttGame.instance.GameInit();
			}
			GUI.color = Color.white;
			GUILayout.FlexibleSpace ();
		}
		GUILayout.EndHorizontal();
		GUILayout.FlexibleSpace ();
		GUILayout.EndVertical();
		GUILayout.EndArea ();
	}
	

	
	// game start (restart) view. should be hidden if game is being played.
	
	// view default should show game state (waiting to begin, who's turn it is, who won).
	
	protected override void ViewInstructions()
	{
		GUI.color = Color.green;
		GUILayout.Label ("Objective:");
		GUI.color = Color.white;
		GUILayout.Label ("Be the first player to select three squares in a row or diagonal.");
		GUILayout.Space(10);
		GUI.color = Color.yellow;
		GUILayout.Label ("Method of Play:");
		GUI.color = Color.white;
		GUILayout.Label ("Each player will alternate turns selecting a square. Play continues until a player wins, or no selectable squares remain.");
	}
}