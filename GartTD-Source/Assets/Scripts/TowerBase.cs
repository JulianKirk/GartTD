using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum attackType {Physical, Incendiary, Electric};

namespace Towers
{
	public enum targetingMode {First, Last, Strongest};

	public abstract class TowerBase: MonoBehaviour
	{
		protected targetingMode currentTargetingMode;
		protected attackType currentAttackType;
		protected LayerMask whatIsEnemies;

		protected float attackRange;
		protected float attackSpeed;
		protected float baseDamage;

		protected int upgradePath1;
		protected int upgradePath2;

		protected SpriteRenderer renderer;
		protected Sprite[,] sprites = new Sprite[6, 6];
		//25 sprites in total for the different combinations of upgrades. Needs to be assigned in the subclasses.
		//Possible change into using the animation system and triggers instead

		protected abstract void basicAttack();

		protected void Upgrade(int path1, int path2) 
		{
			upgradePath1 += path1;
			upgradePath2 += path2;

			renderer.sprite = sprites[upgradePath1, upgradePath2];
			//Possibly change animator too
		}
	}
}