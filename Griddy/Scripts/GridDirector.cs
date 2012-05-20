using UnityEngine;
using System.Collections;

/**
 * TODO
 */
public class GridDirector : MonoSingleton<GridDirector>
{
    /**
     * TODO
     */
    public bool isDebugMode = false;
 
    /**
     * TODO
     */
    protected override void Init ()
    {
        DontDestroyOnLoad (this);
    }
}