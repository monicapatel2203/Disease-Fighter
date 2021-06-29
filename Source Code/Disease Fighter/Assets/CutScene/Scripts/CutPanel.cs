using UnityEngine;
using System.Collections;

public class CutPanel : MonoBehaviour 
{


	// Use this for initialization
	public GameObject loading,cutscreen;
	//public UITexture backcutOut;
	public AudioClip[] Commander;
	public AudioClip[] Laura;
	public AudioClip[] Radioguy;
	float timer,halflimit,halfcliptimer,shalflimit;
	public static bool isCutPlayed = false,isUpgrade = false;
	bool isOver,is2ndmatirial;
	bool isLimit1Audio = false;
	int i,NoOfCutscreens;
	float a = 0.0f;
	
	AsyncOperation async;
	bool isLoading = false;
	public static bool istrue=false;
	//public UISlider levelProgressBar;
	
	void Start ()
	{
			Time.timeScale = 1;
			i=1;
			SetMatirial();
			timer = 0.0f;
			isLimit1Audio = false;
			isCutPlayed = false;
			loading.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//	Debug.Log(PlayerPrefs.GetInt("GameScore"));
		//backcutOut.GetComponent<UITexture>().color = new Color(a+=0.001f,a+=0.001f,a+=0.001f,255);
//		Debug.Log(PlayerPrefs.GetInt("GameScore"));
		if(!GetComponent<AudioSource>().isPlaying)
		{
			timer+= Time.deltaTime;
		}
	
//		if(Movements.isGameCompleted == false)
//		{
			Textureinlevel();
		
			if(NoOfCutscreens == 1)
			{
					if( timer > 1.0f  && !isLimit1Audio)
					{
						SeAudio1();
						GetComponent<AudioSource>().volume = 1;
						GetComponent<AudioSource>().Play();
						isLimit1Audio = true;
					}
			}
			else if(NoOfCutscreens == 2)
			{
				if(timer > 1.0f  && !isLimit1Audio)
				{	SeAudio1();
					GetComponent<AudioSource>().volume = 1;
					GetComponent<AudioSource>().Play();
					isLimit1Audio = true;
					is2ndmatirial = true;
				}
		
				if(is2ndmatirial)
				{
					halfcliptimer+= Time.deltaTime;
				}
				SetHalftimeinterval();
				if(halfcliptimer > halflimit )
				{
					i=2;
					SetMatirial();
					halfcliptimer = 0.0f;
					is2ndmatirial = false;
				}
			}
			else if(NoOfCutscreens == 3)
			{
				if(timer > 1.0f  && !isLimit1Audio)
				{	SeAudio1();
					GetComponent<AudioSource>().volume = 1;
					GetComponent<AudioSource>().Play();
					isLimit1Audio = true;
					is2ndmatirial = true;
				}
		
				if(is2ndmatirial)
				{
					halfcliptimer+= Time.deltaTime;
				}
				SetHalftimeinterval();
				if(halfcliptimer > halflimit )
				{
					i=2;
					SetMatirial();
					//is2ndmatirial = false;
				}
				if(halfcliptimer > shalflimit)
				{
					i=3;
					SetMatirial();
					is2ndmatirial = false;
				}
			}
		
			if( timer > 2 )
			{	GetComponent<AudioSource>().Stop();
//				if(Menuscript.isLevel7Start)
//				{
//					//isCutPlayed = false;
//					Progressbar.isNotasyncload = true;
//					Pausepanel.isRestart = true;
//					Menuscript.isLevel7Start = false;
//				}
//				else
//				{
//					Progressbar.isNotasyncload = true;
					isCutPlayed = true;
//					Pausepanel.isRestart = false;
					isUpgrade = true;
//				}
					//Application.LoadLevel("final");
				loading.SetActive(true);
				cutscreen.SetActive(false);
			}
				
		//}
//	 	else if( Movements.isGameCompleted == true)
//		{
//			if(!isLimit1Audio)
//			{
//						GetComponent<AudioSource>().clip = Laura[19];
//						GetComponent<AudioSource>().volume = 1;
//						GetComponent<AudioSource>().Play();
//						isLimit1Audio = true;
//						isOver = true;
//				
//			}
//				
//			if(!GetComponent<AudioSource>().isPlaying && isOver)
//			{
//				//Application.LoadLevel("final");
//				Pausepanel.isRestart = false;
//				isUpgrade = false;
//				Menuscript.isFInaltrue = false;
//				loading.SetActive(true);
//				cutscreen.SetActive(false);
//				CutPanel.isCutPlayed = false;
//				Progressbar.isNotasyncload = true;
//				//istrue = true;
//			}
//		}
		
		
		if(isLoading)
		{
//			if(!async.isDone)
//			{
//				//if(async.progress < 1)
//					    levelProgressBar.sliderValue = async.progress;
//			}
//			else
//			{
//				panel6.SetActive(false);
//				panel1.SetActive(false);
//				panel2.SetActive(false);
//				panel3.SetActive(false);
//				panel5.SetActive(false);
//			}
		}
		
		if(istrue)
		{
			istrue = false;
			StartCoroutine(Asyncload());
		}
		
		
		
		
	}
	
	IEnumerator Asyncload()
	{
		isLoading = true;
        async = Application.LoadLevelAsync("final");
		yield return async;	
    }
	
