using UnityEngine;
using System.Collections;

public class MoveCell : MonoBehaviour
{
	public static MoveCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<MoveCell> ();
	}

	public void moveACell (GameObject cell_obj, int idx)
	{
		if (BaseGame.getInstance ().HasCell (idx) == true)
			return;

		Vector3 pos = BaseGame.getInstance ().idxToPos (idx);
		cell_obj.transform.position = pos;
		
		Cell cell = cell_obj.GetComponent<Cell> ();

		if (cell.isOnMap) {
			BaseGame.getInstance ().map [cell.Idx] = null;
		}

		cell.Idx = idx;

		BaseGame.getInstance ().map [idx] = cell_obj;
	}

	public void moveACell_anim (GameObject cell_obj, int idx)
	{
		if (BaseGame.getInstance ().HasCell (idx) == true)
			return;
		
		Vector3 pos = BaseGame.getInstance ().idxToPos (idx);

		Hashtable iTweenInfo = new Hashtable ();
		iTweenInfo.Add ("name", "move");
		iTweenInfo.Add ("position", pos);
		iTweenInfo.Add ("Time", 0.20f);
		iTweenInfo.Add ("easetype", iTween.EaseType.easeInOutCirc);
		iTweenInfo.Add ("onstart", "moveACell_anim_onStart");
		iTweenInfo.Add ("onstarttarget", cell_obj);
		iTweenInfo.Add ("oncomplete", "moveACell_anim_onComplete");
		iTweenInfo.Add ("oncompletetarget", cell_obj);
		iTween.MoveTo (cell_obj, iTweenInfo);
		
		Cell cell = cell_obj.GetComponent<Cell> ();
		
		if (cell.isOnMap) {
			BaseGame.getInstance ().map [cell.Idx] = null;
		}
		
		cell.Idx = idx;
		
		BaseGame.getInstance ().map [idx] = cell_obj;
	}

}
