//
// Script name: DialogManager.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;


public class DialogManager : SingletonComponent<DialogManager>
{
    #region Variables
    [System.Serializable]
    public class DialogTrigger : TriggerEvent
    {
        [SerializeField] protected GameProgressManager.eTracked m_TriggerType = GameProgressManager.eTracked.NOTHING;
        [SerializeField] protected string m_FirstDialogKey;
        [SerializeField] protected string m_RepeatDialogKey;

        public GameProgressManager.eTracked TriggerType
        {
            get { return m_TriggerType; }
        }

        public override bool IsTrigger
        {
            get { return m_TriggerType != GameProgressManager.eTracked.NOTHING; }
        }

        public string FirstDialogKey
        {
            get { return m_FirstDialogKey; }
        }

        public string RepeatDialogKey
        {
            get { return m_RepeatDialogKey; }
        }
    }
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void TriggerDialog(DialogTrigger[] triggers)
    {
        DialogTrigger trigger = null;
        DialogTrigger tempTrigger = null;
        for (int i = 0; i < triggers.Length; ++i)
        {
            tempTrigger = triggers[i];

            if (!tempTrigger.IsTrigger)
            {
                trigger = tempTrigger;
                continue;
            }

            if (!GameProgressManager.Instance.Contains(tempTrigger.TriggerType, tempTrigger.TriggerKey) && !tempTrigger.IsComplete)
            {
                break;
            }
            trigger = tempTrigger;
        }

        TriggerDialog(trigger);
    }
    
    public void TriggerDialog(DialogTrigger trigger)
    {
        Debug.Log(trigger.FirstDialogKey);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}