//
// Script name: EditorCamera
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class EditorCamera : MonoBehaviour 
{
	#region Variables
	#endregion

	#region Unity API
	protected virtual void Awake()
	{
		if (Application.isPlaying)
		{
			Destroy(gameObject);
		}
	}
	#endregion

	#region Public Methods
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

}
