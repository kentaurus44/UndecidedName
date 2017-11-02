//
// Script name: PlayerActionController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class PlayerActionController : Subject
{
    #region Variables
    public const string ON_ACTION_PERFORMED = "ON_ACTION_PERFORMED";
    public enum eAction
    {
        INTERACT,
        ACTION1,
        ACTION2
    }
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void OnActionPerformed(int index)
    {
        eAction action = (eAction)index;
        switch (action)
        {
            case eAction.INTERACT:
                break;
            case eAction.ACTION1:
                break;
            case eAction.ACTION2:
                break;
        }

        NotifyObservers(new sNotification(ON_ACTION_PERFORMED, action));
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}