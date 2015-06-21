using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{

	public static Statistics getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<Statistics> ();
	}

	private int movingCount = 0; // how many cell is moving
	public int MovingCount {
		set { 
			movingCount = value;
			GameObject.Find("MovingCount").GetComponent<Text>().text = "Moving Count: " + movingCount;
			if (movingCount == 0) {
				Correlation.getInstance().coutinuousCountWholeMap();
			}
		}
		get{ return movingCount;}
	}
}
