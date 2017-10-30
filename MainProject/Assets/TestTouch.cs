//
// Script name: TestTouch.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;


public class TestTouch : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    #region Variables
    private RectTransform m_PanelRect;
    private Vector3 m_PointerPosition;
    private Vector3 m_CenterPosition;
    #endregion

    #region Unity API
    protected void Awake()
    {
        m_PanelRect = transform.parent as RectTransform;
    }

    protected void Start()
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_PanelRect, transform.position, CustomCamera.CameraManager.Instance.UICamera, out m_CenterPosition);
    }
    #endregion

    #region Public Methods
    public void OnPointerDown(PointerEventData data)
    {
        OnDataSet(data);
    }

    public void OnDrag(PointerEventData data)
    {
        OnDataSet(data);
    }

    public void OnPointerUp(PointerEventData data)
    {

    }

    public void OnPointerEnter(PointerEventData data)
    {
        OnDataSet(data);
    }

    public void OnPointerExit(PointerEventData data)
    {

    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void OnDataSet(PointerEventData data)
    {
        m_PanelRect.SetAsFirstSibling();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_PanelRect, data.position, CustomCamera.CameraManager.Instance.UICamera, out m_PointerPosition);
    }
    #endregion
}