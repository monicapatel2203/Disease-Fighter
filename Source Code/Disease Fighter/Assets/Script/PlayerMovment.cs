 using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour {
	private Vector3 movementVector,preVector;
	private CharacterController characterController;
	private float movementSpeed = 6;
	private float jumpPower = 15;
	private float gravity = 100;
	public int playerLife,enmeynum,playerStar ;
	public GameObject bullet ,bulletPos,playerHand,Enemy,Gate,enmeypos,mustcollect,gameComplete,findweapon;
	public bool gateOpen,playerwin;
	public Texture2D starIcon;
	public Text starScore;
	public GameObject[] enemypos2;

    public float playerHealth;
    public bool isPlayerDie;
    float timer;
    public Image PlayerLifeBarFill;
    public Controller _controller;
    // Use this for initialization
    	void Start ()
   	{
		characterController = GetComponent<CharacterController>();
		LevelManager _levelmanage = FindObjectOfType<LevelManager>();
		Controller _controllerScript = FindObjectOfType<Controller>();
		playerLife = 250;
		gateOpen = false;
		isPlayerDie = false;
		//Invoke ("Enmeygate", 10.0f);
		enmeynum = 5;
		playerwin = false;
		//gameComplete.gameObject.SetActive (false);
		//mustcollect.SetActive (false);
		// Cursor.visible = false;
		playerHealth = _levelmanage.LevelController[_controllerScript.currentLevel].PlayerLife;
	}
	
	// Update is called once per frame
	// void Update ()
	// {
		
	// }


//    void OnTriggerEnter(Collider other)
//     {	
//         if(other.gameObject.tag== "Enemy")
//         {	
//               if(other.gameObject.transform.GetComponent<Rigidbody>())
//                {
// 		if (gameObject.GetComponent<PlayerMovment>().playerHealth < 0.5)
// 		{
// 		isPlayerDie=true;
// 		return;
// 		}
               		
// 	   	Debug.Log("force add");
//           	//other.gameObject.transform.GetComponent<Rigidbody>().AddForce(-other.gameObject.transform.forward * 100f );  
// 		gameObject.GetComponent<PlayerMovment>().playerHealth -= other.gameObject.transform.GetComponent<EnemyMovement>().Damage_health *Time.deltaTime;
//           	Debug.Log(gameObject.GetComponent<PlayerMovment>().playerHealth+ "   _OnTriggerEntr..is call : "+other.name);
//                }
//           }   
//     }

      //void OnTriggerStay(Collider collision) 
      // {
    	 //   if (collision.gameObject.tag == "Enemy") 
    	 //   {
	     //       if (gameObject.GetComponent<PlayerMovment>().playerHealth < 0.5)
	     //       {
		    //        isPlayerDie=true;
		    //        return;
	     //       }               	
	     //           gameObject.GetComponent<PlayerMovment>().playerHealth -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime;
      //              gameObject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime / _controller.currentLevelPlayerLife; 
      //              gameObject.GetComponent<hitOnPlayer>().hitOnPlayer1();
      //  	       // Debug.LogError(gameObject.GetComponent<PlayerMovment>().playerHealth+ "   _OnTriggerStay..is call : "+collision.name);        
      // 	    }
      // }
   
      //void OnTriggerEnter(Collider collision) 
      // {
    	 //   if (collision.gameObject.tag == "Enemy") 
    	 //   {
	     //       if (gameObject.GetComponent<PlayerMovment>().playerHealth < 0.5)
	     //       {
		    //        isPlayerDie=true;
		    //        return;
	     //       }               	
	     //       gameObject.GetComponent<PlayerMovment>().playerHealth -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime;
      //          gameObject.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount -= collision.gameObject.transform.GetComponent<EnemyMovement>().Damage_health * Time.deltaTime / _controller.currentLevelPlayerLife;
      //          gameObject.GetComponent<hitOnPlayer>().hitOnPlayer1();
      //  	    Debug.LogError(gameObject.GetComponent<PlayerMovment>().playerHealth+ "   _OnTriggerEnter..is call : "+collision.name);        
      //  	}
      // }
}
