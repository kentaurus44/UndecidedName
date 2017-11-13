//
// Script name: PanelMover.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;


public class PanelMover : MonoBehaviour
{
    #region Variables
    [SerializeField] protected float m_PanelTransitionTime = 0.5f;
    [SerializeField] protected Vector3 m_HiddenOffset;
    private RectTransform m_CurrentTransform;
    private Vector3 m_InitalPosition;
    private Vector3 m_HiddenPosition;
    private Tween m_Tween;
    private System.Action m_OnComplete;

    public float TransitionTime
    {
        get { return m_PanelTransitionTime; }
    }
    #endregion

    #region Unity API
    protected void Awake()
    {
        m_CurrentTransform = GetComponent<RectTransform>();
        m_InitalPosition = m_CurrentTransform.position;
        m_HiddenPosition = m_InitalPosition + m_HiddenOffset;
        m_CurrentTransform.position = m_HiddenPosition;
    }
    #endregion

    #region Public Methods
    public void Show(System.Action onComplete = null)
    {
        m_Tween = m_CurrentTransform.DOMove(m_InitalPosition, m_PanelTransitionTime);

        if (onComplete != null)
        {
            m_OnComplete = onComplete;
            m_Tween.onComplete = OnComplete;
        }
    }

    public void Hide(System.Action onComplete = null)
    {
        m_Tween = m_CurrentTransform.DOMove(m_HiddenPosition, m_PanelTransitionTime);
        if (onComplete != null)
        {
            m_OnComplete = onComplete;
            m_Tween.onComplete = OnComplete;
        }
    }

    public void HideImmediately()
    {
        Stop();
        transform.position = m_HiddenPosition;
    }

    public void Stop()
    {
        m_Tween.Kill();
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void OnComplete()
    {
        if (m_OnComplete != null)
        {
            m_OnComplete();
        }
    }
    #endregion
}