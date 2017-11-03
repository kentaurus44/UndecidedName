﻿//
// Script name: PlayereStaticInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class PlayereStaticInputController : DirectionalInputController, IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    #region Variables
    public static readonly string ON_ANGLE_SET = "ON_ANGLE_SET";
    private const float NORTH_EAST = 45f;
    private const float EAST = 90f;
    private const float SOUTH_EAST = 135f;
    private const float SOUTH = 180f;
    private const float SOUTH_WEST = 225f;
    private const float WEST = 270f;
    private const float NORTH_WEST = 315f;
    private const float ANGLE_FROM_DIRECTION = 22.5f;

    public enum eDirection
    {
        NORTH,
        NORTH_EAST,
        EAST,
        SOUTH_EAST,
        SOUTH,
        SOUTH_WEST,
        WEST,
        NORTH_WEST
    }

    private RectTransform m_PanelRect;

    [SerializeField] private ControllerVisuals m_ControllerVisuals;

    private eDirection m_FacingDirection;
    private eDirection m_PreviousDirection;
    private eDirection m_CurrentDirection;
    private bool m_IsMoving = false;
    private bool m_IsFingerDown = false;

    #endregion

    #region Unity API
    protected void Start()
    {
        m_PanelRect = transform.parent as RectTransform;
        RegisterObserver(m_ControllerVisuals);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_PanelRect, transform.position, CustomCamera.CameraManager.Instance.UICamera, out m_CenterPosition);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        UnregisterObserver(m_ControllerVisuals);
    }

    protected void Update()
    {
        if (m_IsFingerDown && m_IsMoving)
        {
            NotifyObservers(new sNotification(ON_ANGLE_SET, m_CurrentDirection, m_PreviousDirection, m_FacingDirection));
        }

    }
    #endregion

    #region Public Methods
    public void OnPointerDown(PointerEventData data)
    {
        m_IsFingerDown = true;
        m_IsMoving = true;
        OnDataSet(data);
    }

    public void OnDrag(PointerEventData data)
    {
        OnDataSet(data);
    }

    public void OnPointerUp(PointerEventData data)
    {
        m_IsFingerDown = false;
        m_IsMoving = false;
        NotifyObservers(new sNotification(ON_TOUCH_ENDED));
    }

    public void OnPointerEnter(PointerEventData data)
    {
        m_IsMoving = true;
        OnDataSet(data);
    }

    public void OnPointerExit(PointerEventData data)
    {
        m_IsMoving = false;
        NotifyObservers(new sNotification(ON_TOUCH_ENDED));
    }
    #endregion

    #region Protected 
    protected override void SetAngle(Vector3 target)
    {
        base.SetAngle(target);

        m_PreviousDirection = m_CurrentDirection;

        if (NORTH_EAST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < NORTH_EAST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.NORTH_EAST;
        }
        else if (EAST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < EAST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.EAST;
            m_FacingDirection = eDirection.EAST;
        }
        else if (SOUTH_EAST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH_EAST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH_EAST;
        }
        else if (SOUTH - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH;
            m_FacingDirection = eDirection.SOUTH;
        }
        else if (SOUTH_WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH_WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH_WEST;
        }
        else if (WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.WEST;
            m_FacingDirection = eDirection.WEST;
        }
        else if (NORTH_WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < NORTH_WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.NORTH_WEST;
        }
        else
        {
            m_CurrentDirection = eDirection.NORTH;
            m_FacingDirection = eDirection.NORTH;
        }
    }
    #endregion

    #region Private Methods
    private void OnDataSet(PointerEventData data)
    {
        m_PanelRect.SetAsFirstSibling();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(m_PanelRect, data.position, CustomCamera.CameraManager.Instance.UICamera, out m_TargetPosition);

        SetAngle(m_TargetPosition);
    }
    #endregion
}