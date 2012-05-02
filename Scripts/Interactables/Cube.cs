using UnityEngine;
using System.Collections;

public class Cube : GridInteractable
{
	public override void StartHover()
	{
		renderer.material.color = Color.red;
	}
	
	public override void StopHover()
	{
		renderer.material.color = Color.white;
	}
}
