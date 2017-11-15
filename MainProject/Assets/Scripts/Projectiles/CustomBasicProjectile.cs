//
// Script name: CustomBasicProjectile
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class CustomBasicProjectile : Shooter.BasicProjectile 
{
	#region Variables
	#endregion

	#region Unity API
	protected override void OnTriggerEnter(Collider collider)
	{
		base.OnTriggerEnter(collider);
		Shooter.BasicProjectile projectile = collider.GetComponent<Shooter.BasicProjectile>();
		if (projectile != null && projectile.Identifier != Identifier)
		{
			ProjectileDestroyed();
		}
	}
	#endregion

	#region Public Methods
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

}
