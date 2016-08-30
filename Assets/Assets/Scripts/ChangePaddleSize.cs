using UnityEngine;
using System.Collections;

public class ChangePaddleSize : BasePowerUp {

	// Variable para incrementar o decrementar el tamaño del paddle al interactuar con el power-up
	public Vector3 SizeIncrease = Vector3.zero;

	public Vector3 MinPaddleSize = new Vector3(0.1F, 0.1F, 0.4F);

	protected override void OnPickup ()
	{
		//Call the default behaviour of the base class first
		base.OnPickup ();

		// Se cambia el comportamiento, cambiando el tamaño en este caso
		Paddle p = FindObjectOfType (typeof(Paddle)) as Paddle;
		p.transform.localScale += SizeIncrease;

		// Limitamos el tamaño minimo del paddle
		Vector3 size = p.transform.localScale;
		if (size.x < MinPaddleSize.x)
			size.x = MinPaddleSize.x;
		if (size.y < MinPaddleSize.y)
			size.y = MinPaddleSize.y;
		if (size.z < MinPaddleSize.z)
			size.z = MinPaddleSize.z;

		p.transform.localScale = size; 
	}
}
