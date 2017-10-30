//
// Script name: DirectionalInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;


public class DirectionalInputController : SubjectObserver
{
    #region Variables
    public const string ON_TOUCH_BEGIN = "ON_TOUCH_BEGIN";
    public const string ON_TOUCH_MOVED = "ON_TOUCH_MOVED";
    public const string ON_TOUCH_ENDED = "ON_TOUCH_ENDED";

    protected Vector3 m_CenterPosition;
    protected Vector3 m_TargetPosition;
    protected float m_Angle;

    [SerializeField] protected bool m_InitOnAwake = false;

    public float Angle
    {
        get { return m_Angle; }
    }
    #endregion

    #region Unity API
    protected virtual void Awake()
    {
        if (m_InitOnAwake)
        {
            Init();
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(m_CenterPosition, m_TargetPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(m_CenterPosition, 5f);
    }

    #endregion

    #region Public Methods
    public virtual void Init()
    {

    }
    #endregion

    #region Protected Methods
    protected virtual void SetAngle(Vector3 target)
    {
        target.z = transform.position.z;

        Vector3 direction = target - m_CenterPosition;

        // Vector3.Angle can only find 180 angles
        m_Angle = Vector3.Angle(Vector3.up, direction);

        // Checking for 360 degress
        if (m_CenterPosition.x > m_TargetPosition.x)
        {
            m_Angle = 360 - m_Angle;
        }
    }
    #endregion

    #region Private Methods
    #endregion

    #region ITouchable
    #endregion
}