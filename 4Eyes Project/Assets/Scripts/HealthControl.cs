using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour
{
	public float health = 6f;
	public float maxHealth = 6f;
	public float invincibleTime = 15f;

	private float invincibleCount;

		// Use this for initialization
		void Awake ()
		{
			invincibleCount = invincibleTime;
		}

		void heal (int amount)
		{
			if ((health + amount) >= maxHealth){
					health = maxHealth;
			} else {
					health += amount;
			}
		}

		void hurt (int amount)
		{
				if ((health - amount) <= 0f) {
						health = 0;
						//playerDie();
				} else {
						health -= amount;
				}
		}
}

