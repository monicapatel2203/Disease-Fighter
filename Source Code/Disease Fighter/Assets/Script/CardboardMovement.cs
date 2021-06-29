using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardMovement : MonoBehaviour
{
    public float rotY, rotX;   
    public float speed = 30.0f;    
    float translationX, rotation;
    public GameObject MenuCanvas;
    public ETCJoystick joystick_left, joystick_Right;

    // Start is called before the first frame update
    void Start()
    {
       
    }

   

    // Update is called once per frame
    void Update()
    {
        translationX = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * speed;
        // Debug.Log("Axis x..." + joystick_left.axisX.axisValue + "  Axis y..." + joystick_left.axisY.axisValue);

        if (Input.GetAxis("Horizontal") < 0 || Input.GetKeyDown(KeyCode.LeftArrow) || joystick_left.axisX.axisValue < 0 || joystick_Right.axisX.axisValue < 0 )
        {            
            if (MenuCanvas.activeInHierarchy)
            {
                Debug.Log("Menu Canvas");
                if (rotY > -30f)
                {
                    Debug.Log("Arrow Left");
                    rotY -= Time.deltaTime * speed;
                    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -30f, 30f), 0f);
                }
            }
            else
            {
                if (rotY > -50f)
                {
                    rotY -= Time.deltaTime * speed;
                    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
                }
            }
            //if (rotY > -50f)
            //{
            //    rotY -= Time.deltaTime * speed;
            //   // Debug.Log("Arrow Left");
            //    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
            //}
            
        }
        if (Input.GetAxis("Horizontal") > 0 || Input.GetKeyDown(KeyCode.RightArrow) || joystick_left.axisX.axisValue > 0 || joystick_Right.axisX.axisValue > 0 )
        {
            // Debug.Log("Arrow Right");
            if (MenuCanvas.activeInHierarchy)
            {
                if (rotY < 30f)
                {
                    rotY += Time.deltaTime * speed;
                    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -30f, 30f), 0f);
                }
            }
            else
            {
                if (rotY < 50f)
                {
                    rotY += Time.deltaTime * speed;                    
                    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
                }
            }
            //if (rotY < 50f)
            //{
            //    rotY += Time.deltaTime * speed;
            //    //Debug.Log("Arrow Right");
            //    gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
            //}
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetKeyDown(KeyCode.UpArrow) || joystick_left.axisY.axisValue > 0 || joystick_Right.axisY.axisValue > 0 )
        {
            // Debug.Log("Arrow UP");
            if (MenuCanvas.activeInHierarchy)
            {                
                if (rotX > -3.0f)       //3.0f
                {                    
                    rotX -= Time.deltaTime * speed / 2;                   
                    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 40f), rotY, 0f);
                }
            }
            else
            {
                if (rotX > -3.0f)       //-3.0f
                {
                    rotX -= Time.deltaTime * speed / 2;
                    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
                }
            }
            //if (rotX > -1.75f)
            //{
            //    rotX -= Time.deltaTime * speed / 2;
            //   // Debug.Log("Arrow UP");
            //    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);

            //}
        }
        if (Input.GetAxis("Vertical") < 0 || Input.GetKeyDown(KeyCode.DownArrow) || joystick_left.axisY.axisValue < 0 || joystick_Right.axisY.axisValue < 0)
        {
            // Debug.Log("Arrow Down");
            if (MenuCanvas.activeInHierarchy)
            {
                if (rotX < 40f)
                {
                    rotX += Time.deltaTime * speed / 2;                    
                    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 40f), rotY, 0f);
                }
            }
            else
            {
                if (rotX < 15f)
                {
                    rotX += Time.deltaTime * speed / 2;
                    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
                }
            }
            //if (rotX < 100f)
            //{
            //    rotX += Time.deltaTime * speed / 2;
            //   // Debug.Log("Arrow Down");
            //    gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
            //}
        }




        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("x"))
        //{
        //    if (rotY > -50f)
        //    {
        //        rotY -= Time.deltaTime * speed;
        //        Debug.Log("Arrow Left");
        //        gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -5f, 100f), 0f);
        //    }

        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("b"))
        //{
        //    if (rotY < 50f)
        //    {
        //        rotY += Time.deltaTime * speed;
        //        Debug.Log("Arrow Right");
        //        gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -5f, 100f), 0f);
        //    }

        //}
        //else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey("y"))
        //{
        //    if (rotX > -1.75f)
        //    {

        //        rotX -= Time.deltaTime * 10f;
        //        Debug.Log("Arrow UP");
        //        gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);

        //    }
        //}
        //else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("a"))
        //{
        //    if (rotX < 100f)
        //    {
        //        rotX += Time.deltaTime * 10f;
        //        Debug.Log("Arrow Down");
        //        gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
        //    }
        //}

    }
}
