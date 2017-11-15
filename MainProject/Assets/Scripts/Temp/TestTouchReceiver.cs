//
// Script name: TestTouchReceiver
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class TestTouchReceiver : TouchAction.BaseTouch
{
	#region Variables
	#endregion

	#region Unity API
	#endregion

	#region Public Methods
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

	#region ITouchableImplementation
	public override bool OnTouchBegin(TouchAction.TouchEvent evt)
	{
		Debug.LogFormat("I, {0}, got touched {1} on layer {2}", name, "OnTouchBegin", gameObject.layer);
		return base.OnTouchBegin(evt);
	}

	public override void OnTouchMoved(TouchAction.TouchEvent evt)
	{
		Debug.LogFormat("I, {0}, got moved {1} on layer {2}", name, "OnTouchMoved", gameObject.layer);		
		base.OnTouchMoved(evt);
	}

	public override void OnTouchEnded(TouchAction.TouchEvent evt)
	{
		Debug.LogFormat("I, {0}, got stopped {1} on layer {2}", name, "OnTouchEnded", gameObject.layer);
		base.OnTouchEnded(evt);
	}
	#endregion
}
