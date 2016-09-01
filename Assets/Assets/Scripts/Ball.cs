using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	public bool gameStarted = false;
	private Vector3 paddleVector;

	// Velocidades maxima y minima de la bola
	public float MinSpeed = 10;
	public float MaxSpeed = 20;

	public float MinimumVerticalMovement = 0.5F;

	// Use this for initialization
	void Start () {
		// Ponemos la bola sobre el paddle
		paddleVector = this.transform.position - paddle.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(!gameStarted){
			this.transform.position = paddle.transform.position + paddleVector;
			if(Input.GetMouseButtonDown(0)){
				print("Mouse clicked!");
				gameStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f,10f);
				this.GetComponent<TrailRenderer>().enabled = true; // efecto trailing	
			}
		}
		launchBall ();
	}

	public void launchBall() {
		//Get current speed and direction
		Vector2 direction = GetComponent<Rigidbody2D> ().velocity;
		//float speed = 20f;
		float speed = direction.magnitude;
		direction.Normalize ();
		//Make sure the ball never goes straight horizotal else it could never come down to the paddle.
		if (direction.x > -MinimumVerticalMovement && direction.x <
		    MinimumVerticalMovement) {
			//Adjust the x to limit it to the movement left or right
			direction.x = direction.x < 0 ? -MinimumVerticalMovement :
				MinimumVerticalMovement;
			//Adjust the y, make sure it keeps going into the direction it was going (up or down)
			direction.y = direction.y < 0 ? -1 + MinimumVerticalMovement : 1 - MinimumVerticalMovement;
			//print(direction.x);
			//Apply it back to the ball
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
		if (speed < MinSpeed || speed > MaxSpeed) {
			//Limit the speed so it always above min en below max
			speed = Mathf.Clamp (speed, MinSpeed, MaxSpeed);
			//Apply the limit
			//Note that we don't use * Time.deltaTime here since we set the velocity once, not every frame.
			GetComponent<Rigidbody2D> ().velocity = direction * speed;
		}
	}
}
