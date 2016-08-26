using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Wall : MonoBehaviour {

	public AudioClip sound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) {
		print ("Hit the wall!");

		// Sonido al tocar el muro
		GetComponent<AudioSource>().PlayOneShot(sound);
	}
}
