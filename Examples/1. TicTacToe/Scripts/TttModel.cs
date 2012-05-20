using UnityEngine;
using System.Collections;

public class TttModel : GridModel {
	
	public Player player = Player.None;
	public int index;
	public GridController controller;
	
	// Use this for initialization
	public void PlaceMarker ()
	{
		if(player != Player.None)
		{
			// Tile is not actionable
			return;
		}
		
		player = TttGame.instance.player;
		((TttView)controller.view).SetPlayer(player);
		TttGame.instance.UpdateBoard(index, player);
		
		
		//Instantiate(plant, controller.view.origin, Quaternion.identity);
	}

	public void HighlightOn ()
	{
		if(player != Player.None)
		{
			// Tile is not actionable
			return;
		}
		
		controller.view.SetState(ViewState.Acceptable);
	}
	
	public void HighlightOff()
	{
		if(player != Player.None)
		{
			// Tile is not actionable
			return;
		}
		
		controller.view.SetState(ViewState.Default);
	}
	
	public void Blink()
	{
		((TttView)controller.view).Blink();
	}
}
