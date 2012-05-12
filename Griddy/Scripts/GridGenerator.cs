using UnityEngine;
using System.Collections;

public class GridGenerator : MonoSingleton<GridGenerator>
{
	public GameObject square;
	public GameObject hex;
	// Use this for initialization
	public void Generate(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				Instantiate(square, position, Quaternion.identity);
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
				Vector3 position = origin + new Vector3(x * 1.75f,0,y * 1.5f);
				
				if(y % 2 == 0)
				{
					position += new Vector3((1.75f/2f),0,0);
				}
				
				Instantiate(hex, position, Quaternion.identity);
			}
		}
	}
}
