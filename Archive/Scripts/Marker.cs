//============================================================================
// Class:   Marker
//----------------------------------------------------------------------------
// File:    Marker.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Marker : Tile
{   
	new MeshCollider collider;
	public List<Tile> tiles = new List<Tile>();

	
    void Start()
	{	
		collider = gameObject.AddComponent<MeshCollider>();
		collider.sharedMesh = renderer.gameObject.GetComponent<MeshFilter>().mesh;
		
		Destroy(renderer);	
	}
	
	void OnMouseOver()
	{
		Griddy.Grid.activeMarker = this;
		if( Griddy.Cursor.state == CursorState.None) {
		}
		else if (Griddy.Cursor.state == CursorState.PlaceBuilding) {
			foreach(Tile tile in tiles) {
				if(tile.isValid) {
					tile.renderer.material.color = Color.green;
				}
				else {
					tile.renderer.material.color = Color.red;
				}
			}
		}
	}

	
    void OnMouseExit()
	{
		Griddy.Grid.activeMarker = null;
		foreach(Tile tile in tiles) {
			tile.renderer.material.color = tile.color;
		}
	}

	void OnMouseDown()
    {
		bool isValid = true;

		foreach(Tile tile in tiles) {
			if(!tile.isValid) {
				isValid = false;
			}
		}

		if(isValid) {
			if(Griddy.Tower.selected) {

				Instantiate(Griddy.Tower.selected, new Vector3(position.x, 0, position.y), Quaternion.identity);		

				foreach(Tile tile in tiles) {
					tile.isValid = false;
				}
			}
		}
		if(Griddy.Terrain.selected) {
			foreach(Tile tile in tiles) {
				tile.renderer.material.mainTexture = Griddy.Terrain.selected.terrain;
				
				if(Griddy.Terrain.selected.type == TerrainType.Blocked) {
					tile.isValid = false;
				}
				else {
					tile.isValid = true;
				}
			}	
		}
	}

	public void SetScale(bool scaleX, bool scaleZ) {
	
        float x = transform.localScale.x;
		float z = transform.localScale.z;

		if(scaleX) {
			x *= 1.5f;
		}

		if(scaleZ) {
			z *= 1.5f;
		}

		transform.localScale = new Vector3(x, transform.localScale.y, z);
	}
}