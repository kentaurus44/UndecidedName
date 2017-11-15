//
// Script name: Bullet
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class Bullet : Shooter.BasicProjectile 
{
	#region Variables
	#endregion

	#region Unity API
	#endregion

	#region Public Methods
	public override void Launch(Vector3 target, float velocity, Vector3 unityDirection)
	{
		base.Launch(target, velocity, unityDirection);
	}
	#endregion

	#region Protected Methods
	#endregion

	#region Private Methods
	#endregion

}
