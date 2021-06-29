using UnityEngine;
using System.Collections;

public class Destroyme : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Destroy", 2.0f);
	}
	
	// Update is called once per frame
	// void Update () {
	
	// }

	void Destroy()
	{

		if (gameObject.name == "Fireblast") 
		{
			Destroy (gameObject, 2.0f);
		} 
		if (gameObject.name == "GateOpen") 
		{
			Destroy (gameObject, 3.0f);
		}
		if (gameObject.name == "fireExplosion") 
		{
			Destroy (gameObject, 3.0f);
		}
		else
		{
			Destroy (gameObject);
		}

	}
}
