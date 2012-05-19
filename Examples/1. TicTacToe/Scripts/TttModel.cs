using UnityEngine;
using System.Collections;

public class TttModel : MonoBehaviour {
	
	Player player = Player.None;
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
		TttGame.instance.UpdateBoard(index, player);
		
		((TttView)controller.view).SetPlayer(player);
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
}
