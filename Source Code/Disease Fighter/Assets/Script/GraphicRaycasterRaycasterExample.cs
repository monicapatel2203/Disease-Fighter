﻿//Attach this script to your Canvas GameObject.
//Also attach a GraphicsRaycaster component to your canvas by clicking the Add Component button in the Inspector window.
//Also make sure you have an EventSystem in your hierarchy.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GraphicRaycasterRaycasterExample : MonoBehaviour
{
	GraphicRaycaster m_Raycaster;
	PointerEventData m_PointerEventData;
	EventSystem m_EventSystem;

    void Start()
	{
        //levelManager.LevelController[currentLevel].gun.GetComponent<RayCasthit>();
        Cursor.visible = true;
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
		//Fetch the Event System from the Scene
		m_EventSystem = GetComponent<EventSystem>();
      
	}

	void Update()
	{
        Cursor.visible = true;
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
        Menu _menuScript = FindObjectOfType<Menu>();
		//Check if the left Mouse button is clicked
		//if (Input.GetKey(KeyCode.Mouse0))
		if ( Input.GetButtonDown("Fire7") || Input.GetMouseButtonDown (0) )
		{
			bool HitOutside=false;
			//Set up the new Pointer Event
			m_PointerEventData = new PointerEventData(m_EventSystem);
			//Set the Pointer Event Position to that of the mouse position
			m_PointerEventData.position = Input.mousePosition;

			//Create a list of Raycast Results
			List<RaycastResult> results = new List<RaycastResult>();

			//Raycast using the Graphics Raycaster and mouse click position
			m_Raycaster.Raycast(m_PointerEventData, results);

			//For every result returned, output the name of the GameObject on the Canvas hit by the Ray
			foreach (RaycastResult result in results)
			{
                    // _menuScript.StartPlay();
					HitOutside = true;
            }
		}
        else if (Input.GetButtonDown("Fire9") || Input.GetMouseButtonDown(1))
        {
            bool HitOutside = false;
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                HitOutside = true;
            }
        }
    }
}
