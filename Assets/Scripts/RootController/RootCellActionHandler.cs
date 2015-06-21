using UnityEngine;
using System.Collections;

public class RootCellActionHandler : MonoBehaviour
{

	public static RootCellActionHandler getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<RootCellActionHandler> ();
	}

	public void onCellSwap (GameObject cell_node)
	{
		Cell cell = cell_node.GetComponent<Cell> ();
		CellGestureHandler cellGestureHandler = cell_node.GetComponent<CellGestureHandler> ();

		int target_idx = int.MinValue;
		target_idx = BaseGame.getInstance ().directionIdx (cell.Idx, cellGestureHandler.targetDirection);

//		switch (cellGestureHandler.targetDirection) {
//		case Direction.Right:
//			target_idx = BaseGame.getInstance().rightIdx(cell.Idx);
//			break;
//		case Direction.Up:
//			target_idx = BaseGame.getInstance().upIdx(cell.Idx);
//			break;
//		case Direction.Left:
//			target_idx = BaseGame.getInstance().leftIdx(cell.Idx);
//			break;
//		case Direction.Down:
//			target_idx = BaseGame.getInstance().downIdx(cell.Idx);
//			break;
//		default:
//			break;
//		}

		if (target_idx != int.MinValue) {
			if (Statistics.getInstance ().MovingCount == 0) {
				SwapCell.getInstance ().swapTwoCell (cell.Idx, target_idx);
			}
		}
	}
}
