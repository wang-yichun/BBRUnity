using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{

	public CellType type;
	public CellColor color;
	public bool isOnMap = false;
	public int idx;
	public CellStatus status = CellStatus.None;

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

	public string labelValue;

	public string LabelValue {
		set {
			labelValue = value;
			if (value != "") {
				TextMesh tm = this.transform.Find ("label").GetComponent<TextMesh> ();
				tm.text = value;
				MeshRenderer mr = this.transform.Find ("label").GetComponent<MeshRenderer> ();
				mr.enabled = true;
			} else {
				MeshRenderer mr = this.transform.Find ("label").GetComponent<MeshRenderer> ();
				mr.enabled = false;
			}
		}
		get { return labelValue;}
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
		status = CellStatus.Move;
		Statistics.getInstance ().MovingCount++;
	}

	public void moveACell_anim_onComplete ()
	{
		if (ProcessGame.getInstance ().status == GameStatus.Going) {
			status = CellStatus.Normal;
		} else {
			status = CellStatus.None;
		}
		Statistics.getInstance ().MovingCount--;
	}
}
