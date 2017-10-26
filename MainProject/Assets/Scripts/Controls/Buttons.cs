//
// Script name: Buttons.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System;

public class Buttons : MonoBehaviour
{
    #region Variables

	private Action<string> OnFired;
	private string m_ID;
    #endregion
    
    #region Unity API
	protected void OnDestroy()
	{
		OnFired = null;
	}
    #endregion

    #region Public Methods
	public void Init(string id, Action<string> onFired)
	{
		m_ID = id;
		OnFired += onFired;
	}
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
	private void OnTouchEnded()
	{
		OnFired(m_ID);
	}
    #endregion
}