using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyhitPlayer : MonoBehaviour
{
    public GameObject pmGameobject;
    public Controller _controller;
    int life_CountNo;   
    int playerplaychance; 
    bool chanceplay;
    public bool Playerlife_bool;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("gamechance", PlayerPrefs.GetInt("gamechance") + 1);
        // Debug.Log("fillbar..." + PlayerPrefs.GetInt("fillBar"));
        // if( PlayerPrefs.GetFloat("fillBar") == 1 )
        // {
        //     // pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount = PlayerPrefs.GetFloat("PlayerFillBar_2");
        //     _controller.LifeCount.text = PlayerPrefs.GetInt("life_CountNo").ToString();
        //     Debug.Log("life_CountNo...start..." + life_CountNo);
        // }        
        life_CountNo = 3;
        playerplaychance = 0;
        chanceplay = false;
    }

    //Update is called once per frame
    // void Update()
    // {
    // //     //if (Input.GetButtonDown("Fire1"))
    // //     //{
    // //     //    Debug.Log("Fire 1");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire2"))
    // //     //{
    // //     //    Debug.Log("Fire 2");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire3"))
    // //     //{
    // //     //    Debug.Log("Fire 3");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire4"))
    // //     //{
    // //     //    Debug.Log("Fire 4");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire5"))
    // //     //{
    // //     //    Debug.Log("Fire 5");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire6"))
    // //     //{
    // //     //    Debug.Log("Fire 6");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire7"))
    // //     //{
    // //     //    Debug.Log("Fire 7");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire8"))
    // //     //{
    // //     //    Debug.Log("Fire 8");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire9"))
    // //     //{
    // //     //    Debug.Log("Fire 9");
    // //     //}
    // //     //if (Input.GetButtonDown("Fire10"))
    // //     //{
    // //     //    Debug.Log("Fire 10");
    // //     //}

    //     if(chanceplay)
    //     {
    //         playerplaychance = playerplaychance + 1;
    //         Debug.LogError("player count chance  ====  "+playerplaychance);
                
    //         if(playerplaychance == 3)
    //         {
    //             Debug.LogError("player count chance is completed  ====  "+playerplaychance);
    //             pmGameobject.GetComponent<PlayerMovment>().isPlayerDie = true;
    //             chanceplay = false;
    //         }
    //         else
    //         {
    //             pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount = 1f;
    //             Debug.LogError("player count chance is not completed  ====  "+playerplaychance);
    //             chanceplay = false;
    //         }
            
    //     }
    // }

    
    void OnTriggerStay(Collider collision)
    {
        PlayerMovment _playermovement = FindObjectOfType<PlayerMovment>();
        LevelManager _levelmanage = FindObjectOfType<LevelManager>();
        if (collision.gameObject.tag == "Enemy")
        {
            if( Playerlife_bool == true )
            {            
                // if (pmGameobject.GetComponent<PlayerMovment>().playerHealth == 0)
                if (pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount <= 0.04f)
                {
                    chanceplay = true;
                    _playermovement.playerHealth = _levelmanage.LevelController[_controller.currentLevel].PlayerLife;
                    _controller.currentLevelPlayerLife = _controller.Player.transform.GetComponent<PlayerMovment>().playerHealth;

                    // if( PlayerPrefs.GetInt("gamechance") <2 )               //0
                    // {
                    //     life_CountNo = life_CountNo - 1;
                    //     _controller.LifeCount.text = life_CountNo.ToString();
                    //     PlayerPrefs.SetInt("life_CountNo",life_CountNo);
                    //     Debug.Log("life_CountNo..." + life_CountNo);

                    //     // _controller.Countdown_img.sprite = _controller.Countdown_sprite[life_CountNo];

                    //     // pmGameobject.GetComponent<PlayerMovment>().isPlayerDie = false;
                    //     pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount = 1;
                    //     // PlayerPrefs.SetInt("gamechance", PlayerPrefs.GetInt("gamechance") + 1);
                    //     // _playermovement.playerHealth = _levelmanage.LevelController[_controller.currentLevel].PlayerLife;
                    //     // _controller.currentLevelPlayerLife = _controller.Player.transform.GetComponent<PlayerMovment>().playerHealth;                   
                    // }
                    // else
                    // {
                        _controller.LifeCount.enabled = false;
                        pmGameobject.GetComponent<PlayerMovment>().isPlayerDie = true;
                    // }
                    // PlayerPrefs.SetInt("gamechance", PlayerPrefs.GetInt("gamechance") + 1);
                }
                pmGameobject.GetComponent<PlayerMovment>().playerHealth -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime;
                pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime / _controller.currentLevelPlayerLife;
                // Debug.Log("Player Health...." + pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount);
                PlayerPrefs.SetFloat("PlayerFillBar_2",pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount);
                PlayerPrefs.SetFloat("fillBar",1);
                // Debug.Log("fillbar...incremented" + PlayerPrefs.GetInt("fillBar"));
            }
            gameObject.GetComponent<hitOnPlayer>().hitOnPlayer1();
            // Debug.LogError(gameObject.GetComponent<PlayerMovment>().playerHealth+ "   _OnTriggerStay..is call : "+collision.name);        
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if( Playerlife_bool == true )
            {            
                // if (pmGameobject.GetComponent<PlayerMovment>().playerHealth == 0)
                if (pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount <= 0.04f)
                {
                    pmGameobject.GetComponent<PlayerMovment>().isPlayerDie = true;
                    return;
                }
                pmGameobject.GetComponent<PlayerMovment>().playerHealth -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime;
                pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime / _controller.currentLevelPlayerLife;
                PlayerPrefs.SetFloat("PlayerFillBar_2",pmGameobject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount);
                PlayerPrefs.SetFloat("fillBar",1);
            }
            gameObject.GetComponent<hitOnPlayer>().hitOnPlayer1();
           // Debug.LogError(pmGameobject.GetComponent<PlayerMovment>().playerHealth + "   _OnTriggerEnter..is call : " + collision.name);
        }
    }
}
