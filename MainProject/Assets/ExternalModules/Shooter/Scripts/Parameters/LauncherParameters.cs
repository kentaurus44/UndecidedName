//
// Script name: LauncherParameters
//
//
// Programmer: Kentaurus
//

using UnityEngine;

namespace Shooter
{
	public partial class LauncherParameters : ScriptableObject 
	{
		public BasicProjectile Projectile;
		public float LaunchVelocity = 0f;
		public float ReloadTime = 0f;
	}
}
