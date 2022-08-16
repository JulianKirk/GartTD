using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public abstract class EnemySoldier : EnemyBase
	{
		protected override float health = 10f;
		protected override float speed = 2f;

		public override float deathAnimLength = 1f;

		protected override Transform destination;

		void Start() 
		{
			destination = Gameobject.FindWithTag("endPoint").transform;
		}

		protected abstract IEnumerator Die() 
		{
			//Play the corresponding animation

			//yield return new WaitForSeconds(deathAnimLength);

			//Destroy(gameObject);
		}

		protected abstract IEnumerator TakeDamage(float damage, attackType type) 
		{
			//The subclasses will handle weaknesses and damage calculation
		}
	}
}