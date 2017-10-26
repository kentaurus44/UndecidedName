//
// Script name: TempControlManager.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class TempControlManager : Observer
{
    #region Variables
    [SerializeField] TempControlVisual[] m_TempControlVisual;
    #endregion

    #region Unity API
    protected void Awake()
    {
        SetAllControlsInactive();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void SetActiveVisual(PlayereStaticInputController.eDirection direction)
    {
        SetAllControlsInactive();

        switch (direction)
        {
            case PlayereStaticInputController.eDirection.NORTH:
                m_TempControlVisual[0].Active();
                break;
            case PlayereStaticInputController.eDirection.NORTH_EAST:
                m_TempControlVisual[1].Active();
                break;
            case PlayereStaticInputController.eDirection.EAST:
                m_TempControlVisual[2].Active();
                break;
            case PlayereStaticInputController.eDirection.SOUTH_EAST:
                m_TempControlVisual[3].Active();
                break;
            case PlayereStaticInputController.eDirection.SOUTH:
                m_TempControlVisual[4].Active();
                break;
            case PlayereStaticInputController.eDirection.SOUTH_WEST:
                m_TempControlVisual[5].Active();
                break;
            case PlayereStaticInputController.eDirection.WEST:
                m_TempControlVisual[6].Active();
                break;
            case PlayereStaticInputController.eDirection.NORTH_WEST:
                m_TempControlVisual[7].Active();
                break;
        }

    }

    private void SetAllControlsInactive()
    {
        for (int i = 0; i < m_TempControlVisual.Length; ++i)
        {
            m_TempControlVisual[i].Inactive();
        }
    }
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);
        if (subject is PlayereStaticInputController)
        {
            if (args[0] is sNotification)
            {
                sNotification sNotify = args[0] as sNotification;
                if (sNotify.key.ToString().CompareTo(PlayereStaticInputController.ON_ANGLE_SET) == 0)
                {
                    SetActiveVisual((PlayereStaticInputController.eDirection) sNotify.args[0]);
                }
            }
        }
    }
    #endregion
}