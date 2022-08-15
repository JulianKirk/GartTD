using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase
{
	protected enum targetingMode {First, Last, Strongest};

	protected enum attackType {Physical, Incendiary, Electric};

	public abstract targetingMode currentTargetingMode;

	public abstract attackType curentAttackType;

	public abstract float attackRange;

	public abstract float attackSpeed;

}