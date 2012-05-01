//============================================================================
// Class:   TerrainManager
//----------------------------------------------------------------------------
// File:    TerrainManager.cs
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
public class TerrainManager : MonoBehaviour
{
	//----------------------------------
	// Public
	//----------------------------------
	public List<GridTerrain> gridTerrains;
	public bool hide;
	
	//----------------------------------
	// Private
	//----------------------------------
	private int? activeButton = null;
	private GUILayoutOption[] button = {GUILayout.Height(50), GUILayout.Width(50) };
	
	//----------------------------------
	// SelectedTower
	//----------------------------------
	public GridTerrain selected
	{
		get
		{
			if( activeButton.HasValue )
			{
				return gridTerrains[(int)activeButton];
			}
			
			return null;
		}
	}

	//----------------------------------
	// Ghost
	//----------------------------------
	//public Terrain ghost;
	

	//----------------------------------
	// ONGUI
	//----------------------------------
	void OnGUI()
	{
		if( hide )
			return;
			
		GUILayout.BeginArea( new Rect( 0, 0, 50, Screen.height ) );
			GUILayout.BeginVertical();
		
				foreach( GridTerrain gridTerrain in gridTerrains )
				{
					if( activeButton != gridTerrains.IndexOf(gridTerrain) &&
						GUILayout.Button(gridTerrain.icon, button ) )
					{
						Griddy.Tower.Clear();
						activeButton = gridTerrains.IndexOf(gridTerrain);
						Griddy.Cursor.state = CursorState.PlaceTerrain;
					}
					else if( activeButton == gridTerrains.IndexOf(gridTerrain) )
					{
						float a = Mathf.PingPong( Time.time, 1 );
						GUI.color = new Color( 1, 1, 1, a );
						GUILayout.Label(gridTerrain.icon, button );
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
	}
		
	public void Clear()
	{
		activeButton = null;
	}	
}