using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public abstract class EnemySoldier : EnemyBase
	{
		protected override float maxHealth = 10f;
		protected override float health;
		protected override float speed = 2f;

		protected override float incendiaryMultiplier = 2f;
		protected override float physicalMultiplier = 1f;
		protected override float electricMultiplier = 1.5f;

		public override float deathAnimLength = 1f;

		protected abstract IEnumerator Die() 
		{
			//Play the corresponding animation

			//yield return new WaitForSeconds(deathAnimLength);

			//Destroy(gameObject);
		}
	}
}