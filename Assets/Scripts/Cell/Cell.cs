using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{

	public CellType type;
	public CellColor color;
	public bool isOnMap = false;
	public int idx;

	public int Idx {
		set { 
			idx = value;
			loc = BaseGame.getInstance ().idxToLoc (idx);
		}
		get{ return idx;}
	}

	public Vector3 loc;

	public Vector3 Loc {
		set { 
			loc = value;
			idx = BaseGame.getInstance ().locToIdx (loc);
		}
		get{ return loc;}
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void moveACell_anim_onStart ()
	{
		Debug.Log ("moveACell_anim_onStart - " + idx);
	}

	public void moveACell_anim_onComplete ()
	{
		Debug.Log ("moveACell_anim_onComplete - " + idx);
	}
}