	/// <summary>
	/// for setting audioes as per level  
	/// </summary>
	void SeAudio1()
	{
		int i;
//		if(PlayerPrefs.GetInt("CurrentLevel") < 7)
//		{
//			 i = PlayerPrefs.GetInt("CurrentLevel")-1 ;
//		}
//		else
//		{
//			 i = PlayerPrefs.GetInt("CurrentLevel") ;
//		}
		 i = PlayerPrefs.GetInt("CurrentLevel") ;
//		Debug.Log("valueofi=="+ i);
//		switch(i)
//		{
//			case 1:
//				audio.clip = Laura[10];
//				break;
//			case 2:
//				audio.clip = Laura[11];
//				break;
//			case 3:
//				audio.clip = Laura[12];
//				break;
//			case 4:
//				audio.clip = Laura[13];
//				break;
//			case 5:
//				audio.clip = Laura[14];
//				break;
////			case 6:
////				audio.clip = Laura[15];
////				break;
//			case 7:
//				if(Menuscript.isLevel7Start)
//					audio.clip = Radioguy[5];
//				else
//					audio.clip = Laura[15];
//				break;
//			case 8:
//				audio.clip = Commander[1];
//				break;
//			case 9:
//				audio.clip = Commander[0];
//				break;
//			case 10:
//				audio.clip = Laura[5];
//				break;
//			case 11:
//				audio.clip = Laura[16];
//				break;
//			case 12:
//				audio.clip = Laura[17];
//				break;
//			case 13:
//				audio.clip = Laura[18];
//				break;
//		}
//		
		
		
		switch(i)
		{
			case 2:
				GetComponent<AudioSource>().clip = Laura[10];
				break;
			case 3:
				GetComponent<AudioSource>().clip = Laura[11];
				break;
			case 4:
				GetComponent<AudioSource>().clip = Laura[12];
				break;
			case 5:
				GetComponent<AudioSource>().clip = Laura[13];
				break;
			case 6:
				GetComponent<AudioSource>().clip = Laura[14];
				break;
			case 7:
//				if(Menuscript.isLevel7Start)
//					audio.clip = Radioguy[5];
//				else
					GetComponent<AudioSource>().clip = Laura[15];
				break;
			case 8:
				GetComponent<AudioSource>().clip = Commander[1];
				break;
			case 9:
				GetComponent<AudioSource>().clip = Commander[0];
				break;
			case 10:
				GetComponent<AudioSource>().clip = Laura[5];
				break;
			case 11:
				GetComponent<AudioSource>().clip = Laura[16];
				break;
			case 12:
				GetComponent<AudioSource>().clip = Laura[17];
				break;
			case 13:
				GetComponent<AudioSource>().clip = Laura[18];
				break;
		}
	}

	
	/// <summary>
	/// for setting images as per current level the matirial.
	/// </summary>
	void SetMatirial()
	{
		//backcutOut.GetComponent<UITexture>().color = new Color(0,0,0,255);
		//a = 0.0f;
//		if(!Movements.isGameCompleted)
//		{
//			
////			if(Menuscript.isLevel7Start)
////			{
////				backcutOut.material.mainTexture = Resources.Load("NCS811") as  Texture;
////						ZoomInOut.a = 0.0f;
////			}
////			else
////			{
//				int clevel = PlayerPrefs.GetInt("CurrentLevel");
//					switch(i)
//					{
//						case 1:
//							backcutOut.material.mainTexture = Resources.Load("NCS"+clevel+i) as  Texture;
//							ZoomInOut.a = 0.0f;
//							break;
//						case 2:
//							backcutOut.material.mainTexture = Resources.Load("NCS"+clevel+i) as  Texture;
//							ZoomInOut.a = 0.0f;
//							break;
//						case 3:
//							backcutOut.material.mainTexture = Resources.Load("NCS"+clevel+i) as  Texture;
//							ZoomInOut.a = 0.0f;
//							break;
//					}
////			}
//			backcutOut.transform.localScale = new Vector3(1040f,800f,backcutOut.transform.localScale.z);
//		//	backcutOut.transform.rotation = new Quaternion(0,0,0);
//		}
		//else
		//	backcutOut.material.mainTexture = Resources.Load("NCS141") as  Texture;
	
	}
	
	
	/// <summary>
	/// set the no. of cutscreen texture & as per this we can set audio playing
	/// </summary>
	
	void Textureinlevel()
	{
		int clevel = PlayerPrefs.GetInt("CurrentLevel");
		switch(clevel)
		{
		case 5:
			NoOfCutscreens = 2;
			break;
		case 7:
//			if(Menuscript.isLevel7Start)
//				NoOfCutscreens = 1;
//			else
				NoOfCutscreens = 2;
			break;
		case 8:
				NoOfCutscreens = 2;
			break;
		case 9:
			NoOfCutscreens = 2;
			break;
		case 10:
			NoOfCutscreens = 3;
			break;
		case 11:
			NoOfCutscreens = 2;
			break;
		case 12:
			NoOfCutscreens = 2;
			break;
		case 13:
			NoOfCutscreens = 1;
			break;
		default:
			NoOfCutscreens = 1;
			break;
		}
	}
	
	/// <summary>
	/// Sets the halftimeinterval for changing cutscreen textures in single audio means there are two textures in one audio than we have to set
	/// it when we have to change 2nd texture.
	/// </summary>
	void SetHalftimeinterval()
	{
		int clevel = PlayerPrefs.GetInt("CurrentLevel");
		switch(clevel)
		{
				case 5:
					halflimit = 15.0f;
					break;
				case 7:
					halflimit = 12.5f;
					break;
				case 8:
					halflimit = 9.5f;
					break;
				case 9:
					halflimit = 9.5f;
					break;
				case 10:
					halflimit = 9f;
					shalflimit = 16f;
					break;
				case 11:
					halflimit = 4f;
					shalflimit = 17f;
					break;
				case 12:
					halflimit = 3f;
					break;
				case 13:
					halflimit = 8f;
					shalflimit = 18f;
					break;
			
		}
	}

}


