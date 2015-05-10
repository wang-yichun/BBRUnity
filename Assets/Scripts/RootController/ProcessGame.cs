using UnityEngine;
using System.Collections;

public class ProcessGame : MonoBehaviour
{
	public static ProcessGame getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<ProcessGame> ();
	}
	
	public delegate void InitCellOperation();
	public InitCellOperation initCellOperation;

	// Use this for initialization
	void Start ()
	{
		BaseGame.getInstance ().initCommonPara ();

		if (initCellOperation != null) {
			initCellOperation.Invoke ();
		}

		CreateCell.getInstance ().createAllRabbit ();
	}

}
