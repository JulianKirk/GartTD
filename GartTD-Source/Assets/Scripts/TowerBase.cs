using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum attackType {Physical, Incendiary, Electric};

namespace Towers
{
	enum targetingMode {First, Last, Strongest};

	public abstract class TowerBase: MonoBehaviour
	{
		public abstract targetingMode currentTargetingMode;

		public abstract attackType curentAttackType;

		public abstract float attackRange;

		public abstract float attackSpeed;

		public abstract float baseDamage;

		public abstract int upgradePath1;

		public abstract int upgradePath2;

		public abstract void basicAttack()
		{

		}
	}
}