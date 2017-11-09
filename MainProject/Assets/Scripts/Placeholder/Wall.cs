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
        string key = DialogManager.GetDialog(m_DialogTrigger);
        MessageBoxController.Instance.Open(new MessageBox.MessageBoxParam(MessageBox.eType.MESSAGE, key, null));
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}