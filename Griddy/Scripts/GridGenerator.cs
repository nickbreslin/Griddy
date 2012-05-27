using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * TODO
 */
public class GridGenerator : MonoSingleton<GridGenerator>
{
    public List<GameObject> tiles = new List<GameObject> ();
 
    
    public GameObject Fetch( int x, int y)
    {
        return this.Fetch(new Coord(x,y));   
    }
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
    
    public List<GameObject> FetchArea(Coord coord, int range)
    {
        List<GameObject> gos = new List<GameObject> ();
        /*
         *  - - - - - - -
         * - - 2 2 2 - - 
         *  - 2 1 1 2 - -
         * - 2 1 0 1 2 -
         *  - 2 1 1 2 - -
         * - - 2 2 2 - -
         *  - - - - - - -
         *
         * determine level.
         * 
         * level = number left, number right.
         * 
         * step left X. select.
         * step right X.
         * 
         */
        
        int a = 0;
        int b = 1;
        int nr = 0;
        int nl = 0;
        
        int r = range / 2;
        
        if (coord.y % 2 == 0)
        {
            if(range % 2 == 1)
            {
                b = 0;
                a = 1;
            }
            else
            {
                b = 0;
            }
        }
        else
        {
            if(range % 2 == 0)
            {
                
                b = 0;
            }
            else
            {
            }
        }

        List<Coord> list = new List<Coord>();
        
        list.Add(new Coord(coord.x + range, coord.y));
        list.Add(new Coord(coord.x - range, coord.y));
        
        if(range > 1)
        {
            for(int m = 1; m < range; m++)
            {
                nr = 0;
                nl = 0;
                if(coord.y % 2 == 1 && m % 2 == 1)
                {
                    nr = 1;
                }
                
                if(coord.y % 2 == 0 && m % 2 == 1)
                {
                    nl = 1;
                }
                list.Add(new Coord(coord.x + range - (m/2) - nr, coord.y + m));
                list.Add(new Coord(coord.x - range + (m/2) + nl, coord.y + m));
                list.Add(new Coord(coord.x + range - (m/2) - nr, coord.y - m));
                list.Add(new Coord(coord.x - range + (m/2) + nl, coord.y - m));
            }
        }
        for(int x = -r - b; x <= r + a; x++)
        {
            list.Add(new Coord(coord.x + x, coord.y + range));
        }
        
        for(int x = -r - b; x <= r + a; x++)
        {
            list.Add(new Coord(coord.x + x, coord.y - range));
        }
        
        foreach(Coord c in list)
        {
            GameObject go = Fetch(c);
                
            if(go != null)
            {
                gos.Add(go);
            }
        }
        
        
        
        
        
        if (range > 1)
        {
            List<GameObject> _gos = FetchArea(coord, range - 1);
            
            foreach (GameObject _go in _gos)
            {
                gos.Add(_go);
            }
        }
        
        return gos;
    }
    
    public List<GameObject> FetchCone(Coord coord, int range)
    {
        
        List<GameObject> gos = new List<GameObject> ();
        
        int a = 0;
        int b = 0;
        
        if (coord.y % 2 == 0)
        {
            if (range % 2 == 1)
            {
                a = 1;
            }
        }
        else
        {
            if (range % 2 == 1)
            {
                b = 1;
            }
        }
        
        if (range % 2 == 0)
        {
               // a = 1;
        }
        
        int r = range/2;
        
        for(int x = -r - b; x <= r + a; x++)
        {
            Coord c = new Coord(coord.x + x, coord.y + range);
            GameObject go = Fetch(c);
                
            if(go != null)
            {
                gos.Add(go);
            }
        }
        
        if (range > 1)
        {
            List<GameObject> _gos = FetchCone(coord, range - 1);
            
            foreach (GameObject go in _gos)
            {
                gos.Add(go);
            }
        }
        
        return gos;
    }
 
    public List<GameObject> FetchLine(Coord coord, int range)
    {
        
        List<GameObject> gos = new List<GameObject> ();
        
        //Coord c = new Coord(coord.x, coord.y + range);
        //Coord c = new Coord(coord.x+(range%2), coord.y + range);
        
        //int r = range/2;
        //Coord c = new Coord(coord.x-r, coord.y + range);
        int a = 0;
        
        if (coord.y % 2 == 0)
        {
            if (range % 2 == 1)
            {
                a = 1;
            }
        }
        
        int r = range/2;
        Coord c = new Coord(coord.x + r + a, coord.y + range);
        
        GameObject go = Fetch(c);
                
        if(go != null)
        {
            gos.Add(go);
        }
        
        if (range > 1)
        {
            List<GameObject> _gos = FetchLine(coord, range - 1);
            
            foreach (GameObject _go in _gos)
            {
                gos.Add(_go);
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
