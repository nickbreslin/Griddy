using UnityEngine;
using System.Collections;


public enum ViewState
{
	Default,
	Acceptable,
	Unacceptable,
	Invalid
}


public class GridView : MonoBehaviour {
	
	public Transform originTransform;
	public Vector3 origin; // Used for instantiating at a specific grid.
	
	public ViewState state;
	Color color;
	public Renderer[] renderers;
	void Awake()
	{
		color = renderers[0].renderer.material.color;
		origin = originTransform.position;
	}
	
	public void SetState(ViewState viewState)
	{
		if(state == ViewState.Invalid)
		{
			return;
		}
		
		state = viewState;
		
		
		//Set All Renderers.
		foreach(Renderer renderer in renderers)
		{
			switch(state)
			{
				case ViewState.Acceptable:
					renderer.material.color = Color.green;
					break;
				
				case ViewState.Unacceptable:
					renderer.material.color = Color.red;
					break;
				
				case ViewState.Invalid:
				default:
					renderer.material.color = color;
					break;
			
			}
		}
	}
	
	public void ClearState()
	{	
		SetState (ViewState.Default);
	}
}
