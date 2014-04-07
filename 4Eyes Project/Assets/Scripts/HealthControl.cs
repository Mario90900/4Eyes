using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour
{
	public float health = 6f;
	public float maxHealth = 6f;
	public float invincibleTime = 15f;

	private float invincibleCount;
	private bool isInvincible = false;
	private HeartHandler uiHandler;
	
		void Awake ()
		{
			invincibleCount = invincibleTime;
			uiHandler = (HeartHandler) GameObject.Find("Main Camera").GetComponent("HeartHandler");
		}

		void FixedUpdate() //Counts down the invincibility for when it should wear off
		{
			if (invincibleCount != 0) {
					invincibleCount--;
			} else {
					isInvincible = false;
			}
		}

		bool checkInvincibility() //To determine if the player is still invincible
		{
			return isInvincible;
		}

		void heal (int amount) //Heals the player for the set amount
		{
			if ((health + amount) >= maxHealth){
					health = maxHealth;
			} else {
					health += amount;
			}
			uiHandler.updateHearts(health);
		}

		void hurt (int amount) //Hurts the player's health for the sent amount
		{
			if ((health - amount) <= 0f) {
					health = 0;
			} else {
					health -= amount;
			}
			uiHandler.updateHearts(health);
			if (health == 0) {
					playerDie();
			}
			isInvincible = true;
		}

		void playerDie() //Called to kill the player
		{
			//Need to finish
		}
}

