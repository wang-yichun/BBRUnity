using UnityEngine;
using System.Collections;

public class DetachCell : MonoBehaviour
{

	public static DetachCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<DetachCell> ();
	}

	public GameObject detachCell (int idx)
	{ 
		if (BaseGame.getInstance ().HasCell (idx) == false)
			return null;
		GameObject obj = BaseGame.getInstance ().map [idx];
		Cell cell = obj.GetComponent<Cell> ();
		cell.isOnMap = false;
		BaseGame.getInstance ().map [idx] = null;
		return obj;
	}
}
