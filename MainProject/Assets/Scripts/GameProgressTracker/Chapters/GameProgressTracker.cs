//
// Script name: GameProgressTracker.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameProgressTracker : ScriptableObject
{
    #region Variables
    [System.Serializable]
    public class Event
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
            set { m_EventCompleted = value; }
        }
    }

    [System.Serializable]
    public class Item
    {
        [SerializeField] protected string m_ItemName;
        [SerializeField] protected bool m_Obtained;
        [SerializeField] protected float m_Quantity;

        public string ItemName
        {
            get { return m_ItemName; }
        }

        public bool Obtained
        {
            get { return m_Obtained; }
            set { m_Obtained = value; }
        }

        public float Quantity
        {
            get { return m_Quantity; }
            set { m_Quantity = value; }
        }
    }

    [SerializeField] protected Event[] m_Events;
    [SerializeField] protected Item[] m_Items;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public List<Item> GetObtainedItems()
    {
        List<Item> items = new List<Item>();

        for (int i = 0; i < m_Items.Length; ++i)
        {
            if (m_Items[i].Obtained)
            {
                items.Add(m_Items[i]);
            }
        }

        return items;
    }

    public void Reset()
    {
        for (int i = 0; i < m_Events.Length; ++i)
        {
            m_Events[i].EventCompleted = false;
        }

        for (int i = 0; i < m_Items.Length; ++i)
        {
            m_Items[i].Obtained = false;
        }

    }

    public bool HasItem(string name)
    {
        Item item = GetItem(name);

        return item != null && item.Obtained;
    }

    public void ReceiveItem(string name)
    {
        SetItem(name, true);
    }

    public void GiveItem(string name)
    {
        SetItem(name, false);
    }

    public bool IsEventCompleted(string name)
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

    public void CompleteEvent(string name)
    {
        Event evt = GetEvent(name);

        evt.EventCompleted = true;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void SetItem(string name, bool val)
    {
        Item item = GetItem(name);

        item.Obtained = val;
    }

    private Item GetItem(string name)
    {
        Item item = null;
        for (int i = 0; i < m_Items.Length; ++i)
        {
            if (m_Items[i].ItemName.CompareTo(name) == 0)
            {
                item = m_Items[i];
            }
        }

        return item;
    }

    private Event GetEvent(string name)
    {
        Event evt = null;

        for (int i = 0; i < m_Events.Length; ++i)
        {
            if (m_Events[i].EventName.CompareTo(name) == 0)
            {
                evt = m_Events[i];
            }
        }

        return evt;
    }
    #endregion
}