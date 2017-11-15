//
// Script name: BasicCollidable
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace Shooter
{
	[RequireComponent(typeof(BoxCollider))]
	public class BasicCollidable : MonoBehaviour, ICollidable
	{
		#region Variables
		#endregion

		#region Unity API
		#endregion

		#region Public Methods
		public void ApplyEffect(IProjectile projectile)
		{

		}
		#endregion

		#region Protected Methods
		#endregion

		#region Private Methods
		#endregion
	}
}