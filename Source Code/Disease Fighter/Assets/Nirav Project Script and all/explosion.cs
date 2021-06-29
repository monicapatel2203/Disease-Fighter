using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) 
		{

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
		
			if(Physics.Raycast(ray, out hit,100))
			{
				Collider[] colliders = Physics.OverlapSphere(hit.point, 10000);

				foreach (Collider c in colliders) {
					
					if (c.attachedRigidbody!= null)
						c.attachedRigidbody.AddExplosionForce (10, hit.collider.gameObject.transform.position,10000.0f, 0, ForceMode.Impulse);

				}
				Debug.Log ("YOu have FOUnd"+hit.collider.gameObject.name);
//				rigidbody.

			}
		}
	
	}


}
