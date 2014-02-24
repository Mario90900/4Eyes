using UnityEngine;
using System.Collections;

public class MainCharacterControl : MonoBehaviour
{
	public bool facingRight = true;
	public bool jump = false;
	public float walkForce = 365f;
	public float walkMaxSpeed = 5f;
	public float jumpForce = 1000f;
	public float climbSpeed = 5f;

	private Transform groundCheck;
	private RaycastHit2D climbing;
	private Vector2 climbRange; // The X in the vector is the minimum lowest, while the Y is the maximum.
	private bool grounded = false;
	private bool isClimbing = false;
	private bool canClimb = false;
	
	// Use this for initialization
	void Awake ()
	{
		groundCheck = transform.Find ("groundCheck");
	}

	// Update is called once per frame
	void Update ()
	{
		if (isClimbing) { // Player is grounded if they are either on the ground, or on a climbable surface.
			grounded = true;
		} else {
			grounded = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")); 
		}

		canClimb = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Climbable")); // Testing for climbable surfaces.

		if (Input.GetButtonDown("Jump") && grounded) // Determines if to jump or not.
			jump = true;
	}

	void FixedUpdate ()
	{

		if (isClimbing) {
			float h = Input.GetAxis ("Horizontal"); // To flip both ways while climbing the ladder. Will determine attack direction while climbing.

			if (h > 0 && !facingRight) {
				flip ();
			} else if (h < 0 && facingRight) {
				flip ();
			}

			float v = Input.GetAxis ("Vertical"); // Direction to climb in.

			if (v > 0 && (transform.position.y < climbRange.y)){
				rigidbody2D.velocity = new Vector2(0f, (v*climbSpeed));
			} else if (v < 0 && (transform.position.y > climbRange.x)){
				rigidbody2D.velocity = new Vector2(0f, (v*climbSpeed));
			} else {
				rigidbody2D.velocity = new Vector2(0f, 0f);
			} 

			if (jump){ // Jumping off of the ladder to dismount it.
				rigidbody2D.AddForce (new Vector2 (0f, jumpForce/2f));
				jump = false;
				isClimbing = false;
				rigidbody2D.gravityScale = 1f;
			}

		} else {
			// Borrowed from the tutorial player control, it was very well written in utilizing the physics for even moving the player. 
			float h = Input.GetAxis ("Horizontal");

			if (h * rigidbody2D.velocity.x < walkMaxSpeed)
				rigidbody2D.AddForce (Vector2.right * h * walkForce);

			if (Mathf.Abs (rigidbody2D.velocity.x) > walkMaxSpeed)
				rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * walkMaxSpeed, rigidbody2D.velocity.y);

			if (h > 0 && !facingRight) {
				flip ();
			} else if (h < 0 && facingRight) {
				flip ();
			}

			if (jump) {
				rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
				jump = false;
			}
			// End of borrowed code
				
			float v = Input.GetAxis ("Vertical");
				
			if (canClimb && (v != 0f)){
				climbing = Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Climbable"));
				BoxCollider2D climbingBox = (BoxCollider2D)climbing.collider;
				Vector2 tempVector = new Vector2 ((climbingBox.center.y - (climbingBox.size.y / 2)), (climbingBox.center.y + (climbingBox.size.y / 2)));
				climbRange = tempVector;
				isClimbing = true;
				float x = climbing.collider.transform.position.x;
				transform.position.Set(x, transform.position.y, transform.position.z);
				rigidbody2D.gravityScale = 0f;
			}
		}
	}
	
	void flip() // Borrowed as well
	{
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

