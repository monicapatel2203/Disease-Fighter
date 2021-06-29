using UnityEngine;
using System.Collections;

public class ZoomInOut : MonoBehaviour {

	// Use this for initialization
	//public UITexture cuttexture;
//	float x,y,z;
	public bool ZoomIn,isRoteteplus,isRotateMinus;
	
		 public Color colorStart = Color.black;
  		 public Color colorEnd = Color.white;
		// public float duration = 1.0F;
	   	 public	static	float a = 0.0f;
	   	 Quaternion rotate;
	void Start () 
	{
		ZoomIn = true;
		isRoteteplus = true;
		isRotateMinus = false;
	    rotate = transform.localRotation;
//		x = cuttexture.transform.localScale.x;
//		y = cuttexture.transform.localScale.y;
//		z = cuttexture.transform.localScale.z;
		//cuttexture.GetComponent<UITexture>().color = new Color(0,0,0,255);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( a == 0f)
		{
			//cuttexture.transform.localScale = new  Vector3(1124f,780f,cuttexture.transform.localScale.z);
			//cuttexture.transform.rotation = rotate;
		//	transform.Rotate(0 , 0,0);
		//	cuttexture.transform.Rotate(0,0,0);
//			Debug.Log(cuttexture.rotation.z);
		//	transform.Rotate(0,0,0);
			
		}
		
		//cuttexture.GetComponent<UITexture>().color = new Color(a+=0.005f,a+=0.005f,a+=0.005f,255);
//		Debug.Log(cuttexture.transform.rotate);

		
		if(PlayerPrefs.GetInt("CurrentLevel")!= 13)
		{
			//if(cuttexture.transform.localScale.x <= 1400f && ZoomIn)
			//{
			//	cuttexture.transform.localScale = new Vector3(cuttexture.transform.localScale.x+0.15f,cuttexture.transform.localScale.y+0.15f,cuttexture.transform.localScale.z);
			//}
		}
		else
		{
			//if(cuttexture.transform.localScale.x <= 1400f && ZoomIn)
			//{
			//	cuttexture.transform.localScale = new Vector3(cuttexture.transform.localScale.x+0.1f,cuttexture.transform.localScale.y+0.1f,cuttexture.transform.localScale.z);
			//}
			
		}

		if(PlayerPrefs.GetInt("CurrentLevel")!= 13)
		{
			//if(cuttexture.transform.rotation.z <= 0.1f  && isRoteteplus)
			//{
			//	cuttexture.transform.Rotate(transform.rotation.x , transform.rotation.y,transform.rotation.z+0.005f);
			//	if(cuttexture.transform.rotation.z > 0.1f)
			//	{
			//		isRoteteplus = false;
			//	}
				
			//}
		}
		else
		{
			//if(cuttexture.transform.rotation.z <= 0.1f  && isRoteteplus)
			//{
			//	cuttexture.transform.Rotate(transform.rotation.x , transform.rotation.y,transform.rotation.z+0.002f);
			//	if(cuttexture.transform.rotation.z > 0.1f)
			//	{
			//		isRoteteplus = false;
			//	}
				
			//}
			
		}
//		
//		if(cuttexture.transform.rotation.z >= 0  && isRotateMinus)
//		{
//			cuttexture.transform.Rotate(transform.rotation.x , transform.rotation.y,transform.rotation.z-0.005f);
//			if(cuttexture.transform.rotation.z < 0)
//			{
//				isRotateMinus = false;
//			}
//			
//		}
		

	}
}
