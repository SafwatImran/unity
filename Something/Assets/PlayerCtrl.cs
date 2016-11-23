using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator anim;
	private float hspeed;
	private bool facingRight;
	private float vspeed;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		hspeed = rb.velocity.x;
		vspeed = rb.velocity.y;
		if (Input.GetKeyDown (KeyCode.A)) {
			anim.SetBool ("attack", true);
		}
		anim.SetFloat ("verticalspeed", Mathf.Abs (vspeed));
		anim.SetFloat ("mSpeed", Mathf.Abs(hspeed));
		if(Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce(new Vector2(10f,0f));
			if (!facingRight)
				Flip ();
		}
		if(Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(new Vector2(-10f,0f));
			if (facingRight)
				Flip ();

		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			rb.AddForce(new Vector2(0f,0f));
		}


		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
			rb.velocity = new Vector2 (0f, 0f);
		}

	}



	private void Flip()
	{		
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}
}
