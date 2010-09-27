//============================================================================
// Class:   TowerManager
//----------------------------------------------------------------------------
// File:    TowerManager.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//============================================================================
// TowerManager
//----------------------------------------------------------------------------
// 
//============================================================================
public class TowerManager : MonoBehaviour
{
	//----------------------------------
	// Public
	//----------------------------------
	public List<Tower> towers;
	
	//----------------------------------
	// Private
	//----------------------------------
	private int? activeButton = null;
	private GUILayoutOption[] button = {GUILayout.Height(50), GUILayout.Width(50) };
	
	//----------------------------------
	// SelectedTower
	//----------------------------------
	public Tower selected
	{
		get
		{
			if( activeButton.HasValue )
			{
				return towers[(int)activeButton];
			}
			
			return null;
		}
	}

	//----------------------------------
	// Ghost
	//----------------------------------
	public Tower ghost;
	
	//----------------------------------
	// AWAKE
	//----------------------------------
	void Awake()
	{
	}

	//----------------------------------
	// ONGUI
	//----------------------------------
	void OnGUI()
	{
		GUILayout.BeginArea( new Rect( Screen.width - 50, 0, 50, Screen.height ) );
			GUILayout.BeginVertical();
		
				foreach( Tower tower in towers )
				{
					if( activeButton != towers.IndexOf(tower) &&
						GUILayout.Button(tower.icon, button ) )
					{
						Griddy.Terrain.Clear();
						activeButton = towers.IndexOf(tower);
						Griddy.Cursor.state = CursorState.PlaceBuilding;
						SetGhost( selected );
					}
					else if( activeButton == towers.IndexOf(tower) )
					{
						float a = Mathf.PingPong( Time.time, 1 );
						GUI.color = new Color( 1, 1, 1, a );
						GUILayout.Label(tower.icon, button );
						GUI.color = Color.white;
					}
				}
		
				GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
		GUILayout.EndArea();
	}

	// UPDATE
	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Escape ) )
		{
			Clear();
			Griddy.Cursor.Clear();
		}
		if( ghost != null)
		{
			if( Griddy.Grid.activeMarker != null)
			{
				ghost.SetPosition( Griddy.Grid.activeMarker.position.x, Griddy.Grid.activeMarker.position.y );
			}
			else
			{
				ghost.SetPosition( -100, -100 );
			}
		}
	}
	
	void SetGhost( Tower _ghost )
	{
		if( ghost != null )
			Destroy(ghost.gameObject);
			
		ghost = (Instantiate( _ghost.gameObject ) as GameObject).GetComponent<Tower>();
		
		foreach( Material material in ghost.renderer.materials )
		{
			material.shader = Shader.Find("Transparent/Diffuse");
			material.color = new Color( material.color.r, material.color.g, material.color.b, 0.7f );
		}
	}

	public void Clear()
	{
		activeButton = null;
		Destroy( ghost );
	}
}