//
// Script name: TriggerEvent.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


[System.Serializable]
public class TriggerEvent
{
    #region Variables
    private const string ON_COMPLETE = "_COMPLETED";
    [SerializeField] protected string m_TriggerKey;

    public string TriggerKey
    {
        get { return m_TriggerKey; }
    }

    public bool IsComplete
    {
        get { return SaveManager.GetBool(TriggerKey + ON_COMPLETE); }
    }

    public virtual bool IsTrigger
    {
        get { return true; }
    }
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void SetAsComplete()
    {
        SaveManager.SetBool(m_TriggerKey + ON_COMPLETE, true);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}