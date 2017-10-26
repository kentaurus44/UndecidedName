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
    [SerializeField] protected BoxCollider m_BoxCollider;
    [SerializeField] protected Transform m_FollowedObject;

    private Vector3 m_CurrentVelocity = Vector3.zero;
    private Camera m_Camera;
    private Vector3 m_TargetPosition;
    private sPerimeter m_CurrentPerimeter = new sPerimeter();

    [System.Serializable]
    public struct sPerimeter
    {
        public Vector3 Center;
        public Vector3 Size;

        public float RightExtend()
        {
            return Center.x + (Size.x / 2f);
        }

        public float LeftExtend()
        {
            return Center.x - (Size.x / 2f);
        }

        public float UpExtend()
        {
            return Center.x + (Size.x / 2f);
        }

        public float DownExtend()
        {
            return Center.x - (Size.x / 2f);
        }
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
        if (m_Camera != null)
        {
            m_TargetPosition = m_FollowedObject.position;
            m_TargetPosition.z = m_Camera.transform.position.z;

            // Horizontal Clipping
            if (m_TargetPosition.x + CameraWidth >= m_CurrentPerimeter.RightExtend())
            {
                m_TargetPosition.x = m_CurrentPerimeter.RightExtend() - CameraWidth;
            }
            else if (m_TargetPosition.x - CameraWidth <= m_CurrentPerimeter.LeftExtend())
            {
                m_TargetPosition.x = m_CurrentPerimeter.LeftExtend() + CameraWidth;
            }

            // Vertical Clipping
            if (m_TargetPosition.y + CameraHeight >= m_CurrentPerimeter.UpExtend())
            {
                m_TargetPosition.y = m_CurrentPerimeter.UpExtend() - CameraHeight;
            }
            else if (m_TargetPosition.y - CameraHeight <= m_CurrentPerimeter.DownExtend())
            {
                m_TargetPosition.y = m_CurrentPerimeter.DownExtend() + CameraHeight;
            }

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

    public void LoadPerimeter(sPerimeter perimeter)
    {
        m_CurrentPerimeter = perimeter;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}