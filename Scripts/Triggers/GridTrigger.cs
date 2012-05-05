using UnityEngine;

public enum TriggerEvent
{
	StartHover,
	StopHover,
	RightClick,
	LeftClick
}

/*
 * The Trigger can determine what types of events it responds to,
 * but it does so independently of what the game state is.
 */
public abstract class GridTrigger : MonoBehaviour
{
	public virtual void StartHover() {}
	public virtual void StopHover() {}
	
	public virtual void OnRightClick() {}
	public virtual void OnLeftClick() {}
	
	//do something when moved.
}