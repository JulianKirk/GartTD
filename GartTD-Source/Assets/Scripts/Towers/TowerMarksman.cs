using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
	public class TowerMarksman: TowerBase
	{
		private float _remainingCoolDown;

		protected override void Init() 
		{
			_remainingCoolDown = attackSpeed;

			currentTargetingMode = targetingMode.First;	
			currentAttackType = attackType.Physical;

			attackRange = 5f; //May change later - depends on distance between towers
			attackSpeed = 0.5f;
			baseDamage = 10f;

			upgradePath1 = 0;
			upgradePath2 = 0;
		}

		protected override void basicAttack()
		{
			_remainingCoolDown-= Time.deltaTime;

			if (_remainingCoolDown <= 0) 
			{
				Collider2D[] enemies = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.z), attackRange, whatIsEnemies);

				if (enemies != null) 
				{
					enemies[Random.Range(0, enemies.Length)].GetComponent<Enemies.EnemyBase>().TakeDamage(baseDamage + (2 * (float)upgradePath1), currentAttackType);
					//Max value of Random.Range for integers is exclusive so this is fine
					//Upgrade path one is focused on increasing damage.
					//Temporarily set to hit someone random
				}

				_remainingCoolDown = attackSpeed;
			}
		}
	}
}