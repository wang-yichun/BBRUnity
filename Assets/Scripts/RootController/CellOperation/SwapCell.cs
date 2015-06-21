using UnityEngine;
using System.Collections;

/**
 * Swap Cell
 */
public class SwapCell : MonoBehaviour
{

	public static SwapCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<SwapCell> ();
	}
	
	public void swapTwoCell (int idx0, int idx1)
	{
		if (BaseGame.getInstance ().HasCell (idx0) && BaseGame.getInstance ().HasCell (idx1)) {
			GameObject obj0 = DetachCell.getInstance ().detachCell (idx0);
			GameObject obj1 = DetachCell.getInstance ().detachCell (idx1);

			MoveCell.getInstance ().moveACell_anim (obj0, idx1);
			MoveCell.getInstance ().moveACell_anim (obj1, idx0);
		}
	}
}
