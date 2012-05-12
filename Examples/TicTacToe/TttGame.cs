using UnityEngine;
using System.Collections;

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


public class TttGame : MonoBehaviour {
	
	public GameState state = GameState.None;
	public Player player = Player.Player1;
	public int turn = 0;
	
	Player[] board = new Player[10];
	
	public void GameInit()
	{
		turn = 0;
		player = Player.Player1;
		state = GameState.Playing;
		board = new Player[10];
		
		
		// starting values
		// clear board -- add as option for generator.
		// generate board
		// update UI
	}
	
	public void Step()
	{
		if(CheckWin ())
		{
			state = GameState.Complete;
			return;
		}
		
		if(CheckDraw ())
		{
			state = GameState.Draw;
		}
		
		NextTurn ();
	}
	
	private bool CheckWin()
	{
		
		if(board[5] == player)
		{
			if(board[2] == player)
			{
				if(board[8] == player)
				{
					return true;
				}
			}
			
			if(board[4] == player)
			{
				if(board[6] == player)
				{
					return true;
				}
			}
			
			if(board[1] == player)
			{
				if(board[9] == player)
				{
					return true;
				}
			}
			
			if(board[3] == player)
			{
				if(board[7] == player)
				{
					return true;
				}
			}
		}
		
		if(board[1] == player)
		{
			if(board[3] == player)
			{
				if(board[2] == player)
				{
					return true;
				}
			}
			
			if(board[7] == player)
			{
				if(board[4] == player)
				{
					return true;
				}
			}
		}
		
		if(board[9] == player)
		{
			if(board[3] == player)
			{
				if(board[6] == player)
				{
					return true;
				}
			}
			
			if(board[7] == player)
			{
				if(board[8] == player)
				{
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
		if(turn < 9)
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
		if(index > 0 && index < board.Length)
		{
			board[index] = value;
			Step();
		}
	}
}
