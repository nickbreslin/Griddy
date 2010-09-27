//============================================================================
// Class:   Griddy
//----------------------------------------------------------------------------
// File:    Griddy.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================

using UnityEngine;
using System.Collections;


//============================================================================
// Griddy
//----------------------------------------------------------------------------
// 
//============================================================================
public class Griddy : MonoBehaviour
{


	//------------------------------------------------------------------------
	// Components
	//------------------------------------------------------------------------
	static public CursorManager  Cursor;
	static public GridManager    Grid;
	static public TowerManager   Tower;
	static public TerrainManager Terrain;
	
	static public bool isReady;

	
	//========================================================================
	// Awake
	//------------------------------------------------------------------------
	//
	//========================================================================
	void Awake()
	{
		isReady = false;
		GetComponents();
		isReady = true;
	}	


	//========================================================================
	// Awake
	//------------------------------------------------------------------------
	//
	//========================================================================	
	void GetComponents()
	{
		Cursor  = gameObject.GetComponent<CursorManager>();
		Grid    = gameObject.GetComponent<GridManager>();
		Tower   = gameObject.GetComponent<TowerManager>();
		Terrain = gameObject.GetComponent<TerrainManager>();
	}
}


//============================================================================
// TerrainType
//----------------------------------------------------------------------------
// 
//============================================================================
public enum TerrainType
{
	Unblocked,	
	Blocked
	
}


//============================================================================
// TerrainType
//----------------------------------------------------------------------------
// 
//============================================================================
public class Coord
{
	int _x, _y;
	
	public int x {
		get { return _x; }
		private set { _x = value; }
	}

	public int y {
		get { return _y; }
		private set { _y = value; }
	}


	//------------------------------------------------------------------------
	//
	//------------------------------------------------------------------------	
	public Coord( Vector2 vector )
	: this ( (int)vector.x, (int)vector.y )
	{}

	//------------------------------------------------------------------------
	//
	//------------------------------------------------------------------------
	public Coord( float x, float y )
	: this ( (int)x, (int)y )
	{}

	//------------------------------------------------------------------------
	//
	//------------------------------------------------------------------------	
	public Coord( int x, int y )
	{
		this.x = x;
		this.y = y;
	}
	
	public Vector2 ToVector()
	{
		Vector2 vector = new Vector2( x, y );
		
		return vector;
	}
	
	/**
	 *	Function: ToString
	 *		Overrides the default ToString function.
	 */
	public override string ToString ()
	{
		string str = "(" + x + ", " + y + ")";

		return str;
	}
}