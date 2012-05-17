using UnityEngine;
using System.Collections;

public class TttController : GridController {
	
	public override void Trigger(TriggerEvent triggerEvent)
	{
		switch(triggerEvent)
		{
			case TriggerEvent.StartHover:
				Debug.Log ("Hover Started");
				break;
			
			case TriggerEvent.StopHover:
				Debug.Log ("Hover Stopped");
				break;
			
			case TriggerEvent.LeftClick:
				Debug.Log ("Left Click");
				break;
			
			case TriggerEvent.RightClick:
				Debug.Log ("Right Click");
				break;
				
			default:
				break;
		}
	}
}
