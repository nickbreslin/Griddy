using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SbModel : GridModel
{
    public SbController controller;
    List<GameObject> withinRange = new List<GameObject> ();
    
    public void Selected ()
    {
        controller.view.SetState (ViewState.Selected);
        
        List<GameObject> withinRange = GridGenerator.instance.FetchArea (coord, 2);
        
        foreach (GameObject go in withinRange) {
            go.GetComponent<SbModel> ().Possible ();
        }
    }
    
    public override void OnLeftClick ()
    {
    }
    
    public void Possible ()
    {
        controller.view.SetState (ViewState.Possible);
        //show alpha   
    }
    
    public override void StartHover ()
    {
        controller.view.SetState (ViewState.Acceptable);
        // show full   
        //Debug.Log(coord.ToString());
        withinRange = GridGenerator.instance.FetchArea (coord, SbGame.range);
        
        foreach (GameObject go in withinRange) {
            go.GetComponent<SbModel> ().Possible ();
        }
    }
    
    public override void StopHover ()
    {
        controller.view.SetState (ViewState.Default);
        // go back to alpha, or Clear.
        foreach (GameObject go in withinRange) {
            go.GetComponent<SbModel> ().Clear ();
        }
    }
    
    public void Clear ()
    {
        controller.view.SetState (ViewState.Default);
    }
}
