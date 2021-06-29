using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Introcut : MonoBehaviour {

	// Use this for initialization
	public GameObject introcutpanel,loadingpanel;
	public AudioClip[] LauraIntro;
	float timer,halfcliptimer;
	bool isOver;
	bool isLimit1Audio,isLimit2Audio,isLimit3Audio,isLimit4Audio,sceneComplete;
	int i;
	//public UITexture backcutOut;
	bool isSecondtexture = true;
	bool isThirdtexture = true;
	AsyncOperation async;
	bool isLoading = false;
	public  bool isFInaltrue=false;
	//public UISlider levelProgressBar;
	public bool gamestart;
	
//	float a = 0.0f;
	//bool isColorchange = true;
	//float FadeNum = 0;
	void Awake ()
	{

		gamestart = true;
		//	backmusic.SetActive(false);
	//backcutOut.GetComponent<UITexture>().material.color = new Color(0,0,0,255);
			SetMatirial();
			timer = 0.0f;
			isLimit1Audio = false;
			isLimit2Audio = false;
			isLimit3Audio = false;
			isLimit4Audio = false;
			halfcliptimer = 0.0f;
			sceneComplete = false;
			i = 0;
	}


		
		
	
	// Update is called once per frame
	void Update () 
	{
		

//		if(isFInaltrue)
//		{
//			Debug.Log ("1");
//			isFInaltrue = false;
//			StartCoroutine(Asyncload());
//		}

		if(gamestart)
		{
				i=6;
				SetMatirial();
				
		}
			if(!GetComponent<AudioSource>().isPlaying && !gamestart )
		{
			timer+= Time.deltaTime;
		}
		if(timer > 1.0f  && !isLimit1Audio )
		{
				i=0;
			SetMatirial();
			GetComponent<AudioSource>().clip = LauraIntro[0];
			GetComponent<AudioSource>().volume = 1;
			GetComponent<AudioSource>().Play();
			isLimit1Audio = true;
		}
		
		if(isLimit1Audio)
		{
			halfcliptimer+= Time.deltaTime;
			if(halfcliptimer > 7f && !isLimit2Audio && isSecondtexture)
			{
				i=1;
				SetMatirial();
				halfcliptimer = 0.0f;
				isSecondtexture = false;
			}
		}
		
		if( timer > 1.5f && !isLimit2Audio )
		{
			Debug.Log ("2");
					i=2;
					SetMatirial();
					GetComponent<AudioSource>().clip = LauraIntro[1];
					GetComponent<AudioSource>().volume = 1;
					GetComponent<AudioSource>().Play();
					isLimit2Audio = true;
		}
		
		if(isLimit2Audio)
		{
			halfcliptimer+= Time.deltaTime;
			if(halfcliptimer > 17f && !isLimit3Audio &&  isThirdtexture)
			{
				Debug.Log ("3");
				i=3;
				SetMatirial();
				halfcliptimer = 0;
				isThirdtexture = false;
				
			}
		}
		
		if( timer > 2f && !isLimit3Audio )
		{
			Debug.Log ("4");
					i=4;
					SetMatirial();
					GetComponent<AudioSource>().clip = LauraIntro[2];
					GetComponent<AudioSource>().volume = 1;
					GetComponent<AudioSource>().Play();
					isLimit3Audio = true;
		}
		if( timer > 2.5f && !isLimit4Audio )
		{
			Debug.Log ("5");
					i=5;
					SetMatirial();
					GetComponent<AudioSource>().clip = LauraIntro[3];
					GetComponent<AudioSource>().volume = 1;
					GetComponent<AudioSource>().Play();
					isLimit4Audio = true;
		}


		if (timer > 3.0f) 
		{
			isFInaltrue = true;
			sceneComplete = true;
		}

		if (sceneComplete) 
		{
			Application.LoadLevel ("ControllerTest");
			sceneComplete = false;
		}
		if (Input.GetButtonDown ("Fire2")) 
		{
			Application.LoadLevel ("ControllerTest");
		}
		
//		if(timer > 3.0f)
//		{
//			if(Menuscript.isStartclick)
//			{
//				Movements.isLevelclear = true;	
//			}
//				isFInaltrue = true;
//			
//			loadingpanel.SetActive(true);
//		//	introcutpanel.SetActive(false);
//		
//			//Application.LoadLevel("Menu");			
//		}
	
	}

	void SetMatirial()
	{
		
		//isColorchange = false;
		switch(i)
		{
		case 0:

			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS1");
			//backcutOut.material.mainTexture = Resources.Load("ICS1") as  Texture;
			ZoomInOut.a = 0.0f;
			break;
		case 1:
		//	Debug.Log("Second screen 1");
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS2");
			//backcutOut.material.mainTexture = Resources.Load("ICS2") as  Texture;
			ZoomInOut.a = 0.0f;
			break;
		case 2:
		//	Debug.Log("Second screen 2");
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS3");
			//backcutOut.material.mainTexture = Resources.Load("ICS3") as  Texture;
			ZoomInOut.a = 0.0f;
			break;
		case 3:
		//	Debug.Log("Second screen 3");
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS4");
			//backcutOut.material.mainTexture = Resources.Load("ICS4") as  Texture;
			ZoomInOut.a = 0.0f;
			
			break;
		case 4:
//			Debug.Log("Second screen 4");
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS5");
			//backcutOut.material.mainTexture = Resources.Load("ICS5") as  Texture;
			ZoomInOut.a = 0.0f;
			break;
		case 5:
		//	Debug.Log("Second screen 5");
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("ICS6");
			//backcutOut.material.mainTexture = Resources.Load ("ICS6") as  Texture;

			ZoomInOut.a = 0.0f;
			break;
		case 6:
			introcutpanel.transform.GetChild (0).GetComponent<RawImage> ().texture = (Texture2D)Resources.Load ("Splash-if");
			//backcutOut.material.mainTexture = Resources.Load ("ICS6") as  Texture;
			gamestart = false;
		ZoomInOut.a = 0.0f;
		break;
		


		}
		//backcutOut.transform.localScale = new Vector3(1080f ,780f,backcutOut.transform.localScale.z);

	//	backcutOut.transform.rotation = new Quaternion(0,0,0);
		
	}



}


