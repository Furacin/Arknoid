using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpDrop : MonoBehaviour {

	public BasePowerUp PowerUpPrefab;
	// Use this for initialization

	// Cuando colisiona se crea el powerup en esta posicion
	void OnCollisionEnter2D(Collision2D c) {
		GameObject.Instantiate (PowerUpPrefab, this.transform.position, Quaternion.identity); // Quaterion.identity significa que no hay rotacion sobre el objeto y que esta perfectamente alineado con el espacio en la escena
	}
}
