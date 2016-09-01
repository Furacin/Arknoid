using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	//Funcion básica para cargar un nivel
	public void LoadScene(int level) {
		print ("Cargando nivel" + level);
		Application.LoadLevel (level);
	}
}
