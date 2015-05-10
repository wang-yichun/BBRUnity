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
		
		Vector3 loc = BaseGame.getInstance ().idxToLoc (idx);
		Vector3 pos = BaseGame.getInstance ().locToPos (loc);
		new_rabbit.transform.position = pos;
		
		Cell cell = new_rabbit.GetComponent<Cell> ();
		cell.Idx = idx;
		
		BaseGame.getInstance ().map [idx] = new_rabbit;
	}
	
	public void createAllRabbit ()
	{
		for (int i = 0; i < BaseGame.getInstance().map.Length; i++) {
			createARabbitToMap (i);
		}
	}
}
