using UnityEngine;
using System.Collections;

public class GardenController : GridController {
	
	public GardenModel model;
	
	public override void Trigger(TriggerEvent triggerEvent)
	{
		switch(triggerEvent)
		{
			case TriggerEvent.StartHover:
				model.StartHover();
				break;
			
			case TriggerEvent.StopHover:
				model.StopHover();
				break;
			
			case TriggerEvent.LeftClick:
				model.Plant();
				break;
			
			default:
				break;
		}
	}
}
