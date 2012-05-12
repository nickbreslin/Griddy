using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector>
{
	public bool isDebugMode = false;
	
	protected override void Init ()
	{
		DontDestroyOnLoad(this);
	}
}