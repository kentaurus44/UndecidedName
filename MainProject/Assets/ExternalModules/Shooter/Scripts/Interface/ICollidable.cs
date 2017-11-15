//
// Script name: ICollidable
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

namespace Shooter
{
	public interface ICollidable
	{
		void ApplyEffect(IProjectile projectile);
	}
}