using UnityEngine;
using System.Collections;

/**
 * GridController
 * TODO
 */
public class GridController : MonoBehaviour
{
 
    /**
     * TODO
     */
    public GridView view;
    
    /**
     * TODO
     */
    public GridModel model;
 
    /**
     * TODO
     */
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
