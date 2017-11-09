//
// Script name: AreaNotification.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;


public class AreaNotification : Observer
{
    #region Variables
    private const float PANEL_TRANSITION = 0.5f;
    private const float PANEL_DISPLAYED = PANEL_TRANSITION + 1f;

    [SerializeField] protected Vector3 m_HiddenOffset;
    [SerializeField] protected Image m_Background;
    [SerializeField] protected Text m_Text;

    private RectTransform m_CurrentTransform;
    private WaitForSeconds m_Wait = new WaitForSeconds(PANEL_DISPLAYED);
    private Coroutine m_Coroutine;
    private Vector3 m_InitalPosition;
    private Vector3 m_HiddenPosition;
    private Tween m_Tween;
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
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private IEnumerator NotificationSequence()
    {
        m_Tween = m_CurrentTransform.DOMove(m_InitalPosition, PANEL_TRANSITION);

        yield return m_Wait;

        m_Tween.Kill(true);
        m_Tween = m_CurrentTransform.DOMove(m_HiddenPosition, PANEL_TRANSITION);
    }

    private void StopCoroutine()
    {
        if (m_Coroutine != null)
        {
            StopCoroutine(m_Coroutine);
            m_Coroutine = null;
        }
    }

    private void Reset()
    {
        StopCoroutine();
        m_Tween.Kill(false);
        m_CurrentTransform.position = m_HiddenPosition;
    }
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);

        if (args[0] is sNotification)
        {
            sNotification sNotify = (sNotification)args[0];

            if (sNotify.key.CompareTo(TransitionController.ON_TRANSITION_COMPLETE) == 0)
            {
                Area area = sNotify.args[0] as Area;

                if (area != null)
                {
                    m_Text.text = area.name;
                    StopCoroutine();
                    m_Coroutine = StartCoroutine("NotificationSequence");
                }
            }
            else if (sNotify.key.CompareTo(TransitionController.ON_TRANSITION_BEGIN) == 0)
            {
                Reset();
            }
        }
    }
    #endregion
}