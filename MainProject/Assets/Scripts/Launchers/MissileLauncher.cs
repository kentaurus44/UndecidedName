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
		Fire(m_Target);
	}
	#endregion

	#region Protected Methods
	protected override void OnReloadCOmplete()
	{
		base.OnReloadCOmplete();
		Fire(m_Target);
	}

	protected override void CreateProjectile(Transform target, Transform startlocation, Vector3 direction)
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
