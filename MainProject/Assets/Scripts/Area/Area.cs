//
// Script name: Area.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class Area : Observer
{
    #region Variables
    [SerializeField] protected CameraPerimeter m_CameraPerimeter;
    [SerializeField] protected TransitionController.sTransitionParameters[] m_TransitionParameters;

    public CameraPerimeter CameraPerimeter
    {
        get { return m_CameraPerimeter; }
    }
    #endregion

    #region Unity API
    protected void Awake()
    {
        for (int i = 0; i < m_TransitionParameters.Length; ++i)
        {
            m_TransitionParameters[i].OriginAreaLocation.RegisterObserver(this);
        }
    }

    protected void OnDestroy()
    {
        for (int i = 0; i < m_TransitionParameters.Length; ++i)
        {
            if (m_TransitionParameters[i].OriginAreaLocation != null)
            {
                m_TransitionParameters[i].OriginAreaLocation.UnregisterObserver(this);
            }
        }
    }
    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);
        if (subject is AreaTransition)
        {
            for (int i = 0; i < m_TransitionParameters.Length; ++i)
            {
                if (m_TransitionParameters[i].OriginAreaLocation == (AreaTransition)subject)
                {
                    TransitionController.Instance.BeginTransition(this, m_TransitionParameters[i]);
                    break;
                }
            }
        }
    }
    #endregion
}