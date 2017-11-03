//
// Script name: Wall.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class Wall : InteractableObject
{
    #region Variables
    [SerializeField] protected DialogManager.DialogTrigger[] m_DialogTrigger;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public override void Interact()
    {
        base.Interact();
        DialogManager.Instance.TriggerDialog(m_DialogTrigger);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}