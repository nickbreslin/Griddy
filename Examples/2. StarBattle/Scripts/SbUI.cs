using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//todo - views should be assigned to a set.
//sets can be toggled off and on.

public class SbUI : UIManager
{    
    void Start ()
    {
        AddView ("default", ViewDefault);
        SetView ("default");
    }

    void OnGUI ()
    {
        InitGUI ();
     
    }
 
    void ViewDefault ()
    {
    }

    protected override void ViewInstructions ()
    {
    }
}