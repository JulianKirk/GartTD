using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public abstract class EnemyBase : MonoBehaviour
	{
		protected abstract float health;
		protected abstract float speed;

		public abstract float deathAnimLength;

		protected abstract Transform destination;

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