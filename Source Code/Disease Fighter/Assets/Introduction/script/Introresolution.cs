using UnityEngine;
using System.Collections;

public class Introresolution : MonoBehaviour 
{
	public GameObject panel1,loadingpanel;
	// Use this for initialization
	void Start () 
	{
		
     Vector3[] mousePosition = new Vector3[4];
		
		// for 1024X768 (ipad wide)
		mousePosition[0] = new Vector3(1.04f, 1.03f,1f);
		
		
	   	// for 960X640 (iphone4 wide)
	    mousePosition[1] = new Vector3(1.17f,1.03f,1f);
		
			// for 1136X640 (iphone5 wide)
		mousePosition[2] = new Vector3(1.3845f,1.03f,1f);
		
			// for 2048X1536 (ipad ratina wide)
		 mousePosition[3] = new Vector3(1.04f,1.03f,1f);
		
		
		
		
		if(Screen.width == 1024 && Screen.height == 768)
		{
			panel1.transform.localScale = mousePosition[0];
			loadingpanel.transform.localScale = mousePosition[0];
		}
		else if(Screen.width == 960 && Screen.height == 640)
		{
			panel1.transform.localScale = mousePosition[1];
			loadingpanel.transform.localScale = mousePosition[1];
		
		}
		else if(Screen.width == 1136 && Screen.height == 640)
		{
			panel1.transform.localScale = mousePosition[2];
			loadingpanel.transform.localScale = mousePosition[2];
		
		}
		else if(Screen.width == 2048 && Screen.height == 1536)
		{
			panel1.transform.localScale = mousePosition[3];
			loadingpanel.transform.localScale = mousePosition[3];
		
		}
		
		
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
