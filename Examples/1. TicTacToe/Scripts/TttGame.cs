using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState 
{
	None,
	Playing,
	Complete,
	Draw
}

public enum Player
{
	None,
	Player1,
	Player2
}


public class TttGame : MonoSingleton<TttGame>
{
	public GameState state = GameState.None;
	public Player player = Player.Player1;
	public int turn = 0;
	
	//TttModel[] board = new Player[9];
	List<TttModel> board = new List<TttModel>();
	
	public GameObject tile;
	
	public void GameInit()
	{
		GridCamera.RaycastOn();

		turn = 0;
		player = Player.Player1;
		state = GameState.Playing;
		board = new List<TttModel>();
		GridGenerator.instance.Clear();
		GridGenerator.instance.Generate(tile,Vector3.zero, 3,3);
		
		int index = 0;
		foreach(GameObject go in GridGenerator.instance.tiles)
		{
			TttModel tm = go.GetComponent<TttModel>() as TttModel;
			tm.index = index;
			board.Add(tm);
			index++;
		}
				
	}
	
	public void Step()
	{
		if(CheckWin ())
		{
			GridCamera.RaycastOff();
			state = GameState.Complete;
			return;
		}
		
		if(CheckDraw ())
		{
			GridCamera.RaycastOff();
			state = GameState.Draw;
			return;
		}
		
		NextTurn ();
	}
	
	private bool CheckWin()
	{
		
		if(board[4].player == player)
		{
			if(board[1].player == player)
			{
				if(board[7].player == player)
				{
					board[4].Blink();
					board[1].Blink();
					board[7].Blink();
					return true;
				}
			}
			
			if(board[3].player == player)
			{
				if(board[5].player == player)
				{
					board[4].Blink();
					board[3].Blink();
					board[5].Blink();
					return true;
				}
			}
			
			if(board[0].player == player)
			{
				if(board[8].player == player)
				{
					board[4].Blink();
					board[0].Blink();
					board[8].Blink();
					return true;
				}
			}
			
			if(board[2].player == player)
			{
				if(board[6].player == player)
				{
					board[4].Blink();
					board[2].Blink();
					board[6].Blink();
					return true;
				}
			}
		}
		
		if(board[0].player == player)
		{
			if(board[2].player == player)
			{
				if(board[1].player == player)
				{
					board[0].Blink();
					board[2].Blink();
					board[1].Blink();
					return true;
				}
			}
			
			if(board[6].player == player)
			{
				if(board[3].player == player)
				{
					board[0].Blink();
					board[6].Blink();
					board[3].Blink();
					return true;
				}
			}
		}
		
		if(board[8].player == player)
		{
			if(board[2].player == player)
			{
				if(board[5].player == player)
				{
					board[8].Blink();
					board[2].Blink();
					board[5].Blink();
					return true;
				}
			}
			
			if(board[6].player == player)
			{
				if(board[7].player == player)
				{
					board[8].Blink();
					board[6].Blink();
					board[7].Blink();
					return true;
				}
			}
		}
		
		/* 123
		 * 456
		 * 789
		 *
		 *  
		 * 5 > 2 > 8
		 * 5 > 4 > 6
		 * 5 > 1 > 9
		 * 5 > 3 > 7
		 * 
		 * 1 > 3 > 2
		 * 1 > 7 > 4
		 *
		 * 9 > 3 > 6
		 * 9 > 7 > 8
		 */
		
		return false;
	}
	
	private bool CheckDraw()
	{
		if(turn < 8)
		{
			return false;
		}
		
		return true;
	}
	
	private void NextTurn()
	{
		turn += 1;
		player = (player == Player.Player1) ? Player.Player2 : Player.Player1;
	}
	
	public void UpdateBoard(int index, Player value)
	{
		if(index >= 0 && index < board.Count)
		{
			board[index].player = value;
			Step();
		}
	}
}
