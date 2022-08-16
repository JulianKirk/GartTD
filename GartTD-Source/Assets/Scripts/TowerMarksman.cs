using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers
{
	public abstract class TowerMarksman: TowerBase
	{
		public override targetingMode currentTargetingMode = targetingMode.First;
		public override attackType curentAttackType = attackType.Physical;
		public LayerMask whatIsEnemies; // Set this without the editor later

		public override float attackRange = 5f; //May change later - depends on distance between towers
		public override float attackSpeed = 0.5f;
		public override float baseDamage = 10f;
		private float _remainingCoolDown;

		public override int upgradePath1 = 0;
		public override int upgradePath2 = 0;

		void Start() 
		{
			_remainingCoolDown = attackSpeed;
		}

		public override void basicAttack()
		{
			_remainingCoolDown-= Time.DeltaTime;

			if (remainingCoolDown <= 0) 
			{
				Collider[] enemies = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.z), attackRange, whatIsEnemies);

				if (enemies != null) 
				{
					enemies[Random.Range(enemies.Length)].GetComponent<EnemyBase>().TakeDamage(baseDamage + (2 * Float.Parse(upgradePath1)), currentAttackType);
					//Upgrade path one is focused on increasing damage.
					//Temporarily set to hit someone random
				}

				_remainingCoolDown = attackSpeed;
			}
		}
	}
}