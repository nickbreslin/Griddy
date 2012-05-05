using UnityEngine;
using System.Collections;

public class CubeTrigger : GridInteractable
{
	public GridTile gridTile;
	/*
	public override void StartHover()
	{
		renderer.material.color = Color.red;
	}
	
	public override void StopHover()
	{
		renderer.material.color = Color.white;
	}
	*/
	
	public override void StartHover()
	{
		gridTile.listener.renderer.material.color = Color.red;
	}
	
	public override void StopHover()
	{
		gridTile.listener.renderer.material.color = Color.white;
	}
}
