using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public Text kunci;
	private bool ambilKunci = false;
	public Text starText, highScoreText;
	private static int totalStarts, hs;

	private Rigidbody2D myRigidbody;
	private Animator myAnimator;

	[SerializeField]
	private float movementSpeed;

	[SerializeField]
	private Transform[] groundPoint;

	[SerializeField]
	private float groundRadius;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool facingRight;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start ()
	{
		UpdateKunci ();
		UpdateStarText ();
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnimator = GetComponent<Animator>();

		hs = PlayerPrefs.GetInt ("hs");
		highScoreText.text = "High Score :" + hs.ToString ();
	}

	void Update()
	{
		HandleInput();
	}
		
	// Update is called once per frame
	void FixedUpdate () 
	{

		float horizontal = Input.GetAxis ("Horizontal");

		isGrounded = IsGrounded ();

		Movement (horizontal);
		Flip (horizontal);
		ResetValues ();
		HandleLayers ();  
	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.CompareTag ("Object"))
		{
			totalStarts++;
			UpdateStarText ();
			if (totalStarts > hs) {
				UpdateHs ();
			}
			Destroy (hit.gameObject);
		}

		if (hit.CompareTag("Kunci")) 
		{
			ambilKunci = true;
			UpdateKunci ();
			Destroy (hit.gameObject);
		}
			
	}

	private void Movement(float horizontal)
	{
		if (myRigidbody.velocity.y < 0)
		{
			myAnimator.SetBool ("mendarat", true);
		}
		if (isGrounded && jump) 
		{
			isGrounded = false;
			myRigidbody.AddForce(new Vector2(0, jumpForce));
			myAnimator.SetTrigger ("jump");
		}

		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
		myAnimator.SetFloat ("speed", Mathf.Abs(horizontal));
	}

	private void HandleInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			{
				jump = true;
			}
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}

	}
		
	private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in groundPoint)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

				for (int i = 0; i < colliders.Length; i++) 
				{
					if (colliders[i].gameObject != gameObject)
					{
						myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("mendarat", false);
						return true;
					}
				}
			}
		}
		return false;
	}

	private void ResetValues()
	{
		jump = false;
	}

	private void HandleLayers()
	{
		if (!isGrounded)
		{
			myAnimator.SetLayerWeight (1, 1);
		}
		else
		{
			myAnimator.SetLayerWeight (1, 0);
		}

	}

	private void UpdateStarText()
	{
		string starMEssage = "Find Stars : " + totalStarts;
		starText.text = starMEssage;
	}


	private void UpdateKunci()
	{
		string kunciMessage = "Temukan Kunci!!";
		if (ambilKunci) kunciMessage = "Selamat Berhasil Menemukan Kunci";
		kunci.text = kunciMessage;
	}

	public void UpdateHs()
	{
		hs = totalStarts;
		PlayerPrefs.SetInt ("hs", totalStarts);
		PlayerPrefs.Save ();
		highScoreText.text = "High Score :" + hs.ToString ();
	}

}
