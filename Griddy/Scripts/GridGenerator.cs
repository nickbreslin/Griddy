using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO
 */
public class GridGenerator : MonoSingleton<GridGenerator>
{
    public List<GameObject> tiles = new List<GameObject> ();
 
    public GameObject Fetch(Coord coord)
    {
        foreach(GameObject tile in tiles)
        {
            if(tile.GetComponent<GridModel>().coord.Equals(coord))
            {
                return tile;
            }
        }
        
        return null;
    }
    
    public List<GameObject> FetchRadius(Coord coord, int radius)
    {
        List<GameObject> gos = new List<GameObject> ();
        gos.Add(tiles[0]);
        /*
         * - - - - - - -
         *- - 2 2 2 - - 
         * - 2 1 1 2 - -
         *- 2 1 0 1 2 -
         * - 2 1 1 2 - -
         *- - 2 2 2 - -
         * - - - - - - -
         *
         * determine level.
         * 
         * level = number left, number right.
         * 
         * step left X. select.
         * step right X.
         * 
         */
        
        if(radius > 1)
        {
            //gos.FetchRadius(coord, radius - 1);
        }
        else
        {
            return gos;
        }
        
        return gos;
    }
    
    public List<GameObject> FetchCone(Coord coord, int radius)
    {
        List<GameObject> gos = new List<GameObject> ();
        
        int r = radius / 2;
        for(int x = -r; x <= r; x++)
        {
            Coord c = new Coord(coord.x + x, coord.y + radius);
            GameObject go = Fetch(c);
                
            if(go != null)
            {
                gos.Add(go);
            }
        }

        /*
         *- - - - - - -
         * - 3 3 3 3 - -
         *- - 2 2 2 - - 
         * - - 1 1 - - -
         *- - - 0 - - -
         * - - - - - - -
         *
         * determine level.
         * 
         * level = number left, number right.
         * 
         * step left X. select.
         * step right X.
         * 
         */
        
        if (radius > 0)
        {
            List<GameObject> _gos = FetchCone(coord, radius - 1);
            
            foreach (GameObject go in _gos)
            {
                gos.Add(go);
            }
        }
        
        return gos;
    }
    
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
                GameObject go = Instantiate (obj, position, Quaternion.identity) as GameObject;
                GridModel model = go.GetComponent<GridModel>();
                model.coord = new Coord(x,y);
                tiles.Add (go);
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
             GameObject go = Instantiate (obj, position, Quaternion.identity) as GameObject;
                GridModel model = go.GetComponent<GridModel>();
                model.coord = new Coord(x,y);
                tiles.Add (go);
            }
        }
    }

    /**
     * TODO
     * -- Generate by Pattern
     */
}
