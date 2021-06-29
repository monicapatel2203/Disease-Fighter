using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnProjectilesScript : MonoBehaviour {

	public bool cameraShake;
	public Text effectName;
	public RotateToMouseScript rotateToMouse;
	public GameObject firePoint;
	public GameObject cameras,carbord;
	public List<GameObject> VFXs = new List<GameObject> ();

	private int count = 0;
	private float timeToFire = 0f;
	private GameObject effectToSpawn;
	private List<Camera> camerasList = new List<Camera> ();

	void Start () {
		
		

		
		effectToSpawn = VFXs[0];
		
	}

	void Update ()
    {
        //if (Input.GetKey (KeyCode.Space) && Time.time >= timeToFire || Input.GetMouseButton (0) && Time.time >= timeToFire)
        if (Input.GetButtonDown("Fire10"))
        {
			//timeToFire = Time.time + 1f / effectToSpawn.GetComponent<ProjectileMoveScript>().fireRate;
			SpawnVFX ();	
		}

		
	}

	public void SpawnVFX () {
		GameObject vfx;

		

		if (firePoint != null) {
			vfx = Instantiate (effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localScale = new Vector3(0.0002f, 0.0002f, 0.0002f);
            vfx.transform.SetParent(gameObject.transform);
           
            if (rotateToMouse != null){
                
               // vfx.transform.localRotation = carbord.transform.localRotation;// rotateToMouse.GetRotation ();
            } 
			else Debug.Log ("No RotateToMouseScript found on firePoint.");
		}
		else
			vfx = Instantiate (effectToSpawn);

		var ps = vfx.GetComponent<ParticleSystem> ();
       
        if (vfx.transform.childCount > 0) {
			ps = vfx.transform.GetChild (0).GetComponent<ParticleSystem> ();
		}
	}

	public void Next () {
		count++;

		if (count > VFXs.Count)
			count = 0;

		for(int i = 0; i < VFXs.Count; i++){
			if (count == i)	effectToSpawn = VFXs [i];
			if (effectName != null)	effectName.text = effectToSpawn.name;
		}
	}

	public void Previous () {
		count--;

		if (count < 0)
			count = VFXs.Count;

		for (int i = 0; i < VFXs.Count; i++) {
			if (count == i) effectToSpawn = VFXs [i];
			if (effectName != null)	effectName.text = effectToSpawn.name;
		}
	}

	
}
