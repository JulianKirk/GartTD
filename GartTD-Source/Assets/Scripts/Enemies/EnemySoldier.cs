using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies 
{
	public class EnemySoldier : EnemyBase
	{
		protected override void Init() 
		{
			maxHealth = 10f;

			speed = 2f;

			incendiaryMultiplier = 2f;
			physicalMultiplier = 1f;
			electricMultiplier = 1.5f;

			deathAnimLength = 1f;

			facingRight = true;
		}

		protected override IEnumerator Die() 
		{
			//Play the corresponding animation

			yield return new WaitForSeconds(deathAnimLength);

			//Destroy(gameObject);
		}
	}
}