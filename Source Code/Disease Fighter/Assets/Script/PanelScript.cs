using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    void OnEnable()
    {
        Controller _controllerScript = FindObjectOfType<Controller>();
        _controllerScript._applicationPause  = false;
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
