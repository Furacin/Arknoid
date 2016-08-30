using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(AudioSource))]
public class BasePowerUp : MonoBehaviour {

	public float DropSpeed = 1; // Velocidad a la que cae
	public AudioClip Sound; // Sonido de activacion del power-up

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().playOnAwake = false;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
	
	}

	IEnumerator OnTriggerEnter2D(Collider2D other ) {
		// Si hemos interactuado con el paddle
		if (other.name == "Paddle") {
			// Ejecutar Power-up
			OnPickup();

			// Desactivar más colisiones
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Renderer> ().enabled = false;

			// Cambiar el tono del sonido
			GetComponent<AudioSource>().pitch = Time.timeScale;

			// Ejecutar sonido y esperar
			GetComponent<AudioSource>().PlayOneShot(Sound);
			yield return new WaitForSeconds (Sound.length);
		}
	}

	// ESTE ES EL METODO QUE VAN A HEREDAR TODOS LOS POWERUPS DE ESTA CLASE
	protected virtual void OnPickup() {

	}

}
