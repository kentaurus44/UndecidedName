//
// Script name: CameraController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;

using System.Collections;

public class CameraController : MonoBehaviour
{
    #region Variables
    [SerializeField] protected bool m_InitOnAwake = false;
    [SerializeField] protected Transform m_FollowedObject;

    private Vector3 m_CurrentVelocity = Vector3.zero;
    private Camera m_Camera;
    private Vector3 m_TargetPosition;
    private CameraPerimeter m_CurrentPerimeter;
    private bool m_SnapToEdge = true;

    public bool SnapToEdge
    {
        get { return m_SnapToEdge; }
        set { m_SnapToEdge = value; }
    }

    private float CameraWidth
    {
        get { return m_Camera.orthographicSize * m_Camera.aspect; }
    }
    
    private float CameraHeight
    {
        get { return m_Camera.orthographicSize; }
    }
    #endregion

    #region Unity 
    protected virtual void Awake()
    {
        if (m_InitOnAwake)
        {
            Init();
        }
    }

    protected virtual void LateUpdate()
    {     
        if (m_SnapToEdge && m_Camera != null)
        {
            m_TargetPosition = GetTargetPostion(m_FollowedObject.position);

            // Smooth damp to follow character
            m_Camera.transform.position = Vector3.SmoothDamp(m_Camera.transform.position, m_TargetPosition, ref m_CurrentVelocity, 0.01f);
        }
    }
    #endregion

    #region Public Methods
    public void Init()
    {
        m_Camera = CustomCamera.CameraManager.Instance.MainCamera;
    }

    public void LoadPerimeter(CameraPerimeter perimeter)
    {
        m_CurrentPerimeter = perimeter;
    }

    public Vector3 GetTargetPostion(Vector3 targetPosition)
    {
        targetPosition.z = m_Camera.transform.position.z;

        // Horizontal Clipping
        if (targetPosition.x + CameraWidth >= m_CurrentPerimeter.RightExtend())
        {
            targetPosition.x = m_CurrentPerimeter.RightExtend() - CameraWidth;
        }
        else if (targetPosition.x - CameraWidth <= m_CurrentPerimeter.LeftExtend())
        {
            targetPosition.x = m_CurrentPerimeter.LeftExtend() + CameraWidth;
        }

        // Vertical Clipping
        if (targetPosition.y + CameraHeight >= m_CurrentPerimeter.UpExtend())
        {
            targetPosition.y = m_CurrentPerimeter.UpExtend() - CameraHeight;
        }
        else if (targetPosition.y - CameraHeight <= m_CurrentPerimeter.DownExtend())
        {
            targetPosition.y = m_CurrentPerimeter.DownExtend() + CameraHeight;
        }

        return targetPosition;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}