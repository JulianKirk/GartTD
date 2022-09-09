using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum attackType {Physical, Incendiary, Electric};

namespace Towers
{
	enum targetingMode {First, Last, Strongest};

	public abstract class TowerBase: MonoBehaviour
	{
		protected abstract targetingMode currentTargetingMode;
		protected abstract attackType curentAttackType;

		protected abstract float attackRange;
		protected abstract float attackSpeed;
		protected abstract float baseDamage;

		protected abstract int upgradePath1;
		protected abstract int upgradePath2;

		protected abstract SpriteRenderer renderer;
		protected Sprite[] sprites = new Sprite[6, 6];
		//25 sprites in total for the different combinations of upgrades. Needs to be assigned in the subclasses.
		//Possible change into using the animation system and triggers instead

		protected abstract void basicAttack()
		{

		}

		protected void Upgrade(int path1, int path2) 
		{
			upgradePath1 += path1;
			upgradePath2 += path2;

			renderer.sprite = sprites[upgradePath1, upgradePath2];
		}
	}
}