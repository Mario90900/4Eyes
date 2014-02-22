using UnityEngine;
using System.Collections;

public class MainCharacterControl : MonoBehaviour
{
	public bool facingRight = true;
	public bool jump = false;
	public float walkForce = 365f;
	public float walkMaxSpeed = 5f;
	public float jumpForce = 1000f;

	private Transform groundCheck;
	private bool grounded = false;


	// Use this for initialization
	void Awake ()
	{
		groundCheck = transform.Find ("groundCheck");
	}

	// Update is called once per frame
	void Update ()
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")); 

		if (Input.GetButtonDown("Jump") && grounded)
						jump = true;
	}

	void FixedUpdate ()
	{

		//Borrowed from the tutorial player control, it was very well written in utilizing the physics for even moving the player. 
		float h = Input.GetAxis("Horizontal");

		if(h * rigidbody2D.velocity.x < walkMaxSpeed)
			rigidbody2D.AddForce(Vector2.right * h * walkForce);

		if(Mathf.Abs(rigidbody2D.velocity.x) > walkMaxSpeed)
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * walkMaxSpeed, rigidbody2D.velocity.y);

		if (h > 0 && !facingRight) {
				flip ();
		} else if (h < 0 && facingRight) {
				flip ();
		}

		if (jump) {
				rigidbody2D.AddForce(new Vector2(0f, jumpForce));
				jump = false;
		}
	}

	void flip()
	{
			facingRight = !facingRight;
		
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}
}

