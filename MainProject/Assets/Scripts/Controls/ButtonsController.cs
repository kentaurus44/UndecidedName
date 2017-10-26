//
// Script name: ButtonsController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class ButtonsController : Subject
{
    #region Variables
	public const string BUTTON_FIRED = "BUTTON_FIRED";

	public Buttons[] m_Buttons;
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
	public void Init()
	{
		for (int i = 0 ; i < m_Buttons.Length ; ++i)
		{
			m_Buttons[i].Init(i.ToString(), ButtonFired);
		}
	}
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
	private void ButtonFired(string id)
	{
		NotifyObservers(new sNotification(BUTTON_FIRED, id));
	}
    #endregion
}