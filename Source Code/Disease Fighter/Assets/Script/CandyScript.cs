using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandyScript : MonoBehaviour
{
    GameObject findController;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        findController = GameObject.Find("Controller") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(this.transform.position, Vector3.up, 500 * Time.deltaTime);
        speed += Time.deltaTime / 5.0f;
        // findController.GetComponent<Controller>().EnemyObj.transform.localPosition = Vector3.Lerp(findController.GetComponent<Controller>().EnemyObj.transform.localPosition, findController.GetComponent<Controller>()._targetPosition.transform.position, speed);
        this.transform.localPosition = Vector3.Slerp(this.transform.localPosition, findController.GetComponent<Controller>()._targetPosition.transform.position, speed);
        // if( Vector3.Distance(findController.GetComponent<Controller>().EnemyObj.transform.localPosition,findController.GetComponent<Controller>()._targetPosition.transform.position) <= 1.0f )
        if( Vector3.Distance(this.transform.localPosition,findController.GetComponent<Controller>()._targetPosition.transform.position) <= 1.0f )                
        {
            // findController.GetComponent<Controller>()._Coinactive = false;
            // findController.GetComponent<Controller>().EnemyObj.SetActive(false);
            // Destroy(findController.GetComponent<Controller>().EnemyObj);
            findController.GetComponent<Controller>().CoinText.transform.localPosition = new Vector3(0,0,0);
            // findController.GetComponent<Controller>().CoinText.GetComponent<Text>().text = PlayerPrefs.GetInt("CandyCollect").ToString();
            int storevalue = int.Parse(findController.GetComponent<Controller>().CoinText.GetComponent<Text>().text);
            findController.GetComponent<Controller>().CoinValue = PlayerPrefs.GetInt("CandyCollect");
            findController.GetComponent<Controller>().CoinValue = storevalue + findController.GetComponent<Controller>().CoinValue;
            findController.GetComponent<Controller>().TargetTxt.text = findController.GetComponent<Controller>().CoinValue.ToString();
            PlayerPrefs.SetInt("CandyCollect",findController.GetComponent<Controller>().CoinValue);
            Destroy(this.gameObject);
        }
    }
}
