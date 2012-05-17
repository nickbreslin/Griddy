using UnityEngine;
using System.Collections;

public class TttController : GridController {
	
	public TttModel model;

	public override void Trigger(TriggerEvent triggerEvent)
	{
		switch(triggerEvent)
		{
			case TriggerEvent.StartHover:
				model.HighlightOn();
				break;
			
			case TriggerEvent.StopHover:
				model.HighlightOff();
				break;
			
			case TriggerEvent.LeftClick:
				model.PlaceMarker();
				break;
			
			case TriggerEvent.RightClick:
				break;
				
			default:
				break;
		}
	}
}
