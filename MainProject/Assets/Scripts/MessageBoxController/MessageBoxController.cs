//
// Script name: MessageBoxController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class MessageBoxController : SingletonComponent<MessageBoxController>
{
    #region Variables
    [SerializeField] protected MessageBox m_MessageBox;
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void Open(MessageBox.MessageBoxParam param)
    {
        m_MessageBox.Open(param);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}