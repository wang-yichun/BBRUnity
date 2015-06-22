using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum ShowLabelRules
{
	NONE,
	FULLY,
	ABOVE_2
}

public class Correlation : MonoBehaviour
{
	public static Correlation getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<Correlation> ();
	}
	
	public ShowLabelRules showLabelRules;
	public Dictionary<string, int>[] map;

	public void coutinuousCountWholeMap ()
	{
		int map_length = BaseGame.getInstance ().map.Length;
		map = new Dictionary<string, int>[map_length];
		for (int idx = 0; idx < BaseGame.getInstance().map.Length; idx++) {
			map [idx] = continuousCount (idx);
			
			GameObject obj = BaseGame.getInstance ().map [idx];

			if (obj != null) {
				switch (showLabelRules) {
				case ShowLabelRules.NONE:
					obj.GetComponent<Cell> ().LabelValue = "";
					break;
				case ShowLabelRules.FULLY:
					obj.GetComponent<Cell> ().LabelValue = map [idx] ["h"] + "/" + map [idx] ["v"];
					break;
				case ShowLabelRules.ABOVE_2:
					if (map [idx] ["h"] < 2) {
						map [idx] ["h"] = 0;
					}
					if (map [idx] ["v"] < 2) {
						map [idx] ["v"] = 0;
					}
					if (map [idx] ["h"] >= 2 || map [idx] ["v"] >= 2) {
						obj.GetComponent<Cell> ().LabelValue = map [idx] ["h"] + "/" + map [idx] ["v"];
					} else {
						obj.GetComponent<Cell> ().LabelValue = "";
					}
					break;
				default:
					obj.GetComponent<Cell> ().LabelValue = "";
					break;
				}
			}
		}
	}

	public Dictionary<string, int> continuousCount (int idx)
	{
		GameObject obj0 = BaseGame.getInstance ().map [idx];
		
		Dictionary<string, int> result = null;

		if (obj0 != null) {

			result = new Dictionary<string, int> ();

			var left_count = directionContinuousCount (idx, 0, Direction.Left);
			var right_count = directionContinuousCount (idx, 0, Direction.Right);
			var up_count = directionContinuousCount (idx, 0, Direction.Up);
			var down_count = directionContinuousCount (idx, 0, Direction.Down);

			result.Add ("h", left_count + right_count);
			result.Add ("v", up_count + down_count);
		}

		return result;
	}

	public int directionContinuousCount (int idx, int sum_count, Direction direction)
	{
		GameObject obj0 = BaseGame.getInstance ().map [idx];
		if (obj0 != null) {
			Cell cell0 = obj0.GetComponent<Cell> ();
			GameObject obj1 = null;
			Cell cell1 = null;
			int nextIdx = BaseGame.getInstance ().directionIdx (idx, direction);
			if (nextIdx != int.MinValue) {
				obj1 = BaseGame.getInstance ().map [nextIdx];
				if (obj1 != null) {
					cell1 = obj1.GetComponent<Cell> ();
				}
			}

			if (obj1 == null) {
				return sum_count;
			} else { // has obj1
				if (cell0.color == cell1.color) {
					sum_count = directionContinuousCount (nextIdx, sum_count + 1, direction);
				} else {
					return sum_count;
				}
			}
		}
		return sum_count;
	}
}
