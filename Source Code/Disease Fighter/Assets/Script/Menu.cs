using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject Brain, Terrain, Controller,MenuCanvas,hitIcon,MenuHitIcon,Company_splashScreen,Game_splashScreen;
    public GameObject _QuitPopup, CoronaCanvas;
    public Camera fpsCam;
    public float delay;
    public List<GameObject> CoronaObj;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        EnemyhitPlayer _enemyScript = FindObjectOfType<EnemyhitPlayer>();
        if( PlayerPrefs.GetInt("playgame") == 1 )
        {
            _enemyScript.Playerlife_bool = true;
            Brain.SetActive(true);
            Terrain.SetActive(true);
            Controller.SetActive(true);
            Controller.GetComponent<Controller>().levelManager.LevelController[Controller.GetComponent<Controller>().currentLevel].gun.GetComponent<RayCasthit>().enabled = true;
            Controller.GetComponent<Controller>()._applicationPause = true;
            MenuCanvas.SetActive(false);
            hitIcon.SetActive(true);
            MenuHitIcon.SetActive(false);
            Company_splashScreen.SetActive(false);
            Game_splashScreen.SetActive(false);
            PlayerPrefs.SetInt("playgame",0);
        }
        else
        {
            Controller.GetComponent<Controller>()._applicationPause = false;
            Controller.SetActive(false);
            MenuCanvas.SetActive(false);

            // yield return new WaitForSeconds(delay);
            // Company_splashScreen.SetActive(true);

            // yield return new WaitForSeconds(delay);
            // Company_splashScreen.SetActive(false);
            // Game_splashScreen.SetActive(true);

            yield return new WaitForSeconds(delay);
            // Game_splashScreen.SetActive(false);
            MenuCanvas.SetActive(true);
            Controller.SetActive(true);
            Controller.GetComponent<Controller>().levelManager.LevelController[Controller.GetComponent<Controller>().currentLevel].gun.GetComponent<RayCasthit>().enabled = false;
            _enemyScript.Playerlife_bool = false;
        }        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKey("escape"))
    //     {
    //         PlayerPrefs.DeleteAll();
    //         Application.Quit();
    //     }

    //     // if ( Input.GetButtonDown("Fire10") || Input.GetMouseButtonDown(2) )
    //     // {
    //     //     // StartPlay();
    //     //     //Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
    //     //     RaycastHit hit;
    //     //    // Debug.Log("rayOrigin..." + rayOrigin);

    //     //     // if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
    //     //      if (Physics.Raycast (Camera.main.ScreenPointToRay (fpsCam.transform.position), out hit, Mathf.Infinity))
    //     //     {
    //     //         //if (hit.collider.gameObject.tag == "playbtn")
    //     //         //{
    //     //         //    Debug.Log("Play 1");
    //     //         //    StartPlay();
    //     //         //}

    //     //         // if (hit.collider.gameObject.tag == "highsorebtn")
    //     //         // {
    //     //         //     Debug.Log("highscorebtn 2");
    //     //         //     HighScorePanel.SetActive(true);
    //     //         // }
    //     //         // if (hit.collider.gameObject.tag == "exitM")
    //     //         // {
    //     //         //     Debug.Log("Exit App 3");
    //     //         //     StartPlay();
    //     //         // }
    //     //         // if (hit.collider.gameObject.tag == "exitHS")
    //     //         // {
    //     //         //     Debug.Log("Exit High score menu 3");
    //     //         //     HighScorePanel.SetActive(false);
    //     //         // }

    //     //     }
    //     // }
    // }

    public void StartPlay()
    {
        StartCoroutine(RandomPanel());
        // SceneManager.LoadScene("DiseaseFighter");
        // PlayerPrefs.SetInt("playgame",1);
    }

    IEnumerator RandomPanel()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        MenuCanvas.SetActive(false);
        // CoronaCanvas.SetActive(true);
        // int count = Random.Range(0, CoronaObj.Count);
        // CoronaObj[count].SetActive(true);
        yield return new WaitForSeconds(0f);        //5.0
        // CoronaObj[count].SetActive(false);
        // CoronaCanvas.SetActive(false);
        // MenuCanvas.SetActive(false);
        SceneManager.LoadScene("DiseaseFighter");
        PlayerPrefs.SetInt("playgame",1);
    }

    public void QuitPanel()
    {
        _QuitPopup.SetActive(true);
    }

    public void YesBtn()
    {
        Application.Quit();
    }

    public void NoBtn()
    {
        _QuitPopup.SetActive(false);
    }
}
