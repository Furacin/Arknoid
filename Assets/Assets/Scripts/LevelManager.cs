using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject[] bricks;
	public int count = 0;
	private GameManager gameManager;
	public string FinishTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bricks = GameObject.FindGameObjectsWithTag ("Brick");
		Debug.Log("Brick Count: "+bricks.Length);
		count = bricks.Length;
		if (count == 0) {
			Debug.Log("Todos los bloques han sido destruidos!");
			//Wait before returning to Main level
			StartCoroutine (Pause ());
		}
	}

	IEnumerator Pause() {
		print("Before Waiting 5 seconds");
		//Switch GameManager State
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState (GameState.Completed); // Estado completado
		gameManager.ChangeText ("You Win :)");
		FinishTime = gameManager.formattedTime;
		Debug.Log("Has tardado "+FinishTime+ " en finalizar el juego!");
		yield return new WaitForSeconds(5);
		//Reload Main Menu
		LoadScene (0);
		print("Despues de esperar 5 segundos ir al menu principal");
	}

	public void LoadScene (int level)
	{
		Application.LoadLevel(level);
	}
}
