using UnityEngine;
using System.Collections;

public class GridGenerator : MonoSingleton<GridGenerator>
{
	public GameObject tile;
	
	// Use this for initialization
	public void Generate(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				Instantiate(tile, position, Quaternion.identity);
			}
		}
	}
	
	// Use this for initialization
	public void GenerateHex(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				
				if(y % 2 == 0)
				{
					position += new Vector3(0,0,0.5f);
				}
				
				Instantiate(tile, position, Quaternion.identity);
			}
		}
	}
}
