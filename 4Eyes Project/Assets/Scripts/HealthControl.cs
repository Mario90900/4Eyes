using UnityEngine;
using System.Collections;

public class HealthControl : MonoBehaviour
{
	public float health = 6f;
	public float maxHealth = 6f;
	public float invincibleTime = 3f; //In Seconds

	private float invincibleStartTime;
	private bool isInvincible = false;
	private HeartHandler uiHandler;
	
		void Awake ()
		{
			uiHandler = (HeartHandler) GameObject.Find("Main Camera").GetComponent("HeartHandler");
		}

		void FixedUpdate() //Counts down the invincibility for when it should wear off
		{
			if ((Time.fixedTime - invincibleStartTime) > invincibleTime) {
				isInvincible = false;
				invincibleStartTime = 0;
			}
		}

		public bool checkInvincibility() //To determine if the player is still invincible
		{
			return isInvincible;
		}

		public void heal (float amount) //Heals the player for the set amount
		{
			if ((health + amount) >= maxHealth){
					health = maxHealth;
			} else {
					health += amount;
			}
			uiHandler.updateHearts(health);
		}

		public void hurt (float amount) //Hurts the player's health for the sent amount
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
			invincibleStartTime = Time.fixedTime;
			isInvincible = true;
		}

		void playerDie() //Called to kill the player
		{
			//Need to finish
		}
}

