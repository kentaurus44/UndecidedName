//
// Script name: DialogManager.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;


public class DialogManager
{
    #region Variables
    public const string ON_DIALOGUE_TRIGGERED = "ON_DIALOGUE_TRIGGERED";

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
    public static string GetDialog(DialogTrigger[] triggers)
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

        return trigger.FirstDialogKey;
    }
    
    public static void Trigger(DialogTrigger trigger)
    {
        //MessageBoxController.Instance.Open(trigger.TriggerKey);
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}