using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies 
{
	public abstract class EnemyBase : MonoBehaviour
	{
		protected float maxHealth;
		protected float health;
		protected float speed;

		protected bool burning;
		protected bool stunned; //An indicator for tower abilities to make use of
		protected bool facingRight;

		protected float incendiaryMultiplier;
		protected float physicalMultiplier;
		protected float electricMultiplier;

		protected float deathAnimLength;
		
		protected Rigidbody2D rb;
		public Transform nextDestination;

		protected void Awake()
		{
			Init();

			rb = GetComponent<Rigidbody2D>();

			health = maxHealth;

			burning = false;
			stunned = false;

			StartPathfinding(nextDestination);
		}

		protected virtual void Init() 
		{

		}

		public void StartPathfinding(Transform dest) 
		{
			float nodeAngle = Mathf.Atan((dest.position.y - transform.position.y)/(dest.position.x - transform.position.x)) * Mathf.Rad2Deg; //This finds the angle that next pathfinding position is from the player
			rb.velocity = new Vector2(Mathf.Cos(Mathf.Round(nodeAngle)) * speed, Mathf.Sin(Mathf.Round(nodeAngle)) * speed); // This should make it so the magnitude of velocity is the same no matter what direction the next destination is. The angle is rounded to the nearest because Unity's velocity only accepts up to 2 decimal places;

			//^^^ BRUH THIS IS COMPLETELY BROKEN RN LOL FIX IT

			if ((Mathf.Cos(nodeAngle) * speed) < 0) 
			{
				if (facingRight) 
				{
					Flip();
				}
			} else if ((Mathf.Cos(nodeAngle) * speed) > 0) 
			{
				if(!facingRight) 
				{
					Flip();
				}
			}
		}

		protected void Flip() 
		{
			facingRight = !facingRight;
			transform.localScale = transform.localScale * -1;
		}

		protected virtual IEnumerator Die()
		{
			//Play the corresponding animation

			yield return new WaitForSeconds(deathAnimLength);

			Destroy(gameObject);
		}

		public void TakeDamage(float damage, attackType type) 
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

			// Disable movement - possible through disabling the movement component or changing the destination/speed

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