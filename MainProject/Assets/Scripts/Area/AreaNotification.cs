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
    private const float PANEL_DISPLAYED = 1f;

    [SerializeField] protected Image m_Background;
    [SerializeField] protected Text m_Text;
    [SerializeField] protected PanelMover m_PanelMover;
    private WaitForSeconds m_Wait;
    private Coroutine m_Coroutine;
    #endregion

    #region Unity API
    protected void Awake()
    {
        m_Wait = new WaitForSeconds(PANEL_DISPLAYED + m_PanelMover.TransitionTime);
        DisablePanel();
    }
    #endregion

    #region Public Methods
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private IEnumerator NotificationSequence()
    {
        EnablePanel(true);
        m_PanelMover.HideImmediately();
        m_PanelMover.Show();

        yield return m_Wait;

        m_PanelMover.Hide(DisablePanel);
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
        m_PanelMover.HideImmediately();
        DisablePanel();
    }

    private void DisablePanel()
    {
        EnablePanel(false);
    }

    private void EnablePanel(bool enable)
    {
        m_PanelMover.gameObject.SetActive(enable);
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