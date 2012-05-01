//============================================================================
// Class:   Waypoint
//----------------------------------------------------------------------------
// File:    Waypoint.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : Tile
{
	new MeshCollider collider;
	List<Tile> tiles = new List<Tile>();
	
	Position tower;
	
	void Start()
	{
		collider = gameObject.AddComponent<MeshCollider>();
		collider.sharedMesh = renderer.gameObject.GetComponent<MeshFilter>().mesh;
		Destroy(renderer.gameObject.GetComponent<MeshCollider>());
		Destroy(renderer);		
	}
	
	void OnMouseOver()
	{
		if(  Griddy.Cursor.state == CursorState.None )
		{

		}
		else if ( Griddy.Cursor.state == CursorState.PlaceBuilding )
		{
			foreach( Tile tile in tiles )
			{
				if( tile.isValid )
				{
					tile.renderer.material.color = Color.green;
				}
				else
				{
					tile.renderer.material.color = Color.red;
				}
			}
		}
	}

	void OnMouseExit()
	{
		foreach( Tile tile in tiles )
		{
			tile.renderer.material.color = Color.white;
		}
	}
	
	void OnMouseDown()
	{
		bool isValid = true;
		
		foreach( Tile tile in tiles )
		{
			if( !tile.isValid )
			{
				isValid = false;
			}
		}
		
		if( isValid )
		{
//			Instantiate( Griddy.Grid.tower, new Vector3( tower.x, 0, tower.y ), Quaternion.identity );
		
		
			foreach( Tile tile in tiles )
			{
				tile.isValid = false;
			}
		}		
	}
	
	public void SetTiles( float x, float y )
	{
		tiles =	Griddy.Grid.GetTiles(System.Convert.ToInt32(x), System.Convert.ToInt32(y));
//		tower.x = x + 0.5f;
//		tower.y = y + 0.5f;
	}
	
	public void SetScale( bool scaleX, bool scaleY )
	{
		float x = transform.localScale.x;
		float y = transform.localScale.z;
		
		if( scaleX )
			x *= 1.5f;
		
		if( scaleY )
			y *= 1.5f;
		
		transform.localScale = new Vector3( x, transform.localScale.y, y );
	}
}
