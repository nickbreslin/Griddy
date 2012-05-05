using UnityEngine;
using System.Collections;

public enum ViewState
{
	Inactive, // no hover
	Valid, // hover, and valid for interaction
	Invalid // hover, and unable for interaction
}
public class GridView : MonoBehaviour {
	
	public Transform originTransform;
	public Vector3 origin;
	
	public ViewState state;
	Color color;
	public GameObject[] renderers;
	void Awake()
	{
		color = renderers[0].renderer.material.color;
		origin = originTransform.position;
	}
	
	void Update()
	{
		foreach(GameObject go in renderers)
		{
			switch(state)
			{
				case ViewState.Valid:
					go.renderer.material.color = Color.green;
					break;
				
				case ViewState.Invalid:
					go.renderer.material.color = Color.red;
					break;
				
				default:
					go.renderer.material.color = color;
					break;
			
			}
		}
	}
}
