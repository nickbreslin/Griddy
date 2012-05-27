using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum SbGameState
{
    None,
    Playing,
    Complete,
    Draw
}

public enum SbPlayer
{
    None,
    Player1,
    Player2
}

public class SbGame : MonoSingleton<SbGame>
{
    public GameState state = GameState.None;
    public Player player = Player.Player1;
    public int turn = 0;
    public static int range = 1;
 
    //TttModel[] board = new Player[9];
    List<TttModel> board = new List<TttModel> ();
    public GameObject tile;
    
    public GameObject ship1;
    public GameObject ship2;
 
    protected override void Init()
    {
        GameInit();
    }
    
    public void GameInit ()
    {
        GridCamera.RaycastOn ();
        GridGenerator.instance.Clear ();
        GridGenerator.instance.GenerateHex (tile, Vector3.zero, 10, 10);
        
        List<GameObject> list = new List<GameObject>();
        
        //list.Add(GridGenerator.instance.Fetch(0,0)); // 0
        //list.Add(GridGenerator.instance.Fetch(1,1)); // 1 > 1
        //list.Add(GridGenerator.instance.Fetch(1,2)); // 2 > 1
        //list.Add(GridGenerator.instance.Fetch(2,3)); // 3 > 2
        //list.Add(GridGenerator.instance.Fetch(2,4)); // 4 > 2
        //list.Add(GridGenerator.instance.Fetch(3,5)); // 5 > 3
        
        foreach(GameObject go in list)
        {
        //    go.GetComponent<SbModel>().Possible();
        }
        
        //GameObject s1 = GridGenerator.instance.Fetch(3,3);
        //s1.GetComponent<SbModel>();
    }
        
    public void Update()
    {
      if(Input.GetKey(KeyCode.Alpha1))
      {
            SbGame.range = 1;
      }
        
      if(Input.GetKey(KeyCode.Alpha2))
      {
            SbGame.range = 2;
      }
        
      if(Input.GetKey(KeyCode.Alpha3))
      {
            SbGame.range = 3;
      }
        if(Input.GetKey(KeyCode.Alpha4))
      {
            SbGame.range = 4;
      }
        if(Input.GetKey(KeyCode.Alpha5))
      {
            SbGame.range = 5;
      }
            
    }
}
