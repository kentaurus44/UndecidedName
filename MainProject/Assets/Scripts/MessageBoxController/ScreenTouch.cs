//
// Script name: ScreenTouch.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ScreenTouch : Subject, IPointerDownHandler
{
    #region Variables
    public const string ON_SCREEN_TOUCHED = "ON_SCREEN_TOUCHED";

    [SerializeField] protected Image m_Image;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void SetEnabled(bool enable)
    {
        m_Image.enabled = enable;
    }

    public void OnPointerDown(PointerEventData data)
    {
        NotifyObservers(new sNotification(ON_SCREEN_TOUCHED));
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}