//
// Script name: AreaTransition.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class AreaTransition : Subject
{
    #region Variables
    public enum eTransitionType
    {
        X,
        Y
    }

    [SerializeField] protected eTransitionType m_TransitionType = eTransitionType.X;

    public eTransitionType TransitionType
    {
        get { return m_TransitionType; }
    }
    #endregion
    
    #region Unity API
    protected virtual void OnTriggerEnter(Collider c)
    {
        NotifyObservers();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}