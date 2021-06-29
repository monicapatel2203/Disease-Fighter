using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{  
    GameObject InstEnemyObj;
    public int EnemyInstantiateCount = 0, EnemyInstantiateCount_2,EnemyName, EnemyKillCount;
    public int intScore=0,currentLevel=5,generateEnemyCount,enemyCount ;   
    public GameObject lvlDone,wall,Player,Terrain;
    public Text score;
    public LevelManager levelManager;    
    public List<GameObject> EnemyGeneratePos=new List<GameObject>();
    public List<GameObject> EnemyGeneratePos_New = new List<GameObject>();
   // public List<GameObject> BrainOBJ=new List<GameObject>();
   // public List<GameObject> BrainObjPos=new List<GameObject>();
    public GameObject brain;
    public Material mat1,mat2;
    public Text txtCurrentLevel;
    public Image ImgLevelFill, ImgPlayerLifeFill;
    public float currentLevelPlayerLife;
    public GameObject GameOverCanvas, EnemyGeneration, RestartPanel, CandyGeneration;
    public bool isLevelChange;
    public List<GameObject> bg_particle = new List<GameObject>();
    private int _Highestscore;
    public int _HScore=0;
    public Text txtHighestscore,TimerText;
    public float totalTime;        // = 120f; 2 minutes
    public int textScore,counter,counter_bullet,bullet_no, Count_bullet;
    public GameObject InstructionPanel,InstructionPanel_Bullet, MenuCanvas;
    public Text InstructionTxt,LevelTxt,Bullet_value;
    public Image Bullet_image;   
    public Text EnemyGenerateNo,LifeCount,Bullet_reloadNo_left, Bullet_reloadNo_right ,Reload_txt;
    public Button MusicBtn;
    public Sprite MusicOn, MusicOff;
    public List<Sprite> Countdown_sprite;
    public Image Countdown_img;
    public List<GameObject> DestroyEnemy;
    public Image Bullet_CountImg;
    public GameObject _targetPosition;
    public GameObject CoinText, CandyCollect_home;
    public bool _Coinactive;
    public Text TargetTxt;
    public int CoinValue, reloadNo;
    public List<GameObject> GunPosition;
    public List<GameObject> Gun;
    public List<GameObject> GunGenearated;
    public GameObject Gun_doubleShot,Gun_multipleShot;
    public Image GunFillbar,GunFillImage,GunImage;
    public Text _CoinCollected,_EnemyCollected,CollectGun_txt,_candyCollected_total;
    public bool GenerateGun, _applicationPause;
    public GameObject enemyObj_generate;
    public GameObject EnemyObj;
    public List<GameObject> TargetPos;
    public GameObject Joystick_left, fire_left, Reload_left, Joystick_right, fire_right, Reload_right, PausePanel;
    public bool multishot, doubleshot, BulletFire;
    
    // GameObject ostp;    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("     " + Application.platform);
        // Debug.Log("_applicationPause..." + _applicationPause);
        Cursor.lockState = CursorLockMode.Confined;
        multishot = false;
        doubleshot = false;
        Time.timeScale = 1;
        Count_bullet = 0;
        reloadNo = 20;
        BulletFire = true;
        Player.GetComponent<PlayerMovment>().enabled = true;

        // PlayerPrefs.DeleteAll();
        CoinValue = PlayerPrefs.GetInt("CandyCollect");
        TargetTxt.GetComponent<Text>().text = PlayerPrefs.GetInt("CandyCollect").ToString();
        CandyCollect_home.GetComponent<Text>().text = TargetTxt.GetComponent<Text>().text;

        if (!PlayerPrefs.HasKey ("CurrentLevel")) 
        {
            PlayerPrefs.SetInt ("CurrentLevel",0);
            PlayerPrefs.Save();
        }

        if( PlayerPrefs.GetInt("CurrentLevel") == 0 )
        {
            GenerateGun = true;
            CoinValue = 0;
            CoinText.SetActive(false);
            LifeCount.text = "3";

            currentLevel = PlayerPrefs.GetInt("CurrentLevel");

            if( PlayerPrefs.GetFloat("fillBar") == 0 )                              //When Game starts
            {
                ImgPlayerLifeFill.fillAmount = 1;
            }
            // else
            // {
            //     ImgPlayerLifeFill.fillAmount = PlayerPrefs.GetFloat("PlayerFillBar_2");
            // }
            
            if( currentLevel >=5 && currentLevel <= 50 )
            {
                totalTime = 120f;
            }
            else
            {
                totalTime = 90f;
            }
            // Debug.LogError("Player Prefs...." + PlayerPrefs.GetInt("CurrentLevel") + "    " + "currentLevel....." + currentLevel);

            Cursor.visible = true;
            for (int k=0;k<=Terrain.transform.childCount-1;k++)
            {
            EnemyGeneratePos.Add(Terrain.transform.GetChild(k).gameObject);
            }
            Player.transform.GetComponent<CardboardMovement>().rotX = 0;
            Player.transform.GetComponent<CardboardMovement>().rotY = 0;

            // Player.transform.GetComponent<cameramovement>().rotX = 0;
            // Player.transform.GetComponent<cameramovement>().rotY = 0;

            levelManager.LevelController[currentLevel].gun.SetActive(true);
            levelManager.LevelController[currentLevel].brainObstacle.SetActive(true);         
            generateEnemyCount=levelManager.LevelController[currentLevel].EnemyCount;
            enemyCount = levelManager.LevelController[currentLevel].levelEnemyList.Count; 
            currentLevelPlayerLife = Player.transform.GetComponent<PlayerMovment>().playerHealth;// levelManager.LevelController[0].PlayerLife;//currentLevel
            EnemyKillCount = levelManager.LevelController[currentLevel].EnemyKill;
        // Player.transform.GetComponent<PlayerMovment>().playerHealth= levelManager.LevelController[currentLevel].PlayerLife;
        // Player.transform.GetComponent<PlayerMovment>().PlayerLifeBarFill.fillAmount = levelManager.LevelController[currentLevel].PlayerLife;
            wall.transform.GetComponent<MeshRenderer>().material = levelManager.LevelController[currentLevel].BG_Material;
            Terrain.transform.GetComponent<Terrain>().terrainData.terrainLayers[0].diffuseTexture=levelManager.LevelController[currentLevel].BG_TerrainTexture;
            //InvokeRepeating("EnemyInstantiate", 0.1f, 10f);
            Invoke("EnemyInstantiate", 0.1f);
            isLevelChange = false;
        
            textScore= 1;
            txtCurrentLevel.text = "Level : " + textScore;
            bg_particle[currentLevel].SetActive(true);
            // Debug.Log("Gun Name..." + levelManager.LevelController[currentLevel].gun.name);

            if (PlayerPrefs.GetInt ("SoundOn") == 0)
            {
                levelManager.LevelController[currentLevel].gun.GetComponent<AudioSource>().enabled = true;
                Gun_doubleShot.GetComponent<AudioSource>().enabled = true;
                Gun_multipleShot.GetComponent<AudioSource>().enabled = true;
            }
            else
            {
                levelManager.LevelController[currentLevel].gun.GetComponent<AudioSource>().enabled = false;
                Gun_doubleShot.GetComponent<AudioSource>().enabled = false;
                Gun_multipleShot.GetComponent<AudioSource>().enabled = false;                
            }

            RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
            _raycastHit.anim.Play("ShotgunTake_In");

            // for( int i = 0; i <= GunPosition.Count - 1 ; i++ )
            // {
            //     int gunCount = Random.Range(0, Gun.Count);
            //     if( !GunGenearated.Contains(Gun[gunCount]) )
            //     {
            //         GameObject gun_generate = Instantiate(Gun[gunCount]) as GameObject;
            //         GunGenearated.Add(Gun[gunCount]);
            //         gun_generate.transform.position = GunPosition[i].transform.localPosition;
            //     }            
            //     // Destroy(Gun[gunCount]);
            //     // Gun.RemoveAt(gunCount);
            // }
            GunFillImage.enabled = false;
            GunFillbar.enabled = false;
            GunImage.enabled = false;

        }
        else
        {
            if( PlayerPrefs.GetInt("CurrentLevelNo") <= 50 )
            {
                textScore = PlayerPrefs.GetInt("CurrentLevel") + 1;
                // Debug.LogError("textScore...if..." + textScore);
            }
            else
            {
                textScore = PlayerPrefs.GetInt("LevelName") + 1;
                // Debug.LogError("textScore...else..." + textScore);
            }
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            GenerateGun = true;
            GunFillImage.enabled = false;
            GunFillbar.enabled = false;
            GunImage.enabled = false;
            ImgPlayerLifeFill.fillAmount = 1;

            intScore = 0;
            ImgLevelFill.fillAmount = 0;
            Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            EnemyInstantiateCount = 0;

            if( currentLevel <=  levelManager.LevelController.Count - 1)
            {             
                Cursor.visible = true;        
                for (int k=0;k<=Terrain.transform.childCount-1;k++)
                {
                    EnemyGeneratePos.Add(Terrain.transform.GetChild(k).gameObject);
                }
                Player.transform.GetComponent<CardboardMovement>().rotX = 0;
                Player.transform.GetComponent<CardboardMovement>().rotY = 0;

                levelManager.LevelController[currentLevel].gun.SetActive(true);
                levelManager.LevelController[currentLevel].brainObstacle.SetActive(true);         
                generateEnemyCount=levelManager.LevelController[currentLevel].EnemyCount;
                enemyCount = levelManager.LevelController[currentLevel].levelEnemyList.Count;
                currentLevelPlayerLife = Player.transform.GetComponent<PlayerMovment>().playerHealth;// levelManager.LevelController[0].PlayerLife;//currentLevel
                EnemyKillCount = levelManager.LevelController[currentLevel].EnemyKill;
                wall.transform.GetComponent<MeshRenderer>().material = levelManager.LevelController[currentLevel].BG_Material;
                Terrain.transform.GetComponent<Terrain>().terrainData.terrainLayers[0].diffuseTexture=levelManager.LevelController[currentLevel].BG_TerrainTexture;
                Invoke("EnemyInstantiate", 0.1f);
                isLevelChange = false;

                txtCurrentLevel.text = "Level : " + textScore;

                bg_particle[currentLevel].SetActive(true);
                TimerText.enabled = true;
                counter_bullet = 0;
                bullet_no = 0;
                counter = 0;
                RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
                _raycastHit.anim.Play("ShotgunTake_In");
                Count_bullet = 0;
                BulletFire = true;
                reloadNo = 20;
                Bullet_reloadNo_left.text = reloadNo.ToString();
                Bullet_reloadNo_right.text = reloadNo.ToString();
                
                if (PlayerPrefs.GetInt ("SoundOn") == 0)
                {
                    levelManager.LevelController[currentLevel].gun.gameObject.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
                    Gun_doubleShot.GetComponent<AudioSource>().enabled = true;
                    Gun_multipleShot.GetComponent<AudioSource>().enabled = true;
                }
                else
                {
                    levelManager.LevelController[currentLevel].gun.gameObject.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
                    Gun_doubleShot.GetComponent<AudioSource>().enabled = false;
                    Gun_multipleShot.GetComponent<AudioSource>().enabled = false;                
                }
            }

            if( currentLevel >=5 && currentLevel <= 50 )
            {
                totalTime = 120f;
            }
            else
            {
                totalTime = 90f;
            }
        }
        
        if( PlayerPrefs.GetInt("movedirection") == 1 )
        {
            Joystick_left.SetActive(false);
            fire_right.SetActive(false);
            Reload_right.SetActive(false);            
            Joystick_right.SetActive(true);
            fire_left.SetActive(true);
            Reload_left.SetActive(true);
        }
        else
        {
            Joystick_right.SetActive(false);
            fire_left.SetActive(false);
            Reload_left.SetActive(false);
            Joystick_left.SetActive(true);
            fire_right.SetActive(true);
            Reload_right.SetActive(true);
        }

        TimerText.enabled = true;

       
 
        // if( PlayerPrefs.GetInt("CurrentLevel") == 0 )
        // {
        //     currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        //     textScore = 1;
        //     txtCurrentLevel.text = "Level : " + textScore;
        // }
        

    }    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.DeleteAll();
            // Debug.LogError("Application Quit...");
            Application.Quit();
        }

        if( multishot )
        {
            StartCoroutine(Bullet_multishot(0.1f));
            multishot = false;
        }

        if( doubleshot )
        {
            StartCoroutine(Bullet_doubleshot(0.1f));
            doubleshot = false;
        }

        if( Count_bullet == 20 )
        {
            if( GameOverCanvas.activeInHierarchy || InstructionPanel.activeInHierarchy || RestartPanel.activeInHierarchy )
            {
                Reload_txt.enabled = false;
            }
            else
            {
                Reload_txt.enabled = true;
                Reload_txt.GetComponent<Animation>().Play("ReloadTxt_anim");
            }            
            // _controllScript._reloadanim.enabled = true;
        }

        if( Count_bullet >= 15.0f )
        {
            Bullet_CountImg.GetComponent<Animation>().enabled = true;
            Bullet_CountImg.GetComponent<Animation>().Play("ReloadTxt_anim");
        }

        if (_HScore > _Highestscore)
        {
            _Highestscore = _HScore;
            txtHighestscore.text = "" + _HScore;
            PlayerPrefs.SetInt("highscore", _Highestscore);
        }

        if (Input.GetButtonDown("Fire7") || Input.GetKeyDown("space") )
        {
            if (GameOverCanvas.activeInHierarchy)
            {
                HomeBtn();
                Player.transform.GetComponent<CardboardMovement>().rotX = 0;
                Player.transform.GetComponent<CardboardMovement>().rotY = 0;

                // Player.transform.GetComponent<cameramovement>().rotX = 0;
                // Player.transform.GetComponent<cameramovement>().rotY = 0;

            }
            if(InstructionPanel.activeInHierarchy)
            {                
                NextLevel();
                Player.transform.GetComponent<CardboardMovement>().rotX = 0;
                Player.transform.GetComponent<CardboardMovement>().rotY = 0;

                // Player.transform.GetComponent<cameramovement>().rotX = 0;
                // Player.transform.GetComponent<cameramovement>().rotY = 0;
            }
        }

        if( InstructionPanel.active )
        {
            RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
            // Exploder.Fragment _fragmentpool = FindObjectOfType<Exploder.Fragment>();
            // _fragmentpool.activeObj = false;
            BulletFire = false;
        }
        else
        {
            // RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
            // _raycastHit.BulletFire = true;
        }

        if(Input.GetButtonDown("Fire9") || Input.GetKeyDown(KeyCode.Backspace))
        {
            if(InstructionPanel.activeInHierarchy)
            {
                HomeBtn();
            }
        }

        
            if( InstructionPanel.activeInHierarchy || GameOverCanvas.activeInHierarchy || RestartPanel.activeInHierarchy)
            {
                Player.transform.GetComponent<CardboardMovement>().rotX = 0;
                Player.transform.GetComponent<CardboardMovement>().rotY = 0;
                Player.transform.GetComponent<CardboardMovement>().speed = 0;

                // Player.transform.GetComponent<cameramovement>().rotX = 0;
                // Player.transform.GetComponent<cameramovement>().rotY = 0;
                // Player.transform.GetComponent<cameramovement>().speed = 0;

                GunFillImage.enabled = false;
                GunFillbar.enabled = false;
                GunImage.enabled = false;
                
                Reload_txt.enabled = false;
        
                // GameObject[] fruits = GameObject.FindGameObjectsWithTag("Exploder");
                // foreach(GameObject fruit in fruits)
                // {
                //     Debug.Log("Fruits name..." + fruit.name);
                //     GameObject.Destroy(fruit);
                // }
            }
            else
            {
                Player.transform.GetComponent<CardboardMovement>().speed = 40;
                // Player.transform.GetComponent<cameramovement>().speed = 40;
            }


        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");

       if( GameOverCanvas.activeInHierarchy ||  InstructionPanel.activeInHierarchy || RestartPanel.activeInHierarchy )
       {

       }
       else
       {
           if( !MenuCanvas.active )                    /* to decrease time when menucanvas is in active in hirerachy */
           {
               totalTime -= Time.deltaTime;
           }           
       }        
       
       if( !MenuCanvas.active )                    /* to decrease time when menucanvas is in active in hirerachy */
       {
           if( totalTime >= 0f )
            {
                UpdateLevelTimer(totalTime );
            }
            else if( totalTime < 0f || ImgPlayerLifeFill.fillAmount <= 0.04f )
            {
                Player.transform.GetComponent<PlayerMovment>().isPlayerDie = true;
                TimerText.enabled = false;
                
                    // GameOverCanvas.SetActive(true);
                    RestartPanel.SetActive(true);
                    _candyCollected_total.text = TargetTxt.text;
                
                int EnemyChildcount = EnemyGeneration.transform.childCount;
                for( int i = 0; i <= EnemyChildcount - 1; i++ )
                {
                    EnemyGeneration.transform.GetChild(i).GetComponent<CapsuleCollider>().enabled = false;
                }
                // CancelInvoke("EnemyInstantiate");            
                // GameOverCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
                // Cursor.visible = true;
            }
       }        

        //brain.transform.GetChild(2).transform.GetComponent<MeshRenderer>().sharedMaterial.SetTextureOffset("_MainTex",new Vector2(0f,Time.time/10f));
        mat1.SetTextureOffset("_MainTex",new Vector2(0f,Time.time/10f));
        mat2.SetTextureOffset("_MainTex",new Vector2(0f,-Time.time/10f));
        if(Player.transform.GetComponent<PlayerMovment>().isPlayerDie)
        {
            TimerText.enabled = false;
            // if( PlayerPrefs.GetInt("gamechance") <= 3)
            // {
                RestartPanel.SetActive(true);
            // }
            // else
            // {
                // GameOverCanvas.SetActive(true);
            // }
            // PlayerPrefs.SetInt("gamechance", PlayerPrefs.GetInt("gamechance") + 1);
            CancelInvoke("EnemyInstantiate");
            GameOverCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            _candyCollected_total.text = TargetTxt.text;
            Cursor.visible = true;
        }
        else
        {
            // score.text = "" + intScore;
            // ImgLevelFill.fillAmount = (float)intScore / generateEnemyCount;
            // Debug.LogError("Level Fill...." + ImgLevelFill.fillAmount + "   " + "intScore..." + (float)intScore + "    " + "generateEnemyCount....." + generateEnemyCount);
            // if (intScore >= generateEnemyCount && totalTime >= 0f)
            // {
               
            //     isLevelChange = true;
            //     CancelInvoke("EnemyInstantiate");
            //     // lvlDone.SetActive(true);

            //     // if( PlayerPrefs.GetInt("CurrentLevel") == 7 )
            //     // {
            //     //     InstructionPanel_Bullet.SetActive(true);
            //     //     InstructionTxt.text = "Complete Level in" + 30;
            //     // }
            //     // else if(  PlayerPrefs.GetInt("CurrentLevel") == 8 )
            //     // {
            //     //     InstructionPanel_Bullet.SetActive(true);
            //     //     InstructionTxt.text = "Complete Level in" + 36;
            //     // }
            //     // else if(  PlayerPrefs.GetInt("CurrentLevel") == 9 )
            //     // {
            //     //     InstructionPanel_Bullet.SetActive(true);
            //     //     InstructionTxt.text = "Complete Level in" + 40;
            //     // }
            //     // else
            //     // {                    
                    
            //     // }
            //     // currentLevel +=1;
            //     // Destroy(EnemyGeneration);

            //     GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //     foreach (GameObject enemy in enemies)
            //     {
            //         GameObject.Destroy(enemy);
            //     }

            //     //intScore = 0;
            //     //EnemyInstantiateCount = 0;
            //     EnemyGeneratePos.Clear();
            //     EnemyGeneratePos_New.Clear();
            //     if (currentLevel <= levelManager.LevelController.Count - 1)
            //     {
            //         InstructionPanel.SetActive(true);
            //         LevelTxt.text = "Level " + textScore.ToString() + " Completed...!";
            //         TimerText.enabled = false;
            //         // PlayerPrefs.SetInt("CurrentLevel",PlayerPrefs.GetInt("CurrentLevel") + 1);
            //         // StartCoroutine("changeLevel");
            //         intScore = 0;
            //     }
            //     else
            //     {
            //         TimerText.enabled = false;
            //         GameOverCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            //         GameOverCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            //         GameOverCanvas.SetActive(true);
            //     }
            // }
        }

        // if( GameOverCanvas.activeInHierarchy ||  InstructionPanel.activeInHierarchy)
        // {

        // }
        // else
        // {
        //     if( EnemyGeneration.transform.childCount <=  enemyCount / 2)
        //     {
        //         Debug.Log("Enemygeneration...." + EnemyGeneration.transform.childCount);
        //         EnemyInstantiateCount = 0;
        //         EnemyInstantiate();
        //         // int i;
        //         // // if( i <= enemyCount/2 )
        //         // for( i = 0; i <= enemyCount/2; i++ )
        //         // {                    
        //         //     generateEnemy();
        //         //     //i++;
        //         // }
        //     }
        // }
        if( BulletScript.bulletcount_doubleShot == 3 )
        {
            levelManager.LevelController[currentLevel].gun.SetActive(false);
            Gun_doubleShot.SetActive(true);
            GunFillImage.enabled = true;
            GunFillbar.enabled = true;
            GunImage.enabled = true;
            GunFillbar.fillAmount = 1;
            Gun_multipleShot.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Gun_1"));
            BulletScript.bulletcount_doubleShot = 0;
            BulletFire = true;
        }

        if( BulletScript.bulletcount_multiShot == 3 )
        {
            levelManager.LevelController[currentLevel].gun.SetActive(false);
            Gun_multipleShot.SetActive(true);
            GunFillImage.enabled = true;
            GunFillbar.enabled = true;
            GunImage.enabled = true;
            GunFillbar.fillAmount = 1;
            Gun_doubleShot.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Gun_2"));
            BulletScript.bulletcount_multiShot = 0;
            BulletFire = true;
        }

        if( GunFillbar.IsActive() )
        {
            GunFillbar.fillAmount -= GunFillbar.fillAmount / 10.0f * Time.deltaTime;
            if( Gun_doubleShot.activeInHierarchy )
            {
                if( GunFillbar.fillAmount <= 0.08 )
                {
                    GunFillImage.enabled = false;
                    GunImage.enabled = false;
                    GunFillbar.enabled = false;
                    Gun_doubleShot.SetActive(false);
                    levelManager.LevelController[currentLevel].gun.SetActive(true);
                }
            }
            else if ( Gun_multipleShot.activeInHierarchy )
            {
                if( GunFillbar.fillAmount <= 0.08 )
                {
                    GunFillImage.enabled = false;
                    GunImage.enabled = false;
                    GunFillbar.enabled = false;
                    Gun_multipleShot.SetActive(false);
                    levelManager.LevelController[currentLevel].gun.SetActive(true);
                }
            }
        }

    }

        public void NextLevel()
        {
            // GenerateGun = true;
            // InstructionPanel.SetActive(false);
            // Gun_multipleShot.SetActive(false);
            // GunFillImage.enabled = false;
            // GunFillbar.enabled = false;
            // levelManager.LevelController[currentLevel].gun.SetActive(true);
            // Gun_doubleShot.SetActive(false);
            // RayCasthit _raycastHitScript = FindObjectOfType<RayCasthit>();
            // _raycastHitScript.Count_bullet = 0;
            // _raycastHitScript.BulletFire = true;
            // _raycastHitScript.reloadNo = 20;
            // Bullet_reloadNo_left.text = _raycastHitScript.reloadNo.ToString();
            // Bullet_reloadNo_right.text = _raycastHitScript.reloadNo.ToString();
            // if(currentLevel < 49)
            // {
            //     if(MusicBtn.image.sprite == MusicOff)
            //     {
            //         levelManager.LevelController[currentLevel + 1].gun.GetComponent<AudioSource>().enabled = false;
            //         levelManager.LevelController[currentLevel + 1].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;                
            //         Gun_doubleShot.GetComponent<AudioSource>().enabled = false;
            //         Gun_multipleShot.GetComponent<AudioSource>().enabled = false;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            //     }
            //     else
            //     {
            //         levelManager.LevelController[currentLevel + 1].gun.GetComponent<AudioSource>().enabled = true;
            //         levelManager.LevelController[currentLevel + 1].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.GetComponent<AudioSource>().enabled = true;
            //         Gun_multipleShot.GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            //     }
            // }
            // else
            // {
            //     if(MusicBtn.image.sprite == MusicOff)
            //     {
            //         levelManager.LevelController[currentLevel].gun.GetComponent<AudioSource>().enabled = false;
            //         levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;                
            //         Gun_doubleShot.GetComponent<AudioSource>().enabled = false;
            //         Gun_multipleShot.GetComponent<AudioSource>().enabled = false;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            //     }
            //     else
            //     {
            //         levelManager.LevelController[currentLevel].gun.GetComponent<AudioSource>().enabled = true;
            //         levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.GetComponent<AudioSource>().enabled = true;
            //         Gun_multipleShot.GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            //         Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            //     }
            // }

            // intScore = 0;
            // ImgLevelFill.fillAmount = 0;
            // Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            // EnemyInstantiateCount = 0;
            // lvlDone.SetActive(false);
            // levelManager.LevelController[currentLevel].gun.SetActive(false);
            // levelManager.LevelController[currentLevel].brainObstacle.SetActive(false);
            // bg_particle[currentLevel].SetActive(false);


            // if( PlayerPrefs.GetInt("CurrentLevel") < 49 )
            // {
            //     PlayerPrefs.SetInt("CurrentLevel",PlayerPrefs.GetInt("CurrentLevel") + 1);
            //     textScore = PlayerPrefs.GetInt("CurrentLevel") + 1;
            //     // currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            //     PlayerPrefs.SetInt("CurrentLevelNo",PlayerPrefs.GetInt("CurrentLevel"));
            //     // Debug.LogError("CurrentLevel...if..." + PlayerPrefs.GetInt("CurrentLevel"));
            // }
            // else
            // {
            //     if (!PlayerPrefs.HasKey ("LevelName")) 
            //     {
            //         PlayerPrefs.SetInt ("LevelName",50);        //50
            //         PlayerPrefs.Save();
            //     }
            //     else
            //     {
            //         PlayerPrefs.SetInt("LevelName", PlayerPrefs.GetInt("LevelName") + 1);
            //     }
            //     textScore = PlayerPrefs.GetInt("LevelName") + 1;
            //     int count = Random.Range(39,49);
            //     PlayerPrefs.SetInt("CurrentLevel", count);
            //     // currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            //     // PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("LevelName") + 1);
            //     PlayerPrefs.SetInt("CurrentLevelNo",PlayerPrefs.GetInt("LevelName") + 1);
            //     // Debug.LogError("CurrentLevel...else..." + PlayerPrefs.GetInt("CurrentLevel") + "  LevelName..." + PlayerPrefs.GetInt("LevelName") + 1);
            // }
            // PlayerPrefs.SetInt("playgame",1);
            // SceneManager.LoadScene("DiseaseFighter");
            StartCoroutine(NextLevelCoroutine());
        }

    IEnumerator NextLevelCoroutine()
    {
        InstructionPanel.SetActive(false);
        // Menu _menuscript = FindObjectOfType<Menu>();
        // _menuscript.CoronaCanvas.SetActive(true);
        // int count = Random.Range(0, _menuscript.CoronaObj.Count);
        // _menuscript.CoronaObj[count].SetActive(true);
        yield return new WaitForSeconds(0f);            //5.0
        // _menuscript.CoronaCanvas.SetActive(false);
        // _menuscript.MenuCanvas.SetActive(false);
        PlayerPrefs.SetInt("playgame",1);
        SceneManager.LoadScene("DiseaseFighter");
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("playgame",1);
        SceneManager.LoadScene("DiseaseFighter");
    }

    void OnApplicationPause()
    {
        // Debug.LogError("_applicationPause..." + _applicationPause);
        if(_applicationPause)
        {
            Time.timeScale = 0;
			PausePanel.SetActive (true);
        }
    }

        public void PauseBtn()
        {
            if (Time.timeScale == 1) 
            {
                Time.timeScale = 0;
                PausePanel.SetActive (true);
            }
            else 
            {
                PausePanel.SetActive (false);
                Time.timeScale = 1;
            }
        }

        public void PlayBtn()
        {
            Time.timeScale = 1;
            PausePanel.SetActive (false);
        }


       public void UpdateLevelTimer(float totalSeconds)
         {
             int minutes = Mathf.FloorToInt(totalSeconds / 60f);
             int seconds = Mathf.RoundToInt(totalSeconds % 60f);
 
             string formatedSeconds = seconds.ToString();
 
             if (seconds == 60)
             {
                 seconds = 0;
                 minutes += 1;
             }
 
             TimerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
         }

    public void EnemyInstantiate()
    {
        // int enemyCount = levelManager.LevelController[currentLevel].levelEnemyList.Count; 
        if (EnemyInstantiateCount <= generateEnemyCount)                    //enemyCount
        {                 
            // Debug.LogError("enemyCount..." + enemyCount);
            ShuffleList(EnemyGeneratePos);
            for(int i = 0; i <= generateEnemyCount-1; i++)                  //enemyCount
            {
                EnemyInstantiateCount += 1;
                int enemy_generate = Random.Range(0, enemyCount);
                // Debug.LogError("EnemyInstantiateCount....." + EnemyInstantiateCount);
                if (EnemyInstantiateCount >= generateEnemyCount+1)          //enemyCount
                {
                    break;
                }               
                InstEnemyObj = Instantiate(levelManager.LevelController[currentLevel].levelEnemyList[enemy_generate].Enemyobj, EnemyGeneratePos[i].transform.position, Quaternion.identity);
                InstEnemyObj.transform.parent = EnemyGeneration.transform;
                InstEnemyObj.transform.localPosition = EnemyGeneratePos[i].transform.localPosition;
                InstEnemyObj.transform.name = "Enemy_"+ EnemyInstantiateCount;                
                //Debug.LogError("Viruse Name is_ : "+ InstEnemyObj.transform.name);              
            }          
        }
        else
        {
            CancelInvoke("EnemyInstantiate");
            Debug.LogError("Cancel Invoke for V13");
        }

    }

   

    IEnumerator changeLevel()
    {
        yield return new WaitForSeconds(3f);
        InstructionPanel_Bullet.SetActive(false);
        // intScore = 0;
        // Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        // EnemyInstantiateCount = 0;
        // lvlDone.SetActive(false);
        // levelManager.LevelController[currentLevel].gun.SetActive(false);
        // levelManager.LevelController[currentLevel].brainObstacle.SetActive(false);
        // bg_particle[currentLevel].SetActive(false);
        // SceneManager.LoadScene("DiseaseFighter");
        // Gamefunction();
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("DiseaseFighter");
    }

    IEnumerator ReSetGame()
    {
        yield return new WaitForSeconds(1f);
        ImgPlayerLifeFill.fillAmount = 1f;
    }

     void ShuffleList(List<GameObject> a)
    {
        // Loops through array
        for (int i = a.Count-1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = Random.Range(0,i);
            // Save the value of the current i, otherwise it'll overright when we swap the values
            GameObject temp = a[i];

            // Swap the new and old values
            a[i] = a[rnd];
            a[rnd] = temp;
        }

        // Print
        for (int i = 0; i < a.Count; i++)
        {
            //Debug.Log ("Shuffle_   "+a[i]);
            //AllOpt.rOptionList.Add (a [i]);)
        }

    }

    public void generateEnemy()
    {
        int _enemy = Random.Range(0, enemyCount);        
        ShuffleList(EnemyGeneratePos);
        InstEnemyObj = Instantiate(levelManager.LevelController[currentLevel].levelEnemyList[_enemy].Enemyobj);
        InstEnemyObj.transform.parent = EnemyGeneration.transform;
        InstEnemyObj.transform.localPosition = EnemyGeneratePos[_enemy].transform.localPosition;
        InstEnemyObj.transform.name = "Enemy_"+ _enemy;
        Debug.Log("_enemy...." + _enemy + "  " + "Enemy Name...." + levelManager.LevelController[currentLevel].levelEnemyList[_enemy].Enemyobj.name);
    }
   

    public void paneltrue()
    {
        StartCoroutine(PanelActive());
    }

    IEnumerator PanelActive()
    {
        yield return new WaitForSeconds(3.5f);
        CancelInvoke("EnemyInstantiate");
        GunGenearated.Clear();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        GameObject[] gungenerated_1 = GameObject.FindGameObjectsWithTag("Gun_1");
        foreach (GameObject gun in gungenerated_1)
        {
            GameObject.Destroy(gun);
        }

        GameObject[] gungenerated_2 = GameObject.FindGameObjectsWithTag("Gun_2");
        foreach (GameObject gun in gungenerated_2)
        {
            GameObject.Destroy(gun);
        }

        GameObject[] sugarcandy = GameObject.FindGameObjectsWithTag("Candy");
        foreach(GameObject candy in sugarcandy)
        {
            GameObject.Destroy(candy);
        }

        // GameObject[] fruits = GameObject.FindGameObjectsWithTag("Exploder");
        // foreach(GameObject fruit in fruits)
        // {
        //     Debug.Log("Fruits name..." + fruit.name);
        //     GameObject.Destroy(fruit);
        // }

        //intScore = 0;
        //EnemyInstantiateCount = 0;
        EnemyGeneratePos.Clear();
        EnemyGeneratePos_New.Clear();
        TimerText.enabled = false;
        intScore = 0;

        // if (currentLevel == 99)           //49  //<= findController.GetComponent<Controller>().levelManager.LevelController.Count - 1)
        if( PlayerPrefs.GetInt("CurrentLevelNo") == 100 )
        {
            GameOverCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            GameOverCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            GameOverCanvas.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            _candyCollected_total.text = TargetTxt.text;
            GameOverCanvas.SetActive(true); 
        }
        else
        {
            RayCasthit _rayCastHit = FindObjectOfType<RayCasthit>();
            BulletFire = false;
            InstructionPanel.SetActive(true);            
            LevelTxt.text = "Level " + textScore.ToString() + " Completed...!";
            _CoinCollected.text = TargetTxt.text;
            _EnemyCollected.text = EnemyKillCount.ToString();
            if( PlayerPrefs.GetInt("CurrentLevel") < 49 )
            {
                PlayerPrefs.SetInt("CurrentLevel",PlayerPrefs.GetInt("CurrentLevel") + 1);
                // PlayerPrefs.SetInt("CurrentLevel",48);
                PlayerPrefs.SetInt("CurrentLevelNo",PlayerPrefs.GetInt("CurrentLevel") + 1);
                // Debug.LogError("CurrentLevel...if..." + PlayerPrefs.GetInt("CurrentLevelNo"));
            }
            else
            {
                if (!PlayerPrefs.HasKey ("LevelName")) 
                {
                    PlayerPrefs.SetInt ("LevelName",50);        //50
                    PlayerPrefs.Save();
                }
                else
                {
                    PlayerPrefs.SetInt("LevelName", PlayerPrefs.GetInt("LevelName") + 1);
                }
                int count = Random.Range(39,49);
                PlayerPrefs.SetInt("CurrentLevel", count);
                PlayerPrefs.SetInt("CurrentLevelNo",PlayerPrefs.GetInt("LevelName") + 1);
                // Debug.LogError("CurrentLevel...else..." + PlayerPrefs.GetInt("CurrentLevel") + "  LevelName..." + PlayerPrefs.GetInt("CurrentLevelNo"));
            }
        }        
    }

    public void GunCollection_fun()
    {
        StartCoroutine(Guncollection());
    }

    IEnumerator Guncollection()
    {
        yield return new WaitForSeconds(2.0f);
        CollectGun_txt.enabled = false;        
    }

    public void MoveDirection()
    {
        if( Joystick_left.active )
        {
            Joystick_left.SetActive(false);
            fire_right.SetActive(false);
            Reload_right.SetActive(false);
            Joystick_right.SetActive(true);
            fire_left.SetActive(true);
            Reload_left.SetActive(true);
            PlayerPrefs.SetInt("movedirection",1);
        }
        else
        {
            Joystick_right.SetActive(false);
            fire_left.SetActive(false);
            Reload_left.SetActive(false);
            Joystick_left.SetActive(true);
            fire_right.SetActive(true);
            Reload_right.SetActive(true);
            PlayerPrefs.SetInt("movedirection",0);
        }
    }

    public void BulletShot()
    {
        EnemyMovement _enemymovement = FindObjectOfType<EnemyMovement>();
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
        if( BulletFire == true )
        {
            Reload_txt.enabled = false;
            if( Count_bullet < 20 )
            {
                if (Camera.main.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<PlayerMovment>().isPlayerDie == false )
                {
                    if (isLevelChange == false)
                    {
                        _raycastHit.anim.Play("ShotgunFire");
                        Count_bullet = Count_bullet + 1;
                        reloadNo = reloadNo - 1;
                        if( reloadNo >= 0 )
                        {
                            Bullet_reloadNo_left.text = reloadNo.ToString();
                            Bullet_reloadNo_right.text = reloadNo.ToString();
                            Reload_txt.enabled = false;
                        }
                        if( Gun_multipleShot.activeInHierarchy )
                        {
                            // Debug.LogError("Gun_multishot");
                            // StartCoroutine(Bullet_generation(0.1f));                 //For multiple bullet shots
                            multishot = true;
                        }
                        else if( Gun_doubleShot.activeInHierarchy )
                        {
                            // Debug.LogError("Gun_doubleshot");
                            // StartCoroutine(Bullet_generation(0.1f));
                            doubleshot = true;
                        }
                        else
                        {
                            int count = UnityEngine.Random.Range(0, _raycastHit.Bullet_gen.Count);
                            StartCoroutine(ShotEffect());                                
                            GameObject projectile = Instantiate(_raycastHit.Bullet_gen[count]) as GameObject;
                            projectile.transform.position = _raycastHit.WeaponPos.transform.position;                            
                            Rigidbody rb = projectile.GetComponent<Rigidbody>();
                            // rb.velocity = this.transform.forward * 60;                  //100
                            rb.velocity = _raycastHit.SimpleShot_gun.transform.forward * 60;                     //100 
                        }                        
                    }
                }
            }            
        }
    }

    public void ReloadGun()
    {
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
        BulletFire = false;
        Count_bullet = 0;
        Reload_txt.enabled = false;
        // gameObject.transform.GetComponent<Animation>().Play("Reload");
        if( Gun_multipleShot.activeInHierarchy )
        {
            _raycastHit.Anim_multiShot.Play("Reload");
        }
        else if( Gun_doubleShot.activeInHierarchy )
        {
            _raycastHit.Anim_doubleShot.Play("Reload");
        }
        else
        {
            _raycastHit.anim.Play("Reload");
        }        

        // reloadNo = 20;
        // _controllScript.Bullet_reloadNo.text = reloadNo.ToString();

        if (PlayerPrefs.GetInt ("SoundOn") == 0)
        {
            levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Play();
            Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        else
        {
            levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            levelManager.LevelController[currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        }
        StartCoroutine(BulletShot_start(1.0f));
    }

    IEnumerator Bullet_doubleshot( float delay )
    {
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
        for( int i = 0; i <= 2; i++ )
        {
            int count_multi = UnityEngine.Random.Range(0, _raycastHit.Bullet_gen.Count);
            StartCoroutine(ShotEffect());
            GameObject projectile_multi = Instantiate(_raycastHit.Bullet_gen[count_multi]) as GameObject;
            projectile_multi.transform.position = _raycastHit.WeaponPos_doubleShot.transform.position;                            
            Rigidbody rb_multi = projectile_multi.GetComponent<Rigidbody>();
            rb_multi.velocity = _raycastHit.Anim_doubleShot.transform.forward * 60;                  //100
            yield return new WaitForSeconds(delay);
        }
        doubleshot = false;
    }

    IEnumerator Bullet_multishot( float delay )
    {
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
        for( int i = 0; i <= 2; i++ )
        {
            int count_multi = UnityEngine.Random.Range(0, _raycastHit.Bullet_gen.Count);
            StartCoroutine(ShotEffect());
            GameObject projectile_multi = Instantiate(_raycastHit.Bullet_gen[count_multi]) as GameObject;
            projectile_multi.transform.position = _raycastHit.WeaponPos_MultiShot.transform.position;
            // Debug.Log("Weapons_pos..." + _raycastHit.WeaponPos_MultiShot.transform.position);
            Rigidbody rb_multi = projectile_multi.GetComponent<Rigidbody>();
            // rb_multi.velocity = this.transform.forward * 60;                  //100
            rb_multi.velocity = _raycastHit.MultiShot_gun.transform.forward * 60;                  //100
            yield return new WaitForSeconds(delay);
        }
        multishot = false;
    }

    IEnumerator BulletShot_start( float delay )
    {
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
        yield return new WaitForSeconds(delay);
        Controller _controllScript = FindObjectOfType<Controller>();
        BulletFire = true;
        reloadNo = 20;
        Bullet_reloadNo_left.text = reloadNo.ToString();
        Bullet_reloadNo_right.text = reloadNo.ToString();
        _raycastHit.anim.Rebind();
        Bullet_CountImg.GetComponent<Animation>().Stop();
        Bullet_CountImg.GetComponent<Animation>().enabled = false;
    }

    private IEnumerator ShotEffect()
	{
        RayCasthit _raycastHit = FindObjectOfType<RayCasthit>();
		_raycastHit.gunAudio.Play ();
		// laserLine.enabled = true;
		// gunEnd.transform.GetChild (0).transform.gameObject.SetActive (true);
      
        yield return new WaitForSeconds(0.07f);
       _raycastHit. anim.Rebind();
		// gunEnd.transform.GetChild (0).transform.gameObject.SetActive (false);
		// laserLine.enabled = false;
	}

}
