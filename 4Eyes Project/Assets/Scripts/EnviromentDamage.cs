using UnityEngine;
using System.Collections;

public class EnviromentDamage : MonoBehaviour
{
	public bool thingIn = false;
	private float damage = 2f;

	void OnTriggerEnter2D(Collider2D other){
		thingIn = true;
		other.SendMessage("takeDamage", damage);
	}
}
