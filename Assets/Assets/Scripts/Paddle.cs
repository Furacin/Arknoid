	using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public int i=0;

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

		// Definir nuevo valor para la X del raton, poniendo la restriccion para que úncamente 
		// se mueva en el intervalo [0,15.5] en el eje X y así no salga de la pantalla al moverlo
		paddlePos.x = Mathf.Clamp(mousePos, 0f, 15.5f);

		// Cambiar paddle para nueva X posicion
		this.transform.position = paddlePos;
	}
}
