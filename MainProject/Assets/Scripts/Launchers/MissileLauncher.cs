//
// Script name: MissileLauncher
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileLauncher : Shooter.BasicLauncher
{
	#region Variables
	#endregion

	#region Unity API
	[SerializeField] protected List<Transform> m_StartLocation = new List<Transform>();
	[SerializeField] protected Transform m_Target;
	#endregion

	#region Public Methods
	protected virtual void Start()
	{
		if (m_Target != null)
		{
			Fire(m_Target.position);
		}
	}
	#endregion

	#region Protected Methods
	protected override void OnReloadCOmplete()
	{
		base.OnReloadCOmplete();
		if (m_Target != null)
		{
			Fire(m_Target.position);
		}
	}

	protected override void CreateProjectile(Vector3 target, Transform startlocation, Vector3 direction)
	{
		for (int i = 0; i < m_StartLocation.Count; ++i)
		{
			base.CreateProjectile(target, m_StartLocation[i], m_StartLocation[i].right);
		}
	}
	#endregion

	#region Private Methods
	#endregion

}
