using UnityEngine;
using System.Collections;

public class CutSetreolution : MonoBehaviour {

	// Use this for initialization
	public GameObject CutPanel,loadingpanel;
	void Start () 
	{
		if(Screen.width == 1024 && Screen.height == 768)
		{
			CutPanel.transform.localScale = new Vector3(1f, 1f,1f);
			loadingpanel.transform.localScale = new Vector3(1f, 1f,1f);
		}
		else if(Screen.width == 960 && Screen.height == 640)
		{
			CutPanel.transform.localScale = new Vector3(0.9375f,0.8333f,1f);
			loadingpanel.transform.localScale = new Vector3(0.9375f,0.8333f,1f);
			
		}
		else if(Screen.width == 1136 && Screen.height == 640)
		{
			CutPanel.transform.localScale = new Vector3(1.1094f,0.8333f,1f);
			loadingpanel.transform.localScale = new Vector3(1.1094f,0.8333f,1f);
			
		}
		else if(Screen.width == 2048 && Screen.height == 1536)
		{
			CutPanel.transform.localScale = new Vector3(2f,2f,1f);
			loadingpanel.transform.localScale = new Vector3(2f,2f,1f);;
			
		}
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
