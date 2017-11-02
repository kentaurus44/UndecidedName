//
// Script name: InputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using TouchAction;

public class CircleInputController : DirectionalInputController
{
    #region Variables

	[SerializeField] protected float m_Radius = 50f;

    private float m_Ratio;

	public float Ratio 
	{
		get { return m_Ratio; }
	}
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods

    #endregion

    #region Protected Methods
    protected override void SetAngle(Vector3 target)
    {
        base.SetAngle(target);

        Vector3 direction = target - m_CenterPosition;

        if (direction.magnitude > m_Radius)
        {
            m_TargetPosition = m_CenterPosition + direction.normalized * m_Radius;
        }
        else
        {
            m_TargetPosition = target;
        }


        m_Ratio = Mathf.Clamp01(direction.magnitude / m_Radius);
    }
    #endregion

    #region Private Methods

    #endregion

    #region ITouchable
 //   public override bool OnTouchBegin(TouchEvent evt)
	//{
	//	m_IsActive = true;
	//	m_CenterPosition = evt.CurrentPosition;
	//	m_CenterPosition.z = transform.position.z;

	//	NotifyObservers(new sNotification(ON_TOUCH_BEGIN, m_TargetPosition - m_CenterPosition,  m_Angle, m_Ratio, m_IsActive));
	//	return m_IsActive && base.OnTouchBegin(evt);
	//}

	//public override void OnTouchMoved(TouchEvent evt)
	//{
	//	base.OnTouchMoved(evt);
	//	NotifyObservers(new sNotification(ON_TOUCH_MOVED, m_TargetPosition - m_CenterPosition, m_Angle, m_Ratio, m_IsActive));
	//}

	//public override void OnTouchEnded(TouchEvent evt)
	//{
	//	base.OnTouchEnded(evt);
	//	m_IsActive = false;
	//	NotifyObservers(new sNotification(ON_TOUCH_ENDED, m_TargetPosition - m_CenterPosition, m_Angle, m_Ratio, m_IsActive));
	//}
	#endregion
}