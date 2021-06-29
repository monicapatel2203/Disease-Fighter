using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour {

	private bool m_shake=false	; 
	private float m_shakeIntensity;    
	private Vector3 m_orgPos;
	private Quaternion m_orgRot;

	public float shakeIntensity;
	public float shakeDecay;
	void Start()
	{
		 
	}

	void OnEnable()
	{
		// shakeIntensity = 0.05f;
		// m_shakeIntensity = 0.05f;
		// m_shake = false;
		// shakeDecay = 1;
	}
	
	
	void Update () 
	{
		// if(m_shakeIntensity > 0)
		// {
		// 	transform.localPosition = m_orgPos + Random.insideUnitSphere * m_shakeIntensity;
		// 	transform.localRotation = Quaternion.Euler(m_orgRot.x + Random.Range(-m_shakeIntensity, m_shakeIntensity)*0.02f,m_orgRot.y + Random.Range(-m_shakeIntensity, m_shakeIntensity)*0.02f,
		// 		m_orgRot.z + Random.Range(-m_shakeIntensity, m_shakeIntensity)*0.02f);
			                                   

		// 	//m_orgRot.x + Random.Range(-m_shakeIntensity, m_shakeIntensity)*.2f,,
		// 	                                         //) )
			
		// 	m_shakeIntensity -= Time.deltaTime*shakeDecay;
		// }
		// else
		// {
		// 	if (m_shake)
		// 	{
		// 		transform.localPosition = m_orgPos;
		// 		transform.localRotation		 = m_orgRot;
		// 		m_shake = false;  
		// 	}
		// }
	}
	


	public void shake()
	{
		// if(m_shake==false)
		// {
		// 	m_orgPos = transform.localPosition;
		// 	m_orgRot = transform.localRotation	;
		// 	m_shakeIntensity = shakeIntensity;
		// 	m_shake = true;
		// }
	}    
	
	
}
