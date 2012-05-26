using UnityEngine;
using System.Collections;

public class SbController : GridController
{   
    public override void Trigger (TriggerEvent triggerEvent)
    {
        
        switch (triggerEvent) {
        case TriggerEvent.StartHover:
            ((SbModel)model).StartHover ();
            break;
         
        case TriggerEvent.StopHover:
            ((SbModel)model).StopHover ();
            break;
         
        case TriggerEvent.OnLeftClick:
            ((SbModel)model).OnLeftClick ();
            break;
             
        default:
            break;
        }
    }
}
