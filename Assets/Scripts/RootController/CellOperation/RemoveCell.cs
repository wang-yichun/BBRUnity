using UnityEngine;
using System.Collections;

public class RemoveCell : MonoBehaviour {

	public static RemoveCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<RemoveCell> ();
	}

	public void RemoveARabbitFromMap(int idx) {
		GameObject target_object = BaseGame.getInstance().map[idx];
		Destroy (target_object);
		BaseGame.getInstance ().map [idx] = null;
	}

	public void RemoveAllRabbit() {
		for (int i = 0; i < BaseGame.getInstance().map.Length; i++) {
			RemoveARabbitFromMap (i);
		}
	}
}
