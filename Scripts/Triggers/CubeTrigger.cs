using UnityEngine;
using System.Collections;

/* Specific logic on how to handle a triggered event.
 * Note, this is not the result, merely more handling of
 * the input.
 * 
 * The Trigger doesn't care what the game state is, it's role
 * is to report the events (that it's listening for) to the
 * controller.
 */ 
public class CubeTrigger : GridTrigger
{
	public GridController controller;
	
	public override void StartHover()
	{
		controller.Trigger(TriggerEvent.StartHover);
	}
	
	public override void StopHover()
	{
		controller.Trigger(TriggerEvent.StopHover);
	}

	public override void OnRightClick()
	{
		controller.Trigger(TriggerEvent.RightClick);
	}
	public override void OnLeftClick()
	{
		controller.Trigger(TriggerEvent.LeftClick);
	}
}
