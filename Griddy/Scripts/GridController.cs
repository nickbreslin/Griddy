using UnityEngine;
using System.Collections;

/**
 * GridController
 *
 */
public class GridController : MonoBehaviour
{
 
    public GridView view;
    public GridModel model;
 
    public virtual void Trigger (TriggerEvent triggerEvent)
    {
        switch (triggerEvent) {
            
        case TriggerEvent.StartHover:
            model.StartHover ();
            break;
         
        case TriggerEvent.StopHover:
            model.StopHover ();
            break;
         
        case TriggerEvent.OnLeftClick:
            model.OnLeftClick ();
            break;
         
        case TriggerEvent.OnRightClick:
            model.OnRightClick ();
            break;
             
        default:
            break;
        }
    }
}
