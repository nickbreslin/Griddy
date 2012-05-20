using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO
 */
public class GridGenerator : MonoSingleton<GridGenerator>
{
    public List<GameObject> tiles = new List<GameObject> ();
 
    public void Clear ()
    {
        foreach (GameObject go in tiles) {
            Destroy (go);
        }
     
        tiles = new List<GameObject> ();
    }
    
    // Use this for initialization
    public void Generate (GameObject obj, Vector3 origin, int width, int height)
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Vector3 position = origin + new Vector3 (x, 0, y);
                tiles.Add (Instantiate (obj, position, Quaternion.identity) as GameObject);
            }
        }
    }
 
    // Use this for initialization
    public void GenerateHex (GameObject obj, Vector3 origin, int width, int height)
    {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                Vector3 position = origin + new Vector3 (x * 1.75f, 0, y * 1.5f);
             
                if (y % 2 == 0) {
                    position += new Vector3 ((1.75f / 2f), 0, 0);
                }
             
                tiles.Add (Instantiate (obj, position, Quaternion.identity) as GameObject);
            }
        }
    }

    /**
     * TODO
     * -- Generate by Pattern
     */
}
