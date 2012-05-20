using UnityEngine;
using System.Collections;

public class TttController : GridController
{   
    public override void Trigger (TriggerEvent triggerEvent)
    {
        switch (triggerEvent) {
        case TriggerEvent.StartHover:
            ((TttModel)model).HighlightOn ();
            break;
         
        case TriggerEvent.StopHover:
            ((TttModel)model).HighlightOff ();
            break;
         
        case TriggerEvent.OnLeftClick:
            ((TttModel)model).PlaceMarker ();
            break;
             
        default:
            break;
        }
    }
}
