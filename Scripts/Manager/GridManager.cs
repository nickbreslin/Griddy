//============================================================================
// Class:   GridManager
//----------------------------------------------------------------------------
// File:    GridManager.cs
// Author:  Nick Breslin (nickbreslin@gmail.com), nickbreslin.com
// Version: 0.1
//
// License: http://en.wikipedia.org/wiki/WTFPL
//============================================================================
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
	public bool GenerateOnStart;
	public int width;
	public int height;
	
	public GameObject tile;
	public GameObject marker;
	
	List<Tile> tiles = new List<Tile>();
	List<Marker> markers = new List<Marker>();
	
	[HideInInspector] public Marker activeMarker;
	
	void Start()
	{
		if(width  % 2 != 0) Debug.LogError("Width not divisible by 2." );
		if(height % 2 != 0) Debug.LogError("Height not divisible by 2.");
		if(tile   == null ) Debug.LogError("Tile is null."             );
		if(marker == null ) Debug.LogError("Marker is null."           );
		
		if(GenerateOnStart)
		{
			GenerateTiles(width, height);
			GeneratePath();
			GenerateMarkers(width, height);

		}
	}
	
	void GenerateTiles(int width, int heigh)
	{
		// Set Tiles
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				GameObject gameObject = Instantiate(tile) as GameObject;
				
				gameObject.name = "Tile ("+x+","+y+")";
				Tile _tile = gameObject.GetComponent<Tile>();
				
				_tile.SetPosition(x, y);
				_tile.transform.parent = this.transform;
				tiles.Add(_tile);
			}
		}
	}
	
	void GeneratePath()
	{
		int originX = 6;
		int originY = 15;
		int destX = 7;
		int destY = 0;
		Tile origin = GetTile(originX, originY);
		
		SetPath(origin);
		
		while(originY > 4)
		{
			List<Tile> _tiles = new List<Tile>();
			
			Tile _tile;
			
			if(GetTile(originX + 1, originY) != null)
			{
				_tile = GetTile(originX + 1, originY);
				if(_tile.isValid)
					_tiles.Add(_tile);
			}
			if(GetTile(originX - 1, originY) != null)
			{
				_tile = GetTile(originX - 1, originY);
				if(_tile.isValid)
					_tiles.Add(_tile);
			}
			if(GetTile(originX, originY - 1) != null)
			{
				_tile = GetTile(originX, originY - 1);
				if(_tile.isValid)
					_tiles.Add(_tile);
			}
			
			int r = Random.Range(0, _tiles.Count);
			
			SetPath(_tiles[r]);
			originX = _tiles[r].position.x;
			originY = _tiles[r].position.y;
			
		}
		while(true)
		{
			if(originX == destX) 
			{			
				if(originY == destY)
				{
					
					break;
				}
			}
				
			List<Tile> _tiles = new List<Tile>();
			
			Tile _tile;
			
			if(originX < destX)
			{
				if(GetTile(originX + 1, originY) != null)
				{
					_tile = GetTile(originX + 1, originY);
					if(_tile.isValid)
						_tiles.Add(_tile);
				}	
			}
			else if(originX > destX)
			{
				if(GetTile(originX - 1, originY) != null)
				{
					_tile = GetTile(originX - 1, originY);
					if(_tile.isValid)
						_tiles.Add(_tile);
				}
			}
			
			if(originY > destY)
			{
				if(GetTile(originX, originY - 1) != null)
				{
					_tile = GetTile(originX, originY - 1);
					if(_tile.isValid)
					{
						_tiles.Add(_tile);					
					}
				};		
			}	
			
			int r = Random.Range(0, _tiles.Count);
			
			SetPath(_tiles[r]);
			originX = _tiles[r].position.x;
			originY = _tiles[r].position.y;
		}
	}
	
	void SetPath(Tile tile)
	{
		if(tile == null)
			return;
			
		tile.renderer.material.mainTexture = Griddy.Terrain.gridTerrains[2].terrain;
		
		if(Griddy.Terrain.gridTerrains[2].type == TerrainType.Blocked)
		{
			tile.isValid = false;
		}
		else
		{
			tile.isValid = true;
		}
	}
	
	void GenerateMarkers(int width, int height)
	{
		// Set Markers
		for(int x = 0; x < width - 1; x++)
		{
			for(int y = 0; y < height - 1; y++)
			{
				// Valid Tiles
				List<Tile> tiles = GetTiles(x, y);
				
				if(tiles.Count == 4)
				{
					if(IsValid(tiles))
					{
						float offsetX = (float)tile.GetComponent<Tile>().width / 2;
						float offsetY = (float)tile.GetComponent<Tile>().height / 2;
						bool scaleX = false;
						bool scaleY = false;
				
						// Scale Border Markers
						if(x == 0)
						{
							scaleX = true;
							offsetX += -offsetX/2;
						}
						else if(x == width - 2)
						{
							scaleX = true;
							offsetX += offsetX/2;
						}

						if(y == 0)
						{
							scaleY = true;
							offsetY += -offsetY/2;
						}
						else if(y == height - 2)
						{
							scaleY = true;
							offsetY += offsetY/2;
						}
					
						// Generate Marker		
						GameObject gameObject = Instantiate(tile) as GameObject;
						
						gameObject.name = "Marker ("+x+","+y+")";
						Destroy(gameObject.GetComponent<Tile>());							
						Marker _marker = gameObject.AddComponent<Marker>();				
					
						// Initialize
						_marker.SetPosition(x, y, offsetX, offsetY);			
						_marker.SetScale(scaleX, scaleY);
						_marker.transform.parent = this.transform;
						_marker.tiles = tiles;
				
						// Add to List
						markers.Add(_marker);
					}
					else
					{
						// Invalid Marker
					}
				}
				else
				{
					// Insufficient Tiles
				}
			}
		}		
	}
	
	public List<Tile> GetTiles(int x, int y)
	{
		List<Tile> _tiles = new List<Tile>();

		foreach(Tile tile in tiles)
		{
			if((tile.position.x == x + 0   &&
				  tile.position.y == y + 0) ||
				(tile.position.x == x + 1   &&
				  tile.position.y == y + 0) ||
				(tile.position.x == x + 0   &&
				  tile.position.y == y + 1) ||
				(tile.position.x == x + 1   &&
				  tile.position.y == y + 1))
			{
				_tiles.Add(tile);
			}
		}
		return _tiles;
	}

	public Tile GetTile(int x, int y)
	{
		foreach(Tile tile in tiles) {
			if((tile.position.x == x + 0 &&
				  tile.position.y == y + 0)) {
				return tile;
			}
		}

		return null;
	}
		
	public bool IsValid(List<Tile> tiles)
	{
		foreach(Tile tile in tiles) {
			if(!tile.isValid) {
				return false;
			}
		}
		
		return true;
	}
}