using UnityEngine;
using System.Collections;
using System;
using TouchScript.Gestures;

public class CellGestureDebugHandler : MonoBehaviour
{

	void OnEnable ()
	{
		GetComponent<TapGesture> ().Tapped += tappedHandler;
	}
	
	void OnDisable ()
	{
		GetComponent<TapGesture> ().Tapped -= tappedHandler;
	}

	void tappedHandler (object sender, EventArgs e)
	{
		// remove test
//		Cell cell = this.gameObject.GetComponent<Cell> ();
//		RemoveCell.getInstance ().RemoveARabbitFromMap (cell.Idx);
		// move test
//		int idx_old = this.gameObject.GetComponent<Cell> ().Idx;
//		MoveCell.getInstance ().moveACell (this.gameObject, 0);
		// swap test
//		Cell cell = this.gameObject.GetComponent<Cell> ();
//		int target_idx = BaseGame.getInstance ().upIdx (cell.Idx);
//		SwapCell.getInstance ().swapTwoCell (cell.Idx, target_idx);
	}
}
