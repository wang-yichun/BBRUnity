using UnityEngine;
using System.Collections;

public class BaseGame : MonoBehaviour
{

	public static BaseGame getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<BaseGame> ();
	}
	
	public GameObject rabbitPink;
	public GameObject rabbitYellow;
	public GameObject rabbitGreen;
	public GameObject rabbitBlue;
	public GameObject rabbitWhite;
	public GameObject rabbitRed;
	public GameObject[] map;
	public GameObject root; // The obj include the CellNode, which will be Instantiated.
	public GameObject rightTopObj;
	public int hCount;
	public int vCount;
	public Vector3 gridSize;
	
	public void initCommonPara ()
	{
		// gridSize
		gridSize = rightTopObj.transform.position - root.transform.position;
		gridSize = new Vector3 (gridSize.x / (hCount - 1), gridSize.y / (vCount - 1), gridSize.z);

		// map vector
		map = new GameObject[hCount * vCount];
	}
	
	public Vector3 idxToLoc (int idx)
	{
		return new Vector3 ((int)(idx % hCount), (int)(idx / hCount));
	}
	
	public int locToIdx (Vector3 loc)
	{
		return (int)(loc.x + loc.y * hCount);
	}
	
	public Vector3 locToPos (Vector3 loc)
	{
		return new Vector3 (loc.x * gridSize.x, loc.y * gridSize.y) + BaseGame.getInstance ().root.transform.position;
	}

	public Vector3 idxToPos (int idx)
	{
		return locToPos (idxToLoc (idx));
	}

	public bool HasCell (int idx)
	{
		if (map [idx] == null) {
			return false;
		}
		return true;
	}

	public bool locInRange (Vector3 loc)
	{
		if (loc.x >= 0 && loc.x < hCount &&
			loc.y >= 0 && loc.y < vCount)
			return true;
		return false;
	}

	public int upIdx (int idx)
	{
		Vector3 loc = idxToLoc (idx);
		loc = loc + new Vector3 (0, 1);
		if (locInRange (loc))
			return locToIdx (loc);
		return int.MinValue;
	}
	
	public int downIdx (int idx)
	{
		Vector3 loc = idxToLoc (idx);
		loc = loc + new Vector3 (0, -1);
		if (locInRange (loc))
			return locToIdx (loc);
		return int.MinValue;
	}
	
	public int rightIdx (int idx)
	{
		Vector3 loc = idxToLoc (idx);
		loc = loc + new Vector3 (1, 0);
		if (locInRange (loc))
			return locToIdx (loc);
		return int.MinValue;
	}

	public int leftIdx (int idx)
	{
		Vector3 loc = idxToLoc (idx);
		loc = loc + new Vector3 (-1, 0);
		if (locInRange (loc))
			return locToIdx (loc);
		return int.MinValue;
	}
}
