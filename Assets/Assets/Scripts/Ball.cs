using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private bool gameStarted = false;
	private Vector3 paddleVector; // Posicion de la bola con respecto al paddle

	void Start () {
		// Distancia entre la bola y el paddle. Esto siturara la bola encima del paddle cuando empiece la escena
		paddleVector = this.transform.position - paddle.transform.position; 
	}

	void Update () {
		if (!gameStarted) { // Si el juego no ha empezado
			this.transform.position = paddle.transform.position + paddleVector; // unimos la bola al paddle confome se mueva
			if (Input.GetMouseButtonDown (0)) { // Si clickamos, el juego empieza
				print ("Click del raton!");
				gameStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f,10f); // Se lanza la bola con velocidad
			}
		}
	}
}
