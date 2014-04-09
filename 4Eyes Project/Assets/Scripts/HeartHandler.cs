using UnityEngine;
using System.Collections;

public class HeartHandler : MonoBehaviour
{
	public float currentHealth = 6f;
	private Renderer[] heartsRenders = new Renderer[6];

	// Use this for initialization
	void Awake() //Finds all the hearts with the "Hearts" tag and puts their spriterenderer in the list
	{
		heartsRenders [0] = GameObject.Find("Heart1").renderer;
		heartsRenders [1] = GameObject.Find("Heart2").renderer;
		heartsRenders [2] = GameObject.Find("Heart3").renderer;
		heartsRenders [3] = GameObject.Find("Heart4").renderer;
		heartsRenders [4] = GameObject.Find("Heart5").renderer;
		heartsRenders [5] = GameObject.Find("Heart6").renderer;
	}

	public void updateHearts(float newHealth) //Called to update the visible hearts to the number sent
	{
		float difference = currentHealth - newHealth;

		if (difference > 0f) {
			for (float i = 0; i < difference; i++){
				heartsRenders[(int)(currentHealth - i - 1)].enabled = false;
			}
		} else {
			float temp = Mathf.Abs (difference);
			for (float i = 1; i <= temp; i++){
				heartsRenders[(int)(currentHealth + i - 1)].enabled = true;
			}
		}

		currentHealth = newHealth;
	}
}