//
// Script name: PickUpItem.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class PickUpItem : InteractableObject
{
    #region Variables
    [SerializeField] protected GameProgressManager.eEvent m_Event = GameProgressManager.eEvent.GIVE;
    [SerializeField] protected string m_ItemName;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public override void Interact()
    {
        base.Interact();
        GameProgressManager.Instance.TriggerEvent(m_Event, m_ItemName);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}