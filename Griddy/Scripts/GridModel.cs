using UnityEngine;
using System.Collections;

/**
 * GridController
 *
 */
public class GridModel : MonoBehaviour
{
    public Coord coord;
    
    public virtual void StartHover ()
    {
    }
    
    public virtual void StopHover ()
    {
    }
    
    public virtual void OnRightClick ()
    {
    }
    
    public virtual void OnLeftClick ()
    {
    }
}

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

    public Coord (Vector2 vector)
: this ( (int)vector.x, (int)vector.y )
    {
    }

    public Coord (float x, float y)
: this ( (int)x, (int)y )
    {
    }

    public Coord (int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 ToVector ()
    {
        Vector2 vector = new Vector2 (x, y);
        return vector;
    }
    
    public bool Equals (int x, int y)
    {
        if (x == this.x && y == this.y) {
            return true;
        }
        
        return false;
    }
    
    public bool Equals (float x, float y)
    {
        return this.Equals ((int)x, (int)y);
    }
    
    public bool Equals (Vector2 vector)
    {
        return this.Equals (vector.x, vector.y);
    }
    
    public bool Equals (Coord coord)
    {
        return this.Equals (coord.x, coord.y);
    }
/**
 *  Function: ToString
 *      Overrides the default ToString function.
 */
    public override string ToString ()
    {
        string str = "(" + x + ", " + y + ")";

        return str;
    }
}