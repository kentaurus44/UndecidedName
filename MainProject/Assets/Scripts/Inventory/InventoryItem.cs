//
// Script name: InventoryItem.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class InventoryItem : Subject, IPointerDownHandler
{
    #region Variables
    public const string ON_SELECTED = "ON_SELECTED";
    [SerializeField] protected Text m_Text;

    public string Name
    {
        get { return m_Text.text; }
    }
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void LoadItem(GameProgressTracker.Item item)
    {
        m_Text.text = item.ItemName;
    }

    public void OnPointerDown(PointerEventData data)
    {
        NotifyObservers(new sNotification(ON_SELECTED, this));
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}