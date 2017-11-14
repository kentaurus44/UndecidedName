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