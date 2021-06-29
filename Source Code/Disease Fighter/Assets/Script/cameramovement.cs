using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float rotY, rotX;   
    public float speed = 30.0f;    
    float translationX, rotation;
    public GameObject MenuCanvas;
    Vector3 oldPosition = Vector3.zero;
    Vector3 delta = Vector3.zero;

    public float minX = -360.0f;        //-360.0f
    public float maxX = 360.0f;
    
    public float minY = -50.0f;         //-45.0f
    public float maxY = 50.0f;
    
    public float sensX = 30.0f;        //100
    public float sensY = 30.0f;
    
    float rotationY = 0.0f;
    float rotationX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // oldPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if( Input.GetAxis ("Mouse X") > 0 )
        {
            if( rotationX < 15 )
            {
                Debug.Log("rotationX...left..." + rotationX);
                rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
                transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
            }
        }
        else if( Input.GetAxis ("Mouse X") < 0 )
        {
            if( rotationX > -45  )
            {
                Debug.Log("rotationX...right..." + rotationX);
                rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
                transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
            }
        }
        else if( Input.GetAxis ("Mouse Y") > 0 && Input.GetAxis ("Mouse Y") < 0.5f )
        {
            if( rotationY < 1.0f )
            {
                rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
                // rotationY = Mathf.Clamp (rotationY, minY, maxY);
                transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
                // Debug.Log("rotationY...up..." + rotationY + "   mouse up..." + Input.GetAxis ("Mouse Y"));
            }            
        }
        else if( Input.GetAxis ("Mouse Y") < 0 )
        {
            if( rotationY > -5.0f )
            {
                rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
                // rotationY = Mathf.Clamp (rotationY, minY, maxY);
                transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
                // Debug.Log("rotationY...down..." + rotationY + "  mouse down..." + Input.GetAxis ("Mouse Y"));
            }            
        }
        
        
        // transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

        // translationX = Input.GetAxis("Vertical") * speed;
        // rotation = Input.GetAxis("Horizontal") * speed;

        // delta = Input.mousePosition - oldPosition;
        // oldPosition = Input.mousePosition;

        // if ( (Input.GetAxis("Horizontal") < 0) || (delta.x < 0) || Input.GetKeyDown(KeyCode.LeftArrow) )
        // {
        //     Debug.Log("Arrow Left");
        //     if (MenuCanvas.activeInHierarchy)
        //     {
        //         Debug.Log("Menu Canvas");
        //         if (rotY > -30f)
        //         {
        //             rotY -= Time.deltaTime * speed;
        //             gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -30f, 30f), 0f);
        //         }
        //     }
        //     else
        //     {
        //         if (rotY > -50f)
        //         {
        //             rotY -= Time.deltaTime * speed;                    
        //             gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
        //         }
        //     }            
        // }
        // else if ( (Input.GetAxis("Horizontal") > 0) || (delta.x >0) || Input.GetKeyDown(KeyCode.RightArrow) )
        // {
        //     Debug.Log("Arrow Right");
        //     if (MenuCanvas.activeInHierarchy)
        //     {
        //         if (rotY < 30f)
        //         {
        //             rotY += Time.deltaTime * speed;
        //             gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -30f, 30f), 0f);
        //         }
        //     }
        //     else
        //     {
        //         if (rotY < 50f)
        //         {
        //             rotY += Time.deltaTime * speed;                    
        //             gameObject.transform.localRotation = Quaternion.Euler(rotX, Mathf.Clamp(rotY, -50f, 50f), 0f);
        //         }
        //     }
        // }
        // else if ( (Input.GetAxis("Vertical") > 0) || (delta.y > 0) || Input.GetKeyDown(KeyCode.UpArrow) )
        // {
            
        //     if (MenuCanvas.activeInHierarchy)
        //     {                
        //         if (rotX > -3.0f)
        //         {                    
        //             rotX -= Time.deltaTime * speed / 2;                   
        //             gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 40f), rotY, 0f);
        //         }
        //     }
        //     else
        //     {
        //         if (rotX > -3.0f)
        //         {
        //             Debug.Log("Arrow UP..." + delta.y);
        //             rotX -= Time.deltaTime * speed / 2;
        //             gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
        //         }
        //     }
        // }
        // else if ( (Input.GetAxis("Vertical") < 0) || (delta.y < 0) || Input.GetKeyDown(KeyCode.DownArrow) )
        // {
        //     Debug.Log("Arrow Down..." + delta.y);
        //     if (MenuCanvas.activeInHierarchy)
        //     {
        //         if (rotX < 40f)
        //         {
        //             rotX += Time.deltaTime * speed / 2;                    
        //             gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 40f), rotY, 0f);
        //         }
        //     }
        //     else
        //     {
        //         if (rotX < 15f)
        //         {
        //             rotX += Time.deltaTime * speed / 2;
        //             gameObject.transform.localRotation = Quaternion.Euler(Mathf.Clamp(rotX, -1.75f, 100f), rotY, 0f);
        //         }
        //     }
        // }

        // Debug.Log("rot X = " + rotX + "  =  rotY = " + rotY + " delta = " + delta);
        
    }
}
