using UnityEngine;
using System.Collections;

public enum CellType
{
	Rabbit
}

public enum CellColor
{
	Pink,
	Yellow,
	Blue,
	Green,
	White,
	Red
}

public enum Direction
{
	None,
	Right,
	Up,
	Left,
	Down
}

public class CommonDefine : MonoBehaviour
{
	public static Direction VectorToDirection (Vector2 vec)
	{
		bool rd = vec.y - vec.x < 0;
		bool ru = vec.y + vec.x > 0;
		
		if (rd && ru) {
			return Direction.Right;
		} else if (rd && !ru) {
			return Direction.Down;
		} else if (!rd && ru) {
			return Direction.Up;
		} else {
			return Direction.Left;
		}
		
		return Direction.None;
	}
}
