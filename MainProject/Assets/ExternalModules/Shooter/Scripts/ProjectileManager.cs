//
// Script name: ProjectileManager
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;

namespace Shooter
{
	public class ProjectileManager : SingletonComponent<ProjectileManager>
	{
		#region Variables
		List<BasicProjectile> m_Projectiles = new List<BasicProjectile>();
		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public void AddProjectile(BasicProjectile projectile)
		{
			projectile.gameObject.transform.parent = transform;
			projectile.RegisterObserver(this);
			m_Projectiles.Add(projectile);
		}
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		protected virtual void OnProjectileLaunched(BasicProjectile projectile)
		{
			
		}

		protected virtual void OnProjectileDestroyed(BasicProjectile projectile)
		{
			projectile.RegisterObserver(this);
			m_Projectiles.Remove(projectile);
		}
		#endregion

		#region IObserver
		public override void OnNotify(ISubject subject, params object[] args)
		{
			base.OnNotify(subject, args);
			if (subject is BasicProjectile)
			{
				switch((BasicProjectile.eProjectileState)args[0])
				{
					case BasicProjectile.eProjectileState.Destroyed:
					OnProjectileDestroyed(subject as BasicProjectile);
					break;
					case BasicProjectile.eProjectileState.Launching:
					OnProjectileLaunched(subject as BasicProjectile);
					break;
				}
			}
		}
		#endregion
	}
}