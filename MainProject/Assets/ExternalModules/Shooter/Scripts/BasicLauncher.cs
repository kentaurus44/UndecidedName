//
// Script name: BasicLauncher
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;
using System.Net.Security;

namespace Shooter
{
	public abstract class BasicLauncher : SubjectObserver, ILauncher
	{
		#region Variables
		[SerializeField] protected BasicProjectile m_Projectile;
		[SerializeField] protected float m_LaunchVelocity = 20f;
		[SerializeField] [Range(0, 100f)] protected float m_ReloadTime;
		[SerializeField] protected string m_Identifier;

		protected bool m_CanShoot = true;
		protected Timer m_Timer = new Timer();
		protected int m_NumOfProjectilesOut = 0;

		public int NumOfProjectileOut 
		{
			get { return m_NumOfProjectilesOut; }
		}
		#endregion

		#region Unity API
		protected virtual void Update()
		{
			if (m_Timer != null)
			{
				m_Timer.OnUpdate();
			}
		}
		#endregion

		#region Public Methods
		public virtual void Fire(Vector3 target)
		{
			if (!m_CanShoot)
			{
				OnFireDenial();
				return;
			}

			m_CanShoot = m_ReloadTime == 0f;

			m_Timer.StartTimer(m_ReloadTime, OnReloadCOmplete, true);
			CreateProjectile(target, transform, Vector3.forward);
		}
		#endregion

		#region Protected Methods
		protected virtual void CreateProjectile(Vector3 target, Transform startPosition, Vector3 direction)
		{
			BasicProjectile projectile = Instantiate(m_Projectile);
			projectile.transform.eulerAngles = startPosition.eulerAngles;
			projectile.transform.position = startPosition.position;
			projectile.RegisterObserver(this);
			projectile.SetIdentifier(m_Identifier);
			projectile.Launch(target, m_LaunchVelocity, direction);
			ProjectileManager.Instance.AddProjectile(projectile);
		}

		protected virtual void OnReloadCOmplete()
		{
			m_CanShoot = true;
		}

		protected virtual void OnFireDenial()
		{
			// STUB
		}

		protected virtual void OnProjectileLaunched()
		{
			++m_NumOfProjectilesOut;
		}

		protected virtual void OnProjectileDestroyed()
		{
			--m_NumOfProjectilesOut;
		}
		#endregion

		#region Private Methods
		#endregion

		#region SubjectObserver
		public override void OnNotify(ISubject subject, params object[] args)
		{
			base.OnNotify(subject, args);
			if (subject is BasicProjectile)
			{
				switch((BasicProjectile.eProjectileState)args[0])
				{
					case BasicProjectile.eProjectileState.Destroyed:
					OnProjectileDestroyed();
					break;
					case BasicProjectile.eProjectileState.Launching:
					OnProjectileLaunched();
					break;
				}
			}
		}
		#endregion
	}
}