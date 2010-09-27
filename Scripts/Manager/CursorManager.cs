//============================================================================
// Class:   CursorManager
//----------------------------------------------------------------------------
// File:    CursorManager.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;

///<summary>
///
///</summary>
public enum CursorState
{
    None,			// Nothing placable is selected
    PlaceBuilding,	// Building is selected, clicking will place on grid
    PlaceTerrain	// Terrain is selected, clicking will place on grid
}

//============================================================================
// Cursor
//----------------------------------------------------------------------------
// Manage the cursor visual appearance based on events
//============================================================================
public class CursorManager : MonoBehaviour
{
	[HideInInspector]
    public CursorState state;

	private Texture cursor;	     // Displayed cursor texture 
	public  Texture mouseUp;    // Set in Inspector
	public  Texture mouseDown;  // Set in Inspector

	Coord offset     = new Coord(0, 0);
	Coord dimensions = new Coord(32, 32);


	void Awake()
	{
	    // Hide Screen Cursor
		Screen.showCursor = false;
		
		// Set initial Cursor state
		state = CursorState.None;
		
		// Set initial Cursor texture
		cursor = mouseUp;
		Debug.Log(dimensions.ToString());
	}
	
	
    void OnApplicationQuit()
	{
        // 
		cursor = null;
		
        // Reactivates Screen Cursor
        Screen.showCursor = true;
	}

	
    void OnGUI()
	{
		//--------------------------------------------------------------------
		// Set Cursor to MouseDown Texture
		//--------------------------------------------------------------------
		if (Event.current.type == EventType.MouseDown)
		{
			cursor = mouseDown;
		}
		//--------------------------------------------------------------------
		// Set Cursor to MouseUp Texture
		//--------------------------------------------------------------------
		else if(Event.current.type == EventType.MouseUp)
		{
			cursor = mouseUp;
        }

		//--------------------------------------------------------------------
		// Draw Cursor
		//--------------------------------------------------------------------
		GUI.Label(new Rect(Input.mousePosition.x + offset.x,
							 Screen.height - Input.mousePosition.y + offset.y,
							 dimensions.x,
							 dimensions.y),
							 cursor); 	
	}

    /// <summary>
    /// This class...
    /// </summary>
	public void Clear()
	{
        // Resets cursor
		state = CursorState.None;
		
        // Ghost Tower exists, it is destroyed.
		if(Griddy.Tower.ghost != null) {
			Destroy(Griddy.Tower.ghost.gameObject);
		}
	}
}