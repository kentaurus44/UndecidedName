//
// Script name: Inventory.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Inventory : Observer
{
    #region Variables
    [SerializeField] protected InventoryDisplay m_Display;
    [SerializeField] protected InventoryItem m_Items;

    private GameProgressTracker m_Progress;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void Init(GameProgressTracker progress)
    {
        m_Progress = progress;
    }

    public void Show()
    {
        // Implement scrolling in
    }

    public void Hide()
    {
        // Implement scrolling out
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);
        if (args[0] is sNotification)
        {
            sNotification sNotify = (sNotification) args[0];

            if (subject is InventoryItem)
            {
                if (sNotify.key.CompareTo(InventoryItem.ON_SELECTED) == 0)
                {
                    InventoryItem item = sNotify.args[0] as InventoryItem;

                    if (item != null)
                    {
                        m_Display.Display(item);
                    }
                }
            }
        }
    }
    #endregion
}