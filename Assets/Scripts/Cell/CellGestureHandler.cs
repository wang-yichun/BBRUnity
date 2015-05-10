using UnityEngine;
using System.Collections;
using System;
using TouchScript.Gestures;

public class CellGestureHandler : MonoBehaviour
{

	void OnEnable ()
	{
		GetComponent<PressGesture> ().Pressed += pressedHandler;
		GetComponent<ReleaseGesture> ().Released += releasedHandler;
		GetComponent<PanGesture> ().PanStarted += panStartedHandler;
		GetComponent<PanGesture> ().Panned += pannedHandler;
		GetComponent<PanGesture> ().PanCompleted += panCompletedHandler;

		onCellSwap = new OnCellAction (RootCellActionHandler.getInstance ().onCellSwap);
	}

	void OnDisable ()
	{
		GetComponent<PressGesture> ().Pressed -= pressedHandler;
		GetComponent<ReleaseGesture> ().Released -= releasedHandler;
		GetComponent<PanGesture> ().PanStarted -= panStartedHandler;
		GetComponent<PanGesture> ().Panned -= pannedHandler;
		GetComponent<PanGesture> ().PanCompleted -= panCompletedHandler;

		onCellSwap = null;
	}

	void pressedHandler (object sender, EventArgs e)
	{
	}

	void releasedHandler (object sender, EventArgs e)
	{
	}

	Vector2 panStartedScreenPosition;
	bool panStarted;

	void panStartedHandler (object sender, EventArgs e)
	{
		panStartedScreenPosition = (sender as PanGesture).ScreenPosition;
		panStarted = true;
	}

	Vector2 panedScreenPosition;
	public Direction targetDirection;

	void pannedHandler (object sender, EventArgs e)
	{
		if (panStarted) {
			panedScreenPosition = (sender as PanGesture).ScreenPosition;
			Vector2 vec_panned_started = panedScreenPosition - panStartedScreenPosition;

			if (vec_panned_started.magnitude >= 2.0f) {

				targetDirection = CommonDefine.VectorToDirection (vec_panned_started);
				onCellSwap.Invoke (this.gameObject);
				targetDirection = Direction.None;

				panStarted = false;
			}
		}
	}

	void panCompletedHandler (object sender, EventArgs e)
	{
		panStarted = false;
	}
	
	public delegate void OnCellAction (GameObject cell_node);

	public OnCellAction onCellSwap;
}
