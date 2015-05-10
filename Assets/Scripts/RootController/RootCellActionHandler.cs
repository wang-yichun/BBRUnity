using UnityEngine;
using System.Collections;

public class RootCellActionHandler : MonoBehaviour
{

	public static RootCellActionHandler getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<RootCellActionHandler> ();
	}

	public void onCellMove (GameObject cell_node)
	{
		Debug.Log ("onCellMove @ GameProcess");
	}
}
