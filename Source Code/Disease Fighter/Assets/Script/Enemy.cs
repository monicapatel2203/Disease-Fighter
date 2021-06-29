using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	NavMeshAgent pathfinder;
	Transform target;
	public int enemyheath ,enemywalk;
	public bool isdieanimationPlay;
	//public GameObject soundpre;
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0.0f;
		enemywalk = Random.Range (0, 3);
		Debug.Log ("value for random"+enemywalk);
		transform.gameObject.name = "enmey" + enemywalk;
		isdieanimationPlay = false;
		pathfinder = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		enemyheath = 3;
		StartCoroutine ("UpdatePath");
		//GetComponent<NavMeshAgent> ().enabled = false;
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator UpdatePath()
	{
		float refreshrate = 0.25f;

		while (target != null)
		{
			
			Vector3 targetPosition = new Vector3 (target.position.x,0,target.position.z);
			transform.GetComponent<NavMeshAgent> ().SetDestination (targetPosition);
			yield return new WaitForSeconds (refreshrate);


			if (Vector3.Distance (target.transform.position, gameObject.transform.position) >50  && Vector3.Distance (target.transform.position, gameObject.transform.position) <100 && !isdieanimationPlay) 
			{
				int idleanimation = Random.Range (0, 2);

				switch (idleanimation) 
				{

					case 0:
					transform.Find("zombie_low").GetComponent<Animation> ().Play ("Idle1");
				//	transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("idle");
						GetComponent<NavMeshAgent> ().enabled = true;
						break;
					case 1:
					transform.Find("zombie_low").GetComponent<Animation> ().Play ("Idle4");
				//	transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("idlebreak");
						GetComponent<NavMeshAgent> ().enabled = true;
						break;
					case 2:
//					transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("idlefloor");
					transform.Find("zombie_low").GetComponent<Animation> ().Play ("idlefloor");
						GetComponent<NavMeshAgent> ().enabled = true;
						break;
					
				}
			}
			else if (Vector3.Distance (target.transform.position, gameObject.transform.position) <3 && !isdieanimationPlay ) 
			{
				timer +=0.1f;
				GetComponent<NavMeshAgent> ().Stop ();
				if (timer > 1) 
				{

					Invoke ("playerhit",1.0f);
					
					int i = Random.Range (0, 2);
					switch (i) 
					{
						case 0:
						transform.Find("zombie_low").GetComponent<Animation> ().Play ("Attack1");
						//transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("attack2");
						timer = 0.0f;
						break;
						case 1: 
						transform.Find("zombie_low").GetComponent<Animation> ().Play ("attack4");
						//transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("attack1");
							timer = 0.0f;
							break;

					}
				}

			} 
			else  if(Vector3.Distance (target.transform.position, gameObject.transform.position) >3 && Vector3.Distance (target.transform.position, gameObject.transform.position) <50 && !isdieanimationPlay && !Camera.main.transform.GetChild(2).GetComponent<RayCasthit>().enmeyhit)
			{


//				GameObject soundpref = Instantiate (Resources.Load("sound")) as GameObject;
//				soundpref.GetComponent<AudioSource> ().clip = Resources.Load ("sfx_zombiestep03") as AudioClip;
//				soundpref.GetComponent<AudioSource>(). Play();
					
				GetComponent<NavMeshAgent> ().Resume ();
					switch (enemywalk) 
					{
					case 0: 
					transform.Find("zombie_low").GetComponent<Animation> ().Play ("lunatic walk");
					transform.Find("zombie_low").GetComponent<Animation> () ["lunatic walk"].speed = 0.65f;
						GetComponent<NavMeshAgent> ().speed = 0.5f;
//						transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("walk2");
//						transform.FindChild("zombie_strong").GetComponent<Animation> () ["walk2"].speed = 0.65f;

						break;
					case 1:
					transform.Find("zombie_low").GetComponent<Animation> ().Play ("lunatic walk");
					transform.Find("zombie_low").GetComponent<Animation> () ["lunatic walk"].speed = 0.65f;
						GetComponent<NavMeshAgent> ().speed = 0.5f;
//						transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("walk2");
//						transform.FindChild("zombie_strong").GetComponent<Animation> () ["walk2"].speed = 0.75f;
						
						break;
					case 2 :
						transform.Find("zombie_low").GetComponent<Animation> ().Play ("walk");
						transform.Find("zombie_low").GetComponent<Animation> () ["walk"].speed = 0.65f;
						GetComponent<NavMeshAgent> ().speed = 0.5f;
//					transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("walk1");
//					transform.FindChild("zombie_strong").GetComponent<Animation> () ["walk1"].speed = 0.45f;
						GetComponent<NavMeshAgent> ().speed = 0.4f;
						break;
					case 3 :
						transform.Find("zombie_low").GetComponent<Animation> ().Play ("walk");
						transform.Find("zombie_low").GetComponent<Animation> () ["walk"].speed = 0.65f;
//					transform.FindChild("zombie_strong").GetComponent<Animation> ().Play ("walk1");
//					transform.FindChild("zombie_strong").GetComponent<Animation> () ["walk1"].speed = 0.75f;
						GetComponent<NavMeshAgent> ().speed = 0.8f;
						break;
						

					}

			} else if( !isdieanimationPlay && !Camera.main.transform.GetChild(2).GetComponent<RayCasthit>().enmeyhit){
				transform.Find("zombie_strong").GetComponent<Animation> ().Play ("lunatic walk");
				transform.Find("zombie_strong").GetComponent<Animation> () ["lunatic walk"].speed = 0.65f;
				}

			}


		}

	void playerhit()
	{
		GameObject soundpref = Instantiate (Resources.Load("sound")) as GameObject;
		soundpref.GetComponent<AudioSource> ().clip = Resources.Load ("sfx_zombieattack01") as AudioClip;
		soundpref.GetComponent<AudioSource>(). Play();
	}




}
