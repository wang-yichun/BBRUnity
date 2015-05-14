using UnityEngine;
using System.Collections;

public class Correlation : MonoBehaviour {

	public static Correlation getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<Correlation> ();
	}


}
