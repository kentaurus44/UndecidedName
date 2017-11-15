//
// Script name: StaightLauncher
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StaightLauncher : Shooter.BasicLauncher
{
	#region Variables
	#endregion

	#region Unity API
	[SerializeField] protected List<Transform> m_StartLocation = new List<Transform>();
	#endregion

	#region Public Methods
	#endregion

	#region Protected Methods
	protected override void CreateProjectile(Vector3 target, Transform startPosition, Vector3 direction)
	{
		startPosition = m_StartLocation.Count > 0 ? m_StartLocation[Random.Range(0, m_StartLocation.Count)] : transform;
		direction = target - startPosition.position;
		direction.z = startPosition.position.z;

		base.CreateProjectile(target, startPosition, direction);
	}
	#endregion

	#region Private Methods
	#endregion

}
