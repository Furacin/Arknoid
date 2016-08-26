using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	private Ball ball;
	private GameManager gamemanager;

	IEnumerator Pause() {
		print("Before Waiting 2 seconds");
		// Cambiar el estado del GameManager
		gamemanager = GameObject.FindObjectOfType<GameManager>();
		gamemanager.SwitchState (GameState.Failed);

		yield return new WaitForSeconds(2);

		//Find the ball and reset game start
		ball = GameObject.FindObjectOfType<Ball>();
		ball.gameStarted = false;

		//Reload level
		Application.LoadLevel(Application.loadedLevel);

		print("After Waiting 2 Seconds");
	}

	void OnTriggerEnter2D (Collider2D trigger){
		print ("Lost Triggered!");

		//Wait before restarting level
		StartCoroutine(Pause());

	}
}
