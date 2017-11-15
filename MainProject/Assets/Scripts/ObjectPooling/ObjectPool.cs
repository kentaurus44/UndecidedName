//
// Script name: ObjectPool.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class ObjectPool<T> : MonoBehaviour where T : Component
{
    #region Variables
    [SerializeField] protected T m_InitialItem;

    [SerializeField] protected List<T> m_HiddenPool = new List<T>();
    protected List<T> m_UsedObject = new List<T>();

    public int ObjectCount
    {
        get { return m_UsedObject.Count; }
    }

    public ICollection UsedObject
    {
        get { return m_UsedObject.AsReadOnly(); }
    }
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void LoadItems(int count)
    {
        int currentCount = m_UsedObject.Count;
        T item = null;

        if (currentCount > count)
        {
            for (int i = currentCount - 1; i >= count; --i)
            {
                ReturnItem(m_UsedObject[i]);
            }
        }

        if (currentCount < count)
        {
            for (int i = currentCount; i < count; ++i)
            {
                if (m_HiddenPool.Count > 0)
                {
                    item = LoadFromHidden();
                }
                else
                {
                    item = CreateItem();
                }

                if (item != null)
                {
                    m_UsedObject.Add(item);
                }

                item = null;
            }
        }

    }

    public virtual void ReturnItem(T item)
    {
        m_UsedObject.Remove(item);
        m_HiddenPool.Add(item);
        item.transform.SetParent(transform);
        item.gameObject.SetActive(false);
    }
    #endregion

    #region Protected Methods
    protected virtual T CreateItem()
    {
        T item = Instantiate<T>(m_InitialItem);
        item.transform.SetParent(transform);
        item.gameObject.SetActive(true);
        return item;
    }

    protected virtual T LoadFromHidden()
    {
        T item = m_HiddenPool[0];
        m_HiddenPool.RemoveAt(0);
        item.gameObject.SetActive(true);
        return item;
    }
    #endregion

    #region Private Methods
    #endregion
}