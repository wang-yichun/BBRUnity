using UnityEngine;
using System.Collections;

public class CreateCell : MonoBehaviour
{
	public static CreateCell getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<CreateCell> ();
	}

	public GameObject[] chooseList;

	void Awake ()
	{
		if (ProcessGame.getInstance ().initCellOperation == null) {
			ProcessGame.getInstance ().initCellOperation = new ProcessGame.InitCellOperation (init);
		} else {
			ProcessGame.getInstance ().initCellOperation += init;
		}
	}

	public void init ()
	{
		chooseList = new GameObject[]{
			BaseGame.getInstance ().rabbitPink,
			BaseGame.getInstance ().rabbitYellow,
			BaseGame.getInstance ().rabbitGreen,
			BaseGame.getInstance ().rabbitBlue,
			BaseGame.getInstance ().rabbitWhite,
			BaseGame.getInstance ().rabbitRed
		};
	}

	public void createARabbitToMap (int idx)
	{
		GameObject readyObj = chooseList [Random.Range (0, chooseList.Length)];
		
		GameObject new_rabbit = Instantiate (readyObj) as GameObject;
		new_rabbit.transform.parent = BaseGame.getInstance ().root.transform;
		new_rabbit.GetComponent<Cell> ().LabelValue = "";

		MoveCell.getInstance ().moveACell (new_rabbit, idx);
	}
	
	public void createAllRabbit ()
	{
		for (int i = 0; i < BaseGame.getInstance().map.Length; i++) {
			createARabbitToMap (i);
		}
	}
}
