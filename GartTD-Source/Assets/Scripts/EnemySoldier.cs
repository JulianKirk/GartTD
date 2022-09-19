using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public class EnemySoldier : EnemyBase
	{
		void Start() {
			maxHealth = 10f;
			health = maxHealth;

			speed = 2f;

			incendiaryMultiplier = 2f;
			physicalMultiplier = 1f;
			electricMultiplier = 1.5f;

			deathAnimLength = 1f;

			//Debug.Log(Mathf.Atan(1f) * Mathf.Rad2Deg); --- Testing the output of Atan and conversion to degrees
			//StartPathfinding(destination);
		}

		protected override IEnumerator Die() 
		{
			//Play the corresponding animation

			yield return new WaitForSeconds(deathAnimLength);

			//Destroy(gameObject);
		}
	}
}