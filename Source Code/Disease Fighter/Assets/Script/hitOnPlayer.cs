using UnityEngine;
using System.Collections;

public class hitOnPlayer : MonoBehaviour {


	public Texture bloodpattent1;
	public LevelManager levelManager;
	float bloodTimer=1.0f;
	public bool playerhit = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	// void Update () {




	
	// }


	void OnGUI()
	{
		if (playerhit) 
		{
			// Debug.Log ("found..."+ Screen.width + "  Height..." + Screen.height);
			GUI.color= new Color(1,1,1,bloodTimer);
			bloodTimer -= Time.deltaTime*0.20f;
			//Debug.Log (bloodTimer+"out loop");
			GUI.DrawTexture ( new Rect(0, 0, Screen.width, Screen.height),bloodpattent1,ScaleMode.StretchToFill,true);
			if (bloodTimer < 0) 
			{
				//Debug.Log (bloodTimer+"In looop");
				bloodTimer = 0.5F;
				playerhit = false;

			}

		}

	}

/*
	void OnTriggerEnter(Collider coli)
		{
			if (coli.gameObject.tag =="Enemy")// "Player") 
				{
//					playerhit = true;
					StartCoroutine ("camerahit");
//			Camera.main.GetComponent<CameraShake>().en
					Debug.Log ("ENEMEY HIT THE PLAYER");
					
					coli.GetComponent<PlayerMovment> ().playerLife -= 10;
					Debug.Log (coli.gameObject.name + "found player name");
					if (coli.GetComponent<PlayerMovment> ().playerLife <= 0) 
						{
							//StartCoroutine ("Playerdead");
								//Debug.Log ("Game Over");
							//Destroy (coli.gameObject, 3.0f);

						}
					
				}
		}
 */

	public void hitOnPlayer1()
	{
        StartCoroutine ("camerahit");
       // playerhit = true;
    }
	IEnumerator camerahit()
	{
		playerhit = true;
		Camera.main.GetComponent<CameraShake> ().enabled = true;
		Controller _controllerScript = FindObjectOfType<Controller>();
		LevelManager _managerScript = FindObjectOfType<LevelManager>();
		// _managerScript.LevelController[_controllerScript.currentLevel].gun.GetComponent<GunShake>().enabled = true;			//Gun Shake script enabling
		yield return new WaitForSeconds (2.0f);
		Camera.main.GetComponent<CameraShake> ().enabled = false;
		// _managerScript.LevelController[_controllerScript.currentLevel].gun.GetComponent<GunShake>().enabled = false;
		Camera.main.transform.localPosition = new Vector3 (0, 0, 0);
		Camera.main.transform.localRotation= Quaternion.Euler(0,0,0);
	}
}