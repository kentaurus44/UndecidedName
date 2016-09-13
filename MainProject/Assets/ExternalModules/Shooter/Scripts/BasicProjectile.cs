﻿//
// Script name: BasicProjectile
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace Shooter
{
	[RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
	public abstract class BasicProjectile : Subject, IProjectile
	{
		#region Variables
		public enum eProjectileState
		{
			None,
			Launching,
			Traveling,
			Targeting,
			Repositioning,
			Destroyed
		}

		protected float m_Velocity = 0;
		protected Transform m_Target;
		protected Vector3 m_UnityDirection;
		#endregion

		#region Unity API
		protected virtual void Update()
		{
			Travel();
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.GetComponent<ICollidable>() != null)
			{
				collider.gameObject.GetComponent<ICollidable>().ApplyEffect(this);
				ProjectileDestroyed();
			}
		}
		#endregion

		#region Public Methods
		public virtual void Launch(Transform target, float velocity, Vector3 unityDirection)
		{
			m_Target = target;
			m_Velocity = velocity;
			m_UnityDirection = unityDirection;
			NotifyObservers(eProjectileState.Launching);
		}
		#endregion

		#region Protected Methods
		protected virtual void Travel()
		{
			transform.position += m_UnityDirection.normalized * m_Velocity * Time.deltaTime;		
		}

		protected virtual void ProjectileDestroyed()
		{
			NotifyObservers(eProjectileState.Destroyed);
			Destroy(gameObject);
		}
		#endregion

		#region Private Methods
		#endregion
	}
}