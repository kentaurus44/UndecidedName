//
// Script name: MessageBox.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MessageBox : Observer
{
    #region Variables
    public enum eType
    {
        MESSAGE,
        YES_NO
    }

    public struct MessageBoxParam
    {
        public eType Type;
        public string Message;
        public System.Action OnClosed;

        public MessageBoxParam(eType type, string message, System.Action onClosed)
        {
            Type = type;
            Message = message;
            OnClosed = onClosed;
        }
    }

    [SerializeField] protected Image m_Background;
    [SerializeField] protected ScreenTouch m_ScreenTouch;
    [SerializeField] protected Text m_Text;

    private MessageBoxParam m_Param;
    #endregion

    #region Unity API
    protected void Start()
    {
        Init();
    }
    #endregion

    #region Public Methods
    public void Open(MessageBoxParam param)
    {
        m_Param = param;

        switch(m_Param.Type)
        {
            case eType.MESSAGE:
                SetMessage();
                break;
            case eType.YES_NO:
                break;
        }
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void SetMessage()
    {
        m_Text.text = m_Param.Message;
        SetMessageVisuals(true);
    }

    private void Init()
    {
        m_ScreenTouch.RegisterObserver(this);
        SetVisuals(false);
    }

    private void SetMessageVisuals(bool enabled)
    {
        m_ScreenTouch.SetEnabled(enabled);
        SetVisuals(enabled);
    }

    private void SetVisuals(bool enabled)
    {
        m_Background.enabled = enabled;
        m_Text.enabled = enabled;
    }
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);
        if (args[0] is sNotification)
        {
            sNotification sNotify = (sNotification) args[0];

            if (subject is ScreenTouch)
            {
                if (sNotify.key.CompareTo(ScreenTouch.ON_SCREEN_TOUCHED) == 0)
                {
                    // Implement

                    switch (m_Param.Type)
                    {
                        case eType.MESSAGE:
                            SetMessageVisuals(false);
                            break;
                        case eType.YES_NO:
                            break;
                    }

                    if (m_Param.OnClosed != null)
                    {
                        m_Param.OnClosed();
                    }
                }
            }
        }
    }
    #endregion
}