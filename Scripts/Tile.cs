//============================================================================
// Class:   Tile
//----------------------------------------------------------------------------
// File:    Tile.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
	public struct Position
	{
		public int x, y; // Coordinates
		
		public void Set( int _x, int _y )
		{
			x = _x;
			y = _y;
		}
	}
	
	public int width;
	public int height;
	
	public Position position;
	
	public new Renderer renderer;
	public Material material;
	
	
	[HideInInspector] public bool isValid;
	[HideInInspector] public Color color;

	public void Awake()
	{
		isValid = true;
		renderer = gameObject.transform.GetComponentInChildren<MeshRenderer>();
		SetMaterial();
		color = renderer.material.color;
	}
	

	public void SetPosition( int x, int y )
	{
		SetPosition( x, y, 0, 0 );
	}
	

	public void SetPosition( int x, int y, float offsetX, float offsetY )
	{
		position.Set( x, y );
		gameObject.transform.position = new Vector3( x + offsetX, transform.position.y, y + offsetY );
	}
	

	public void SetMaterial()
	{
		renderer.material = material;
	}
}
