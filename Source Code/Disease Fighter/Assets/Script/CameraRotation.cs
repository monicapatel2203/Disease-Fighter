﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public GameObject gun, bulletPosition, bulletPrefeb, shotIcon;


    private int speedOfBullet = 2500;

    private bool moving = false;
    private Vector3 initialPosition, movePosition;
    private float angleInDegrees = 0;

    void Start()
    {
        loadInitialData();
    }

    public void loadInitialData()
    {
        //initially gunman will have angel 0
        gun.transform.eulerAngles = new Vector3(0, 0, 0);
        shotIcon.GetComponent<Renderer>().enabled = false;

    }

    void Update()
    {
        checkForTouchActions();
    }


    private void checkForTouchActions()
    {
        if (Input.GetMouseButtonDown(0))
        {

            moving = true;

            //if touched shoot icon will be appear

            shotIcon.GetComponent<Renderer>().enabled = true;

            //calculation for angles

            initialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            double angle2 = Mathf.Atan2(initialPosition.y - gun.transform.position.y,
            initialPosition.x - gun.transform.position.x);

            angleInDegrees = (float)(angle2);
            angleInDegrees = Mathf.Rad2Deg * angleInDegrees;

            gun.transform.eulerAngles = new Vector3(0, 0, angleInDegrees);

        }
        // if touch is moving on screen
        if (moving)
        {

            movePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shotIcon.transform.position = new Vector3(movePosition.x, movePosition.y, 12);
            double angle1 = Mathf.Atan2(gun.transform.position.y - initialPosition.y,
            gun.transform.position.x - initialPosition.x);
            double angle2 = Mathf.Atan2(gun.transform.position.y - movePosition.y,
            gun.transform.position.x - movePosition.x);

            angleInDegrees = (float)(angle2 - angle1);
            angleInDegrees = Mathf.Rad2Deg * angleInDegrees;

            // setting angles according to move

            gun.transform.eulerAngles += new Vector3(0, 0, angleInDegrees);

            initialPosition = movePosition;


        }
        //on touch up bullet will be fired
        if (Input.GetMouseButtonUp(0))
        {

            shotIcon.GetComponent<Renderer>().enabled = false;

            if (moving == true)
                fireBullet(bulletPosition.transform.position);

            moving = false;
        }
    }

    //method for firing bullet

    private void fireBullet(Vector3 pos)
    {

        GameObject currentBullet = (GameObject)Instantiate(bulletPrefeb, pos, Quaternion.identity);
        Vector3 angle = gun.transform.eulerAngles;
        currentBullet.transform.eulerAngles = angle;

        Vector3 forceVector = currentBullet.transform.right;

        currentBullet.GetComponent<Rigidbody>().AddForce(forceVector * speedOfBullet * 1.5f, ForceMode.Impulse);
    }
}
