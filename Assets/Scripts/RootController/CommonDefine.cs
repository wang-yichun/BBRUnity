using UnityEngine;
using System.Collections;

public enum CellType {
	Rabbit
}

public enum CellColor {
	Pink,
	Yellow,
	Blue,
	Green,
	White,
	Red
}

public enum Direction {
	None,
	Right,
	Up,
	Left,
	Down
}

public class CommonDefine : MonoBehaviour {
	public static Direction VectorToDirection (Vector2 vec) {
		return Direction.None;
	}
}
