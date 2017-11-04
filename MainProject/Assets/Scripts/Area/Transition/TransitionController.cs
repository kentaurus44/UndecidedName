//
// Script name: TransitionController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using DG.Tweening;
using System.Collections;


public class TransitionController : SingletonComponent<TransitionController>
{
    #region Variables
    private const float PLAYER_OFFSET = 10f;
    public const string ON_TRANSITION_COMPLETE = "ON_TRANSITION_COMPLETE";
    [System.Serializable]
    public struct sTransitionParameters
    {
        public AreaTransition OriginAreaLocation;
        public AreaTransition TargetAreaLocation;
        public Area TargetArea;
    }

    protected CameraController m_CameraController;
    protected PlayerController m_PlayerController;
    [SerializeField] protected float m_TransitionLength = 0.5f;

    private bool m_IsTransitioning = false;
    private Area m_TargetArea;
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public void Init(CameraController cameraController, PlayerController playerController)
    {
        m_CameraController = cameraController;
        m_PlayerController = playerController;
    }

    public void BeginTransition(Area origin, sTransitionParameters paramters)
    {
        if (!m_IsTransitioning)
        {
            origin.Pause();
            m_TargetArea = paramters.TargetArea;

            m_IsTransitioning = true;
            m_CameraController.SnapToEdge = false;
            m_CameraController.LoadPerimeter(paramters.TargetArea.CameraPerimeter);
            Vector3 target = m_CameraController.GetTargetPostion(paramters.TargetAreaLocation.transform.position);

            Sequence seq = DOTween.Sequence();
            Tweener tween = CustomCamera.CameraManager.Instance.MainCamera.transform.DOMove(target, m_TransitionLength);
            seq.Append(tween);

            target = GetPlayerPosition(m_PlayerController.transform.position, paramters.TargetAreaLocation.transform.position, paramters.OriginAreaLocation.TransitionType);
            target.z = m_PlayerController.transform.position.z;
            tween = m_PlayerController.transform.DOMove(target, m_TransitionLength);
            seq.Join(tween);

            seq.OnComplete(OnTweenComplete);
        }
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    private void OnTweenComplete()
    {
        m_IsTransitioning = false;
        m_CameraController.SnapToEdge = true;
        NotifyObservers(new sNotification(ON_TRANSITION_COMPLETE, m_TargetArea));
    }

    public Vector3 GetPlayerPosition(Vector3 from, Vector3 to, AreaTransition.eTransitionType type)
    {
        Vector3 direction = (to - from);

        switch (type)
        {
            case AreaTransition.eTransitionType.X:
                direction.y = 0f;
                direction.x += Mathf.Sign(direction.x) * (m_PlayerController.BoxCollider.size.x / 2f + PLAYER_OFFSET);
                break;
            case AreaTransition.eTransitionType.Y:
                direction.x = 0f;
                direction.y += Mathf.Sign(direction.y) * (m_PlayerController.BoxCollider.size.y / 2f + PLAYER_OFFSET);
                break;
        }

        return direction + from;
    }
    #endregion
}