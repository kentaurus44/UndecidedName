//
// Script name: Missle
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class Missle : Shooter.BasicProjectile 
{
	#region Variables
	[SerializeField] [Range(0f, 1f)] protected float m_LaunchingRatio = 0.1f;
	[SerializeField] protected float m_MinVelocity = 0;
	[SerializeField] protected float m_MaxSpeedIn = 1f;
	protected float m_InitialVelociy = 0f;

	private Timer m_RepositioningTimer = new Timer();
	#endregion

	#region Unity API
	protected override void Update()
	{
		if (m_RepositioningTimer != null)
		{
			m_RepositioningTimer.OnUpdate();
		}

		CorrectingAngle();

		base.Update();
	}
	#endregion

	#region Public Methods
	public override void Launch(Transform target, float velocity, Vector3 unityDirection)
	{
		m_RepositioningTimer.StartTimer(m_MaxSpeedIn);
		m_InitialVelociy = velocity;
		base.Launch(target, velocity, unityDirection);
	}
	#endregion

	#region Protected Methods
	protected override void Travel()
	{
		m_Velocity = Mathf.Clamp(m_InitialVelociy * m_RepositioningTimer.Ratio, m_MinVelocity, m_InitialVelociy);

		base.Travel();
	}

	protected virtual void CorrectingAngle()
	{
		Vector3 wantedDirection = (m_Target.transform.position - transform.position).normalized;
		Vector3 direction = transform.right;

		m_UnityDirection += (wantedDirection - direction) * Mathf.Clamp01(m_RepositioningTimer.Ratio);
		transform.right = m_UnityDirection;
	}
	#endregion

	#region Private Methods
	#endregion

}
