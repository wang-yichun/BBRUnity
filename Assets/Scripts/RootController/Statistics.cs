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
			GameObject.Find("MovingCount").GetComponent<Text>().text = "正在移动数: " + movingCount;
			if (movingCount == 0) {
				Correlation.getInstance().coutinuousCountWholeMap();
				RemoveCell.getInstance().RemoveCorrelation2Cell();
			}
		}
		get{ return movingCount;}
	}

	private int removeCount = 0; // how many cell is moving
	public int RemoveCount {
		set { 
			removeCount = value;
			GameObject.Find("RemoveCount").GetComponent<Text>().text = "正在消除数: " + removeCount;
			if (removeCount == 0) {
				Correlation.getInstance().coutinuousCountWholeMap();
//				RemoveCell.getInstance().RemoveCorrelation2Cell();
			}
		}
		get{ return removeCount;}
	}
}
