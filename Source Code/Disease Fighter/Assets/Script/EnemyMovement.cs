using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;
    public float Health;
    public Image Ehealth_Bar;
    public float Damage_health;
    public float hit_health;
    public GameObject Particle_Atma;
    bool Stop_move;
    public GameObject findController;
    public GameObject Levelcontroller, SoundController;
    //new add
    public bool isEnemyAttack;
    float timer;
    int randomNo;
    public AudioSource PlayerHit_audio;
    public GameObject _enemyCanvas;
    public int _Coinvalue;
    Vector3 targetPosition;
    int count_Pos;
    Transform Destination_Pos;
    

    // Start is called before the first frame update
    void Start()
    {
        findController = GameObject.Find("Controller") as GameObject;
        Levelcontroller = GameObject.Find("LevelMgr") as GameObject;
        SoundController = GameObject.Find("SoundController") as GameObject;
        pathfinder = GetComponent<NavMeshAgent>();        
        target = GameObject.FindGameObjectWithTag("Player").transform;       
        StartCoroutine("UpdatePath");
        randomNo = Random.Range(45, 55);
        int count = findController.GetComponent<Controller>().generateEnemyCount;
        count_Pos = Random.Range(0,findController.GetComponent<Controller>().TargetPos.Count);
        Destination_Pos = findController.GetComponent<Controller>().TargetPos[count_Pos].transform;
        // findController.GetComponent<Controller>().CoinText.GetComponent<Text>().text = _Coinvalue.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(Health <1)
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.GetComponent<Animator>().Play("Die");
            _enemyCanvas.SetActive(false);
            // findController.GetComponent<Controller>()._Coinactive = true;
            StartCoroutine(HealthDown());
        }

        if(target.GetComponent<PlayerMovment>().isPlayerDie) 
        {
            gameObject.GetComponent<Animator>().Play("Win");
            gameObject.GetComponent<NavMeshAgent>().isStopped=true;
        }
    }

    public IEnumerator HealthDown()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

        findController.GetComponent<Controller>().EnemyObj = Instantiate(findController.GetComponent<Controller>().enemyObj_generate);
        findController.GetComponent<Controller>().EnemyObj.transform.parent = findController.GetComponent<Controller>().CandyGeneration.transform;
        findController.GetComponent<Controller>().EnemyObj.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 2.0f, this.transform.localPosition.z);

        findController.GetComponent<Controller>().CoinText.GetComponent<Text>().text = _Coinvalue.ToString();
        findController.GetComponent<Controller>()._Coinactive = true;
        // findController.GetComponent<Controller>().CoinText.SetActive(true);

        // DisplayImageLerp(findController.GetComponent<Controller>().CoinText);
        // this.gameObject.SetActive(false);

        Instantiate(Particle_Atma, gameObject.transform.position, Quaternion.identity);

        findController.GetComponent<Controller>().EnemyGenerateNo.text = findController.GetComponent<Controller>().intScore.ToString();
        // Debug.Log("intscore...." + findController.GetComponent<Controller>().intScore );
        findController.GetComponent<Controller>().intScore = findController.GetComponent<Controller>().intScore + 1;
        findController.GetComponent<Controller>().score.text = "" + findController.GetComponent<Controller>().intScore;

        if( findController.GetComponent<Controller>().ImgLevelFill.fillAmount == 1 )
        {

        }
        else
        {
            findController.GetComponent<Controller>().ImgLevelFill.fillAmount = (float)findController.GetComponent<Controller>().intScore / findController.GetComponent<Controller>().EnemyKillCount;           //generateEnemyCount
        }        

        // findController.GetComponent<Controller>()._HScore += 1;
        if( findController.GetComponent<Controller>().GameOverCanvas.activeInHierarchy ||  findController.GetComponent<Controller>().InstructionPanel.activeInHierarchy || findController.GetComponent<Controller>().RestartPanel.activeInHierarchy )
        {

        }
        else
        {
            // if( findController.GetComponent<Controller>().EnemyGeneration.transform.childCount <=  findController.GetComponent<Controller>().enemyCount / 2)
            if( findController.GetComponent<Controller>().intScore ==  findController.GetComponent<Controller>().EnemyKillCount / 2)
            {
                if(findController.GetComponent<Controller>().GenerateGun)
                {
                    for( int i = 0; i <= findController.GetComponent<Controller>().GunPosition.Count - 1 ; i++ )
                    {
                        int gunCount = Random.Range(0, findController.GetComponent<Controller>().Gun.Count);
                        if( !findController.GetComponent<Controller>().GunGenearated.Contains(findController.GetComponent<Controller>().Gun[gunCount]) )
                        {
                            GameObject gun_generate = Instantiate(findController.GetComponent<Controller>().Gun[gunCount]) as GameObject;
                            findController.GetComponent<Controller>().GunGenearated.Add(findController.GetComponent<Controller>().Gun[gunCount]);
                            gun_generate.transform.position = findController.GetComponent<Controller>().GunPosition[i].transform.localPosition;
                        }            
                        // Destroy(Gun[gunCount]);
                        // Gun.RemoveAt(gunCount);
                    }
                    findController.GetComponent<Controller>().CollectGun_txt.enabled = true;
                    findController.GetComponent<Controller>().CollectGun_txt.GetComponent<Animation>().Play("ReloadTxt_anim");
                    findController.GetComponent<Controller>().GunCollection_fun();
                    findController.GetComponent<Controller>().GenerateGun = false;
                }
            }
            if( findController.GetComponent<Controller>().EnemyGeneration.transform.childCount <=  findController.GetComponent<Controller>().generateEnemyCount )
            {
                findController.GetComponent<Controller>().EnemyInstantiateCount = findController.GetComponent<Controller>().generateEnemyCount - 1;
                findController.GetComponent<Controller>().EnemyInstantiate();
            }            
        }
        
        // if( findController.GetComponent<Controller>().intScore ==  Levelcontroller.GetComponent<LevelManager>().LevelController[findController.GetComponent<Controller>().currentLevel].EnemyCount )
        if( findController.GetComponent<Controller>().intScore == findController.GetComponent<Controller>().EnemyKillCount)
        {
            findController.GetComponent<Controller>().paneltrue();
            // CancelInvoke("EnemyInstantiate");
            // findController.GetComponent<Controller>().GunGenearated.Clear();

            // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            // foreach (GameObject enemy in enemies)
            // {
            //     GameObject.Destroy(enemy);
            // }

            // GameObject[] gungenerated_1 = GameObject.FindGameObjectsWithTag("Gun_1");
            // foreach (GameObject gun in gungenerated_1)
            // {
            //     GameObject.Destroy(gun);
            // }

            // GameObject[] gungenerated_2 = GameObject.FindGameObjectsWithTag("Gun_2");
            // foreach (GameObject gun in gungenerated_2)
            // {
            //     GameObject.Destroy(gun);
            // }            

            // //intScore = 0;
            // //EnemyInstantiateCount = 0;
            // findController.GetComponent<Controller>().EnemyGeneratePos.Clear();
            // findController.GetComponent<Controller>().EnemyGeneratePos_New.Clear();
            // findController.GetComponent<Controller>().TimerText.enabled = false;
            // findController.GetComponent<Controller>().intScore = 0;
            // // Debug.Log("findController Cl...." + findController.GetComponent<Controller>().currentLevel + "   " + "findController LC..." + findController.GetComponent<Controller>().levelManager.LevelController.Count);
            // if (findController.GetComponent<Controller>().currentLevel == 9)//<= findController.GetComponent<Controller>().levelManager.LevelController.Count - 1)
            // {
            //     findController.GetComponent<Controller>().GameOverCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            //     findController.GetComponent<Controller>().GameOverCanvas.transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
            //     findController.GetComponent<Controller>().GameOverCanvas.transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
            //     findController.GetComponent<Controller>().GameOverCanvas.SetActive(true); 
            // }
            // else
            // {
            //     RayCasthit _rayCastHit = FindObjectOfType<RayCasthit>();
            //     _rayCastHit.BulletFire = false;
            //     // StartCoroutine(PanelActive());
                
            //     // findController.GetComponent<Controller>().InstructionPanel.SetActive(true);
            //     // findController.GetComponent<Controller>().CoinText.SetActive(false);
            //     // findController.GetComponent<Controller>().LevelTxt.text = "Level " + findController.GetComponent<Controller>().textScore.ToString() + " Completed...!";
            //     // findController.GetComponent<Controller>()._CoinCollected.text = findController.GetComponent<Controller>().TargetTxt.text;
            //     // findController.GetComponent<Controller>()._EnemyCollected = findController.GetComponent<Controller>().levelManager.EnemyCount;
            // }
        }
    }

    IEnumerator UpdatePath()
    {
        Controller _controllScript = FindObjectOfType<Controller>();
        LevelManager _lvlmanager = FindObjectOfType<LevelManager>();
        float refreshrate = 0.25f;

        if (Health > 0 && target.transform.GetComponent<PlayerMovment>().playerHealth >0.5)
        {
            // int count_Pos = Random.Range(0,_controllScript.TargetPos.Count);
            // Debug.Log("Count_Pos..." + count_Pos + "  Enemy name..." + this.name);
            Vector3 targetPosition = new Vector3( findController.GetComponent<Controller>().TargetPos[count_Pos].transform.localPosition.x + 0.80f, findController.GetComponent<Controller>().TargetPos[count_Pos].transform.localPosition.y, findController.GetComponent<Controller>().TargetPos[count_Pos].transform.localPosition.z + 3.0f);

            // Debug.Log("Count_Pos..." + count_Pos + "  Enemy name..." + this.name + "  Pos..." + targetPosition);
            // Vector3 targetPosition = new Vector3(target.position.x + 0.80f, 0,target.position.z + 8.0f);     //6.50f        //z = 2.80f              //-0.80  target.position.x +0.80f                     
            // Debug.Log("targetPosition...." + Vector3.Distance(target.transform.position, gameObject.transform.position) + " Name..." + this.name);
            if(transform.GetComponent<NavMeshAgent>().isActiveAndEnabled)
            {
                transform.GetComponent<NavMeshAgent>().SetDestination(targetPosition);
            }            
            yield return new WaitForSeconds(refreshrate);
            if(!target.GetComponent<PlayerMovment>().isPlayerDie)
            {
                StartCoroutine("UpdatePath");
            }

            if (Vector3.Distance(Destination_Pos.transform.position, gameObject.transform.position) > 10f)     // 12f   // 6f  // && Vector3.Distance(target.transform.position, gameObject.transform.position) < 100)
            {
                gameObject.GetComponent<Animator>().Play("Walk");
            }
            else if (Vector3.Distance(Destination_Pos.transform.position, gameObject.transform.position) > 8f)        //10f   //4f
            {
                // if (PlayerPrefs.GetInt ("SoundOn") == 0)
                if( SoundController.GetComponent<SoundController>().MusicBtn.GetComponent<Image>().sprite == SoundController.GetComponent<SoundController>().SoundOn )
                {
                    PlayerHit_audio.Play();
                }
                else
                {
                    PlayerHit_audio.Stop();
                }
                GameObject enemy = this.gameObject;

                this.gameObject.GetComponent<NavMeshAgent>().angularSpeed = 0;

                if(!findController.GetComponent<Controller>().DestroyEnemy.Contains(enemy))                         //Add GameObject in list which are near to player
                {
                    findController.GetComponent<Controller>().DestroyEnemy.Add(enemy);
                }
                if( findController.GetComponent<Controller>().DestroyEnemy.Count > 3 )                             //Destroy Enemy if list is greater than 2
                {
                    for(int i = 0; i < findController.GetComponent<Controller>().DestroyEnemy.Count; i++)
                    {
                        Destroy(findController.GetComponent<Controller>().DestroyEnemy[i]);
                        findController.GetComponent<Controller>().DestroyEnemy.RemoveAt(i);
                        break;
                    }
                }
                if( findController.GetComponent<Controller>().GameOverCanvas.activeInHierarchy ||  findController.GetComponent<Controller>().InstructionPanel.activeInHierarchy || findController.GetComponent<Controller>().RestartPanel.activeInHierarchy )
                {

                }
                else
                {
                    if( findController.GetComponent<Controller>().EnemyGeneration.transform.childCount <=  findController.GetComponent<Controller>().enemyCount / 2)
                    {
                        findController.GetComponent<Controller>().EnemyInstantiateCount = 0;
                        findController.GetComponent<Controller>().EnemyInstantiate();
                    }
                }
                gameObject.GetComponent<Animator>().Play("Walk_Attack");
            }
            else
            {
                // Debug.Log("targetPosition...." + Vector3.Distance(target.transform.position, gameObject.transform.position));
                gameObject.GetComponent<Animator>().Play("Attack");

                // gameObject.transform.LookAt(Camera.main.transform);
                Vector3 lookPos = Camera.main.transform.position - gameObject.transform.position;
                Quaternion lookRot = Quaternion.LookRotation(lookPos, Vector3.up);
                float eulerY = lookRot.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler (0, eulerY, 0);
                gameObject.transform.rotation = rotation;

                if( SoundController.GetComponent<SoundController>().MusicBtn.GetComponent<Image>().sprite == SoundController.GetComponent<SoundController>().SoundOn )
                {
                    // PlayerHit_audio.Play();
                }
                else
                {
                    PlayerHit_audio.Stop();
                }
            }
        }
        else if(target.transform.GetComponent<PlayerMovment>().playerHealth < 0.5)
        {
            target.transform.GetComponent<PlayerMovment>().playerHealth = _lvlmanager.LevelController[_controllScript.currentLevel].PlayerLife;
        }
    }
}
