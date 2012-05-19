using UnityEngine;
using System.Collections;


public class TttView : GridView {


	public void SetPlayer(Player player)
	{
		if(state == ViewState.Invalid)
		{
			return;
		}
		
		state = ViewState.Invalid;		
		
		//Set All Renderers.
		foreach(Renderer renderer in renderers)
		{
			switch(player)
			{
				case Player.Player1:
					renderer.material.color = Color.green;
					break;
				
				case Player.Player2:
					renderer.material.color = Color.red;
					break;
				
				default:
					renderer.material.color = color;
					break;
			
			}
		}
	}
	
	public override void SetState(ViewState viewState)
	{
		if(state == ViewState.Invalid)
		{
			return;
		}
		
		state = viewState;
		
		Color playerColor = TttGame.instance.player == Player.Player1
			? new Color(0,1,0,0.5f)
			: new Color(1,0,0,0.5f);
		//Set All Renderers.
		foreach(Renderer renderer in renderers)
		{
			switch(state)
			{
				case ViewState.Acceptable:
					renderer.material.color = playerColor;
					break;
				
				case ViewState.Invalid:
				default:
					renderer.material.color = color;
					break;
			
			}
		}
	}
}
