

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//new adde...23.7.2019...9.08am
using UnityEngine.SceneManagement;



public class GetJoyStickMovement : MonoBehaviour
{

    public float _speed = 10.0f;
    public float _rotationSpeed = 10.0f;//100.0f;   
    float _flt_LeftRightRotationRangeY;

    public GameObject _mashineGun;

    float _flt_leftRightBoundry;
    bool _bool_InLeftRightBoundry, _bool_RightBoundry;

    float _flt_lastYrotation;
    GameObject _gmObj_BoundryXY;
    bool _bool_leftright;
          

    void Start()
    {
        _gmObj_BoundryXY = this.gameObject;
        _bool_leftright = false;

        _bool_InLeftRightBoundry = true;
        _bool_RightBoundry = false;


        _flt_LeftRightRotationRangeY = this.gameObject.transform.localRotation.eulerAngles.y;

    }

    void Update()
    {
                       
        // float _direction_x_Rotation = Input.GetAxis("joystick_X");

        float _direction_x = Input.GetAxis("Horizontal") * _speed * 15; //*_speed*20;
        float _direction_y = Input.GetAxis("Vertical") * _rotationSpeed / 4f;                   
        Debug.Log("Horizontal value .... " + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical value .... " + Input.GetAxis("Vertical"));
        
        _direction_x *= Time.deltaTime * 1 / 3f;  
        _direction_y *= Time.deltaTime * 1 / 3f;
                          
        if (_bool_InLeftRightBoundry == true)
        {
             {
                
                _flt_lastYrotation = this.gameObject.transform.localRotation.eulerAngles.y;
                _gmObj_BoundryXY.transform.localRotation = this._gmObj_BoundryXY.transform.localRotation * Quaternion.Euler(0, _direction_x, 0);  


                if (((_flt_LeftRightRotationRangeY ) < _gmObj_BoundryXY.transform.localRotation.eulerAngles.y) && (_gmObj_BoundryXY.transform.localRotation.eulerAngles.y < (_flt_LeftRightRotationRangeY + 100)))
                {
                    this.gameObject.transform.localRotation = this.gameObject.transform.localRotation * Quaternion.Euler(_direction_y, _direction_x, 0);
                }
                else
                {
                    _gmObj_BoundryXY.transform.localRotation = Quaternion.Euler(0, _flt_lastYrotation, 0); ;
                }

            }
        }
                              
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))                      
        {
            //transform.Translate(Vector3.right *_direction_x * 0.1f );  
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))                      
        {
            //  transform.Translate(Vector3.forward * _direction_y * 0.1f ); 
        }

    }
}