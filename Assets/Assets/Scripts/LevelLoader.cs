using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	//Funcion básica para cargar un nivel
	public void LoadScene(int level) {
		Application.LoadLevel (level);
	}
}
