//
// Script name: InventoryPooling.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class InventoryPooling : ObjectPool<InventoryItem>
{
    #region Variables
    private IObserver m_Observer;
    [SerializeField] protected float m_ItemOffset = 10f;
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods
    public void LoadItems(List<GameProgressTracker.Item> items)
    {
        LoadItems(items.Count);

        for (int i = 0; i < items.Count; ++i)
        {
            m_UsedObject[i].LoadItem(items[i]);
            m_UsedObject[i].transform.localPosition = new Vector3(0f, -(m_UsedObject[i].Height + m_ItemOffset) * i, 0f);
            m_UsedObject[i].name = m_UsedObject[i].Name;
        }
    }

    public void RegisterObserver(IObserver obs)
    {
        m_Observer = obs;
    }
    #endregion

    #region Protected Methods
    public override void ReturnItem(InventoryItem item)
    {
        item.UnregisterObserver(m_Observer);
        base.ReturnItem(item);
        item.gameObject.SetActive(false);
    }

    protected override InventoryItem CreateItem()
    {
        InventoryItem item = base.CreateItem();
        item.gameObject.SetActive(true);
        item.RegisterObserver(m_Observer);
        return item;
    }

    protected override InventoryItem LoadFromHidden()
    {
        InventoryItem item = base.LoadFromHidden();
        item.gameObject.SetActive(true);
        item.RegisterObserver(m_Observer);
        return item;
    }
    #endregion

    #region Private Methods
    #endregion
}