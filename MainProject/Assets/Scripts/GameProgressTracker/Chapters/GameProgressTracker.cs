//
// Script name: GameProgressTracker.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;

public class GameProgressTracker : ScriptableObject
{
    #region Variables
    [System.Serializable]
    public class Events
    {
        [SerializeField] protected string m_EventName;
        [SerializeField] protected bool m_EventCompleted;

        public string EventName
        {
            get { return m_EventName; }
        }

        public bool EventCompleted
        {
            get { return m_EventCompleted; }
        }
    }

    [System.Serializable]
    public class Items
    {
        [SerializeField] protected string m_ItemName;
        [SerializeField] protected bool m_Obtained;

        public string ItemName
        {
            get { return m_ItemName; }
        }

        public bool Obtained
        {
            get { return m_Obtained; }
        }
    }

    [SerializeField] protected Events[] m_Events;
    [SerializeField] protected Items[] m_Items;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public bool HasItem(string name)
    {
        bool result = false;

        for (int i = 0; i < m_Items.Length; ++i)
        {
            if (m_Items[i].ItemName.CompareTo(name) == 0)
            {
                result = m_Items[i].Obtained;
            }
        }

        return result;
    }

    public bool EventCompleted(string name)
    {
        bool result = false;

        for (int i = 0; i < m_Events.Length; ++i)
        {
            if (m_Events[i].EventName.CompareTo(name) == 0)
            {
                result = m_Events[i].EventCompleted;
            }
        }

        return result;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}