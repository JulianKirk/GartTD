using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase
{
	public abstract enum targetingMode {First, Last, Strongest};
	public abstract enum attackType {Physical, Incendiary, Electric};
	public abstract targetingMode currentTargetingMode;
	public abstract float attackRange;

}