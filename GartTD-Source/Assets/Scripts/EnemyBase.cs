using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public abstract class EnemyBase : MonoBehaviour
	{
		protected abstract float maxHealth;
		protected abstract float health;
		protected abstract float speed;

		protected bool burning;
		protected bool stunned;

		protected abstract float incendiaryMultiplier;
		protected abstract float physicalMultiplier;
		protected abstract float electricMultiplier;

		public abstract float deathAnimLength;

		protected Transform destination;
		protected NavMeshAgent agent;

		protected void Start()
		{
			health = maxHealth;

			burning = false;
			stunned = false;

			destination = Gameobject.FindWithTag("endPoint").transform;
			agent = gameObject.GetComponent<NavMeshAgent>();

			agent.speed = speed;
			agent.SetDestination(destination);
		}

		protected abstract IEnumerator Die() 
		{
			//Play the corresponding animation

			//yield return new WaitForSeconds(deathAnimLength);

			//Destroy(gameObject);
		}

		protected void TakeDamage(float damage, attackType type) 
		{
			//Possibly trigger an animation

			switch (type)
			{
				case (attackType.Incendiary):
					health -= damage * incendiaryMultiplier;
					break;
				case (attackType.Electric):
					health -= damage * electricMultiplier;
					break;
				case (attackType.Physical):
					health -= damage * physicalMultiplier;
					goto default;
				default:
					health -= damage;
					break;
			}
		}

		protected IEnumerator Stun(float stunTime) 
		{
			stunned = true;

			// Disable movement - possible through disabling the Navmesh component or changing the destination/speed

			// Play stun animation - I can set the trigger as the same name for all enemies

			yield return new WaitForSeconds(stunTime);

			//Re-enable the movement

			stunned = false;
		}

		protected IEnumerator Burn(float burnTime, float burnPercentage) 
		{
			burning = true;
			// Play burning animation - I can set the trigger as the same name for all enemies

			yield return new WaitForSeconds(burnTime);

			burning = false;
		}
	}
}