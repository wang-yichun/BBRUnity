using UnityEngine;
using System.Collections;

public class MoveCell : MonoBehaviour
{
	public static MoveCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<MoveCell> ();
	}

	public void MoveACell(GameObject cell_obj, int idx) {

		Vector3 loc = BaseGame.getInstance ().idxToLoc (idx);
		Vector3 pos = BaseGame.getInstance ().locToPos (loc);
		cell_obj.transform.position = pos;
		
		Cell cell = cell_obj.GetComponent<Cell> ();

		if (cell.isOnMap) {
			BaseGame.getInstance ().map [cell.Idx] = null;
		}

		cell.Idx = idx;

		BaseGame.getInstance ().map [idx] = cell_obj;
	}
}
