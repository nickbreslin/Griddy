using UnityEngine;
using System.Collections;

/**
 * GridCamera
 *
 * The camera is responsible for generating the raycasts
 * from the mouse position, relative to the camera position.
 *
 * These raycasts are what interact with the triggers which
 * are the foundation of the Griddy logic.
 */
public class GridCamera : MonoSingleton<GridCamera>
{
    /**
     * Controls whether or not raycasts are generated
     */
    bool activeRaycast = false;

    /**
     * Last trigger raycast hit
     */
    GridTrigger trigger = null;

    /**
     * Enable Raycasting
     */
    static public void RaycastOn ()
    {
        
        GridCamera.instance.activeRaycast = true;
    }

    /**
     * Disable Raycasting
     */
    static public void RaycastOff ()
    {
        instance.activeRaycast = false;
    }

    /**
     * Have Camera look at a GameObject
     */
    static public void LookAt (GameObject go)
    {
        instance.transform.LookAt (go.transform);
    }

    /**
     * Have Camera look at a specific location
     */
    static public void LookAt (Vector3 position)
    {
        instance.transform.LookAt (position);
    }

    void Update ()
    {
        // If raycast is not active, don't perform logic.
        if (!activeRaycast) {
            trigger = null;
            return;
        }

        Ray ray = camera.ScreenPointToRay (Input.mousePosition);

        RaycastHit hit = new RaycastHit ();


        // Did Raycast hit Collider?
        if (Physics.Raycast (ray, out hit, 1000)) {
            
            // Find Trigger on Collider (if it's there).
            GridTrigger newTrigger = hit.collider.gameObject.GetComponent<GridTrigger> ();

            // Is the current trigger different from the last trigger?
            if (trigger != newTrigger) {
                
                // Is there a previous trigger?
                if (trigger) {
                    trigger.StopHover ();
                }

                // Current trigger is now our last trigger.
                trigger = newTrigger;
                trigger.StartHover ();
            }

            // Collider did NOT have Trigger attached.
            if (!newTrigger) {
                trigger = null;
                return;
            }

            // Is Left Mouse Clicked?
            if (Input.GetMouseButtonDown (0)) {
                trigger.OnLeftClick ();
            }

            // Is Right Mouse Clicked?
            if (Input.GetMouseButtonDown (1)) {
                trigger.OnRightClick ();
            }
        } else {
            
            // Raycast did not hit anything. If there is
            if (trigger != null) {
                trigger.StopHover ();
                trigger = null;
            }
        }
    }
}