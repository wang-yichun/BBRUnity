using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RemoveCell : MonoBehaviour
{

	public static RemoveCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<RemoveCell> ();
	}

	/**
	 * Remove idx on map
	 */
	public void RemoveARabbitFromMap (int idx)
	{
		GameObject target_object = BaseGame.getInstance ().map [idx];
		Destroy (target_object);
		BaseGame.getInstance ().map [idx] = null;
	}

	/**
	 * Remove GameObject on map
	 */
	public void RemoveACell_anim (GameObject cell_obj)
	{
		int idx = cell_obj.GetComponent<Cell> ().Idx;
		
		var randomDelay = Random.Range (.05f, .15f);

		Hashtable iTweenInfo = new Hashtable ();
		iTweenInfo.Add ("name", "normalRemove");
		
		iTweenInfo.Add ("from", 1.0f);
		iTweenInfo.Add ("to", 0.0f);
		iTweenInfo.Add ("time", .3f);
		iTweenInfo.Add ("delay", randomDelay);
		iTweenInfo.Add ("easetype", iTween.EaseType.easeOutSine);
		iTweenInfo.Add ("onstart", "normalRemoveACell_anim_onStart");
		iTweenInfo.Add ("onstarttarget", cell_obj);
		iTweenInfo.Add ("onupdate", "normalRemoveACell_anim_onUpdate");
		iTweenInfo.Add ("onupdatetarget", cell_obj);
		iTweenInfo.Add ("oncomplete", "normalRemoveACell_anim_onComplete");
		iTweenInfo.Add ("oncompletetarget", cell_obj);
		iTween.ValueTo (cell_obj, iTweenInfo);

		Hashtable iTweenInfo2 = new Hashtable ();
		iTweenInfo2.Add ("name", "normalRemove");
		iTweenInfo2.Add ("scale", new Vector3 (3, 3, 3));
		iTweenInfo2.Add ("time", .3f);
		iTweenInfo2.Add ("delay", randomDelay + .05f);
		iTweenInfo2.Add ("easetype", iTween.EaseType.easeOutSine);
		iTween.ScaleTo (cell_obj, iTweenInfo2);

		Cell cell = cell_obj.GetComponent<Cell> ();
		
		if (cell.isOnMap) {
			BaseGame.getInstance ().map [cell.Idx] = null;
			cell.isOnMap = false;
		}
	}

	public void RemoveAllRabbit ()
	{
		for (int i = 0; i < BaseGame.getInstance().map.Length; i++) {
			RemoveARabbitFromMap (i);
		}
	}

	public void RemoveCorrelation2Cell ()
	{
		Dictionary<string, int>[] map = Correlation.getInstance ().map;
		for (int i = 0; i < map.Length; i++) {
			Dictionary<string, int> item = map [i];
			if (item != null) {
				if (item ["v"] >= 2 || item ["h"] >= 2) {
					GameObject obj = BaseGame.getInstance ().map [i];
					if (obj != null) {
						this.RemoveACell_anim (obj);
					}
				}
			}
		}
	}
}
