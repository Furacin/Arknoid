using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour {

	public int i=0;
	public AudioClip sound;

	// Use this for initialization
	void Start () {
		print ("Este es mi primer script en Unity");
	}
	
	// Update is called once per frame
	void Update () {

		// Variable para la posicion actual
		Vector3 paddlePos = new Vector3 (8f, this.transform.position.y, 0f);

		// Posicion del raton
		float mousePos = Input.mousePosition.x / Screen.width * 16;

		// Definir nuevo valor para la X del raton
		paddlePos.x = Mathf.Clamp(mousePos, 0.5f, 15.5f);

		// Cambiar paddle para nueva X posicion
		this.transform.position = paddlePos;
	}

	void OnCollisionEnter2D(Collision2D col) {
		print ("Hit the paddle!");

		// Cambiar el tono 
		GetComponent<AudioSource>().pitch = Time.timeScale;

		// Sonido al tocar el muro
		GetComponent<AudioSource>().PlayOneShot(sound);
	}
}
