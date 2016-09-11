//
// Script name: TouchManagerTest
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class TouchManagerTest : MonoBehaviour 
{
	#region Variables
	#endregion

	#region Unity API
	protected void Awake()
	{
		CustomCamera.CameraManager.Instance.Init();
		TouchAction.TouchManager.Instance.Init();
	}
	#endregion

	#region Public Methods
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

}
