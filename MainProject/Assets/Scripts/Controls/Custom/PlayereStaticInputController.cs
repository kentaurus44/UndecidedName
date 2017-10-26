﻿//
// Script name: PlayereStaticInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class PlayereStaticInputController : StaticInputController
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

    private eDirection m_PreviousDirection;
    private eDirection m_CurrentDirection;

    #endregion

    #region Unity API
    #endregion

    #region Public Methods
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
        }
        else if (SOUTH_EAST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH_EAST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH_EAST;
        }
        else if (SOUTH - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH;
        }
        else if (SOUTH_WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < SOUTH_WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.SOUTH_WEST;
        }
        else if (WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.WEST;
        }
        else if (NORTH_WEST - ANGLE_FROM_DIRECTION <= m_Angle && m_Angle < NORTH_WEST + ANGLE_FROM_DIRECTION)
        {
            m_CurrentDirection = eDirection.NORTH_WEST;
        }
        else
        {
            m_CurrentDirection = eDirection.NORTH;
        }

        NotifyObservers(new sNotification(ON_ANGLE_SET, m_CurrentDirection, m_PreviousDirection));
    }
    #endregion

    #region Private Methods
    #endregion
}