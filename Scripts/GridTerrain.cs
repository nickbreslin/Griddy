//============================================================================
// Class:   GridTerrain
//----------------------------------------------------------------------------
// File:    GridTerrain.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================

using UnityEngine;
using System.Collections;


public class GridTerrain : MonoBehaviour
{
	public string title;
	public Texture2D icon;
	public Texture terrain;
	public TerrainType type;

	/*public void SetPosition( int x, int y )
	{
		SetPosition( x, y, 0, 0 );
	}
		
	public void SetPosition( int x, int y, float offsetX, float offsetY )
	{
		gameObject.transform.position = new Vector3( x + offsetX, transform.position.y, y + offsetY );
	}
	*/	
}