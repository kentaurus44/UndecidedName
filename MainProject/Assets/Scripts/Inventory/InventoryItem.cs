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

    private RectTransform m_RectTransform;

    public string Name
    {
        get { return m_Text.text; }
    }

    public float Height
    {
        get
        {
            if (m_RectTransform == null)
            {
                m_RectTransform = GetComponent<RectTransform>();
            }
            return m_RectTransform.rect.height;
        }
    }
    #endregion

    #region Unity API
    protected void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
    }
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