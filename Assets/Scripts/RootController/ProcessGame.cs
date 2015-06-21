using UnityEngine;
using System.Collections;

public class ProcessGame : MonoBehaviour
{
	public static ProcessGame getInstance ()
	{
		return GameObject.Find ("Controller").GetComponent<ProcessGame> ();
	}
	
	public delegate void InitCellOperation ();

	public InitCellOperation initCellOperation;

	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = 60;

		BaseGame.getInstance ().initCommonPara ();

		if (initCellOperation != null) {
			initCellOperation.Invoke ();
		}

		CreateCell.getInstance ().createAllRabbit ();
		setStatus (GameStatus.Going);

		Correlation.getInstance ().coutinuousCountWholeMap ();
		Statistics.getInstance ().MovingCount = 0;
	}

	public GameStatus status = GameStatus.None;

	public void setStatus (GameStatus status)
	{
		this.status = status;
		switch (status) {
		case GameStatus.Stopped:
			setAllCellStatus(CellStatus.None);
			break;
		case GameStatus.Going:
			setAllCellStatus (CellStatus.Normal);
			break;
		default:
			break;
		}
	}

	public void setAllCellStatus (CellStatus status)
	{
		for (int i = 0; i < BaseGame.getInstance().map.Length; i++) {
			if (BaseGame.getInstance ().map [i] != null) {
				Cell cell = BaseGame.getInstance ().map [i].GetComponent<Cell> () as Cell;
				cell.status = status;
			}
		}
	}
}
