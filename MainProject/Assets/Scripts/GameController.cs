//
// Script name: GameController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;


public class GameController : Observer
{
    #region Variables
    [Header("Controllers")]
	[SerializeField] protected DirectionalInputController m_InputController;
	[SerializeField] protected PlayerController m_PlayerController;
    [SerializeField] protected CameraController m_CameraController;
    [SerializeField] protected PlayerActionController m_ActionController;
    [SerializeField] protected AreaNotification m_AreaNotification;
    [SerializeField] protected BackpackController m_BackpackController;

    [Header("Story")]
    [SerializeField] protected Chapter m_Chapter;

    private Area m_CurrentArea = null;

    #endregion

    #region Unity API
    protected void Awake()
	{
        CustomCamera.CameraManager.Instance.Init();
    }

    protected void Start()
    {
#if UNITY_EDITOR
        LoadChapter(m_Chapter);
#endif
    }

    protected void OnDestroy()
	{
        UnregisterComponent();
    }
    #endregion

    #region Public Methods
    public void LoadChapter(Chapter chapter)
    {
        UnregisterComponent();

        m_CurrentArea = chapter.GetInitalArea();

        InitInput();
        InitAction();
        InitPlayer();
        InitCamera();
        InitTransition();
        InitProgress();
        InitBackpack();
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void UnregisterComponent()
    {
        if (m_InputController != null)
        {
            m_InputController.UnregisterObserver(m_PlayerController);
        }

        if (m_ActionController != null)
        {
            m_ActionController.UnregisterObserver(m_PlayerController);
        }
        
        if (!TransitionController.IsInstanceNull())
        {
            TransitionController.Instance.UnregisterObserver(this);
            TransitionController.Instance.UnregisterObserver(m_AreaNotification);
        }
    }

    private void InitCamera()
    {
        m_CameraController.Init();
        m_CameraController.LoadPerimeter(m_CurrentArea.CameraPerimeter);
    }

    private void InitInput()
    {
        m_InputController.Init();
        m_InputController.RegisterObserver(m_PlayerController);
    }

    private void InitAction()
    {
        m_ActionController.RegisterObserver(m_PlayerController);
    }

    private void InitPlayer()
    {
        m_PlayerController.transform.position = m_CurrentArea.CharacterInitalPosition.position;
    }
    
    private void InitTransition()
    {
        TransitionController.Instance.Init(m_CameraController, m_PlayerController);
        TransitionController.Instance.RegisterObserver(this);
        TransitionController.Instance.RegisterObserver(m_AreaNotification);
    }

    private void InitProgress()
    {
        GameProgressManager.Instance.LoadGameProgress(m_Chapter.ProgressTracker);
    }

    private void InitBackpack()
    {
        m_BackpackController.Init(m_Chapter.ProgressTracker);
    }
    #endregion

    #region IObservable
    public override void OnNotify(ISubject subject, params object[] args)
    {
        base.OnNotify(subject, args);
        if (args[0] is sNotification)
        {
            sNotification sNotify = (sNotification) args[0];
            if (subject is TransitionController)
            {
                if (sNotify.key.CompareTo(TransitionController.ON_TRANSITION_COMPLETE) == 0)
                {
                    m_CurrentArea = sNotify.args[0] as Area;
                    m_CurrentArea.Play();
                }
            }
        }
    }
    #endregion
}