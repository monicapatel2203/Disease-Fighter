using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.AI;

public class RayCasthit : MonoBehaviour {
       
	public int gunDamage = 1, Count_bullet;
	public float fireRate = 0.25f;
	public float weaponRange = 5f;
	public float hitForce = 4f;   
	public Transform gunEnd;
	public bool enmeyhit;
	private Camera fpsCam;                                              
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
	public AudioSource gunAudio;
	private LineRenderer laserLine;
	private float nextFire;
	public GameObject[] enmey;
	public Texture targetimg;
	public GameObject particle;
    public GameObject findController;
    public GameObject bullet;
    public GameObject cardbord;
    private GameObject insBullet;
    public bool BulletFire;
    public GameObject WeaponPos,WeaponPos_doubleShot, WeaponPos_MultiShot, SimpleShot_gun, DoubleShot_gun, MultiShot_gun;   //,Bullet_gen;
    public List<GameObject> Bullet_gen;

    public int reloadNo;
    public Animator  anim, Anim_doubleShot, Anim_multiShot;
    // public int counter,counter_bullet,bullet_no;


    public List<GameObject> enemydestroy = new List<GameObject> ();

	void Start () 
	{
        BulletFire = true;
        // counter = 0;
        Count_bullet = 0;
        reloadNo = 20;
		laserLine = GetComponent<LineRenderer>();
		nextFire = 0.0f;
		gunAudio = GetComponent<AudioSource>();
        findController = GameObject.Find("Controller") as GameObject;
        fpsCam = GetComponentInParent<Camera>();
		enmeyhit = false;
        // if( PlayerPrefs.GetInt("CurrentLevel") == 8 )
        // {
        //     counter_bullet = 30;
        //     bullet_no = counter_bullet;
        //     findController.GetComponent<Controller>().Bullet_image.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.text = counter_bullet.ToString();
        // }
        // else if( PlayerPrefs.GetInt("CurrentLevel") == 9 )
        // {
        //     counter_bullet = 36;
        //     bullet_no = counter_bullet;
        //     findController.GetComponent<Controller>().Bullet_image.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.text = counter_bullet.ToString();
        // }
        // else if( PlayerPrefs.GetInt("CurrentLevel") == 10 )
        // {
        //     counter_bullet = 40;
        //     bullet_no = counter_bullet;
        //     findController.GetComponent<Controller>().Bullet_image.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.enabled = true;
        //     findController.GetComponent<Controller>().Bullet_value.text = counter_bullet.ToString();
        // }
        if (PlayerPrefs.GetInt ("SoundOn") == 0)
        {
            this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            this.gameObject.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
        }
        findController.GetComponent<Controller>().Bullet_CountImg.GetComponent<Animation>().enabled = false;
	}

    void Update()
    {
        EnemyMovement _enemymovement = FindObjectOfType<EnemyMovement>();
        Controller _controllScript = FindObjectOfType<Controller>();
        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        // if( _controllScript.GameOverCanvas.activeInHierarchy || _controllScript.InstructionPanel.activeInHierarchy )
        // {
        //     _controllScript.Reload_txt.enabled = false;
        // }
        // else
        // {
        //     if ( Input.GetButtonDown("Fire9") || Input.GetMouseButtonDown(1) )                      //Reload the gun
        //     {
        //         BulletFire = false;
        //         Count_bullet = 0;
        //         _controllScript.Reload_txt.enabled = false;
        //         // gameObject.transform.GetComponent<Animation>().Play("Reload");
        //         anim.Play("Reload");

        //         // reloadNo = 20;
        //         // _controllScript.Bullet_reloadNo.text = reloadNo.ToString();

        //         if(_controllScript.MusicBtn.image.sprite == _controllScript.MusicOff)
        //         {
        //             _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
        //             _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        //             _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
        //             _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        //             _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
        //             _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        //         }
        //         else
        //         {
        //             _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
        //             _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Play();
        //             _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
        //             _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
        //             _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
        //             _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
        //         }
        //         StartCoroutine(BulletShot_start(1.0f));
        //     }
        // }

        // if( BulletFire == true )
        // {
        //     _controllScript.Reload_txt.enabled = false;
        //     // _controllScript.Reload_txt.GetComponent<Animation>().Stop();
        //     // _controllScript._reloadanim.enabled = false;
        //     if(Count_bullet < 20)
        //     {
        //         if (Camera.main.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<PlayerMovment>().isPlayerDie == false )
        //         {
        //             if (findController.GetComponent<Controller>().isLevelChange == false)
        //             {
        //                     if (Input.GetButtonDown("Fire10") || Input.GetMouseButtonDown(0))//Input.GetButtonDown("Fire1")  || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire8") )
        //                     {
        //                         anim.Play("ShotgunFire");
        //                         Count_bullet = Count_bullet + 1;
        //                         reloadNo = reloadNo - 1;
        //                         if(reloadNo >= 0)
        //                         {
        //                             _controllScript.Bullet_reloadNo.text = reloadNo.ToString();
        //                             _controllScript.Reload_txt.enabled = false;
        //                         }
        //                         // nextFire = Time.time + fireRate;

        //                         if( _controllScript.Gun_multipleShot.activeInHierarchy ||  _controllScript.Gun_doubleShot.activeInHierarchy )
        //                         {
        //                             StartCoroutine(Bullet_generation(0.1f));                 //For multiple bullet shots
        //                         }
        //                         else if( _controllScript.Gun_doubleShot.activeInHierarchy )
        //                         {
        //                             StartCoroutine(Bullet_generation(0.1f));                 //For multiple bullet shots
        //                             // int count = UnityEngine.Random.Range(0, Bullet_gen.Count);
        //                             // GameObject projectile = Instantiate(Bullet_gen[count]) as GameObject;
        //                             // projectile.transform.position = WeaponPos.transform.position;
        //                             // Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //                             // rb.velocity = this.transform.forward * 60;                  //100

        //                             // int count_doubleShot = UnityEngine.Random.Range(0, Bullet_gen.Count);
        //                             // GameObject projectile_doubleShot = Instantiate(Bullet_gen[count_doubleShot]) as GameObject;
        //                             // projectile_doubleShot.transform.position = WeaponPos_doubleShot.transform.position;
        //                             // Rigidbody rb_doubleShot = projectile_doubleShot.GetComponent<Rigidbody>();
        //                             // rb_doubleShot.velocity = this.transform.forward * 60;                  //100

        //                             // StartCoroutine(ShotEffect());
        //                         }
        //                         else
        //                         {
        //                             int count = UnityEngine.Random.Range(0, Bullet_gen.Count);
        //                             StartCoroutine(ShotEffect());                                
        //                             GameObject projectile = Instantiate(Bullet_gen[count]) as GameObject;
        //                             projectile.transform.position = WeaponPos.transform.position;                            
        //                             Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //                             rb.velocity = this.transform.forward * 60;                  //100
        //                         }                                

        //                         Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        //                         RaycastHit hit;
                                
        //                         // fireBullet(gunEnd.transform.position);
        //                         laserLine.SetPosition(0, gunEnd.position);

        //                         // if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        //                         // {
        //                         //     if (hit.collider.gameObject.tag == "Enemy")
        //                         //     {
        //                         //         hit.collider.gameObject.GetComponent<EnemyMovement>().Health -= hit.collider.gameObject.GetComponent<EnemyMovement>().hit_health;
        //                         //         hit.collider.gameObject.GetComponent<EnemyMovement>().Ehealth_Bar.transform.GetComponent<Image>().fillAmount -= hit.collider.gameObject.GetComponent<EnemyMovement>().hit_health / 100f;
        //                         //         // Destroy (hit.collider.gameObject);
        //                         //         //GameObject soundpref = Instantiate (Resources.Load("sound")) as GameObject;
        //                         //         //soundpref.GetComponent<AudioSource> ().clip = Resources.Load ("bullethit") as AudioClip;
        //                         //         //soundpref.GetComponent<AudioSource>(). Play();
        //                         //         //Debug.Log (hit.collider.gameObject.name+"Found Box"+hit.collider.transform.position+"Position");
        //                         //         // GameObject boxParticle = Instantiate (Resources.Load("vfx_Hit_SpellOrange_Mobile 1") , hit.point , Quaternion.Euler (0, 0, 0))as GameObject; //("boxhitParticle")
        //                         //             // Debug.Log("Health...." + hit.collider.gameObject.GetComponent<EnemyMovement>().Health);                              
        //                         //     }
        //                         // }
        //                     }
        //             }
        //         }
        //     }            
        // }
        // if( Count_bullet == 20 )
        // {
        //     if( _controllScript.GameOverCanvas.activeInHierarchy || _controllScript.InstructionPanel.activeInHierarchy )
        //     {
        //         _controllScript.Reload_txt.enabled = false;
        //     }
        //     else
        //     {
        //         _controllScript.Reload_txt.enabled = true;
        //         _controllScript.Reload_txt.GetComponent<Animation>().Play("ReloadTxt_anim");
        //     }            
        //     // _controllScript._reloadanim.enabled = true;
        // }

        // if( Count_bullet >= 15.0f )
        // {
        //     _controllScript.Bullet_CountImg.GetComponent<Animation>().enabled = true;
        //     _controllScript.Bullet_CountImg.GetComponent<Animation>().Play("ReloadTxt_anim");
        // }
	}

    IEnumerator Bullet_generation( float delay )
    {
        for( int i = 0; i <= 2; i++ )
        {
            int count_multi = UnityEngine.Random.Range(0, Bullet_gen.Count);
            StartCoroutine(ShotEffect());
            GameObject projectile_multi = Instantiate(Bullet_gen[count_multi]) as GameObject;
            projectile_multi.transform.position = WeaponPos.transform.position;                            
            Rigidbody rb_multi = projectile_multi.GetComponent<Rigidbody>();
            rb_multi.velocity = this.transform.forward * 60;                  //100
            yield return new WaitForSeconds(delay);
        }
    }
    IEnumerator BulletShot_start( float delay )
    {
        yield return new WaitForSeconds(delay);
        Controller _controllScript = FindObjectOfType<Controller>();
        // Debug.Log("bulletFire..." + BulletFire);
        BulletFire = true;
        reloadNo = 20;
        _controllScript.Bullet_reloadNo_left.text = reloadNo.ToString();
        _controllScript.Bullet_reloadNo_right.text = reloadNo.ToString();
        anim.Rebind();
        _controllScript.Bullet_CountImg.GetComponent<Animation>().Stop();
        _controllScript.Bullet_CountImg.GetComponent<Animation>().enabled = false;
    }

    private void fireBullet(Vector3 pos)
    {
        GameObject currentBullet = (GameObject)Instantiate(bullet, pos, Quaternion.identity);
        currentBullet.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        Vector3 angle = gunEnd.transform.eulerAngles;
        currentBullet.transform.eulerAngles = angle;
        //currentBullet.transform.SetParent(gunEnd.transform.GetChild(1).transform);
        Vector3 forceVector = gunEnd.transform.GetChild(1).transform.forward;
        currentBullet.GetComponent<Rigidbody>().AddForce(forceVector * 100f * 1.5f, ForceMode.Impulse);
    }

    private IEnumerator ShotEffect()
	{
		gunAudio.Play ();
		// laserLine.enabled = true;
		// gunEnd.transform.GetChild (0).transform.gameObject.SetActive (true);
      
        yield return shotDuration;
        anim.Rebind();
		// gunEnd.transform.GetChild (0).transform.gameObject.SetActive (false);
		// laserLine.enabled = false;
	}



	void enemyTrigger()
	{
		enmeyhit = false;
	}

    public void BulletShot()
    {
        EnemyMovement _enemymovement = FindObjectOfType<EnemyMovement>();
        Controller _controllScript = FindObjectOfType<Controller>();
        if( BulletFire == true )
        {
            _controllScript.Reload_txt.enabled = false;
            if(Count_bullet < 20)
            {
                if (Camera.main.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<PlayerMovment>().isPlayerDie == false )
                {
                    if (findController.GetComponent<Controller>().isLevelChange == false)
                    {
                        anim.Play("ShotgunFire");
                        Count_bullet = Count_bullet + 1;
                        reloadNo = reloadNo - 1;
                        if(reloadNo >= 0)
                        {
                            _controllScript.Bullet_reloadNo_left.text = reloadNo.ToString();
                            _controllScript.Bullet_reloadNo_right.text = reloadNo.ToString();
                            _controllScript.Reload_txt.enabled = false;
                        }

                        int count = UnityEngine.Random.Range(0, Bullet_gen.Count);
                        StartCoroutine(ShotEffect());                                
                        GameObject projectile = Instantiate(Bullet_gen[count]) as GameObject;
                        projectile.transform.position = WeaponPos.transform.position;                            
                        Rigidbody rb = projectile.GetComponent<Rigidbody>();
                        rb.velocity = this.transform.forward * 60;                  //100

                        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
                        RaycastHit hit;

                        laserLine.SetPosition(0, gunEnd.position);
                    }
                }
            }            
        }
    }

    public void ReloadGun()
    {
        EnemyMovement _enemymovement = FindObjectOfType<EnemyMovement>();
        Controller _controllScript = FindObjectOfType<Controller>();
        BulletFire = false;
        Count_bullet = 0;
        _controllScript.Reload_txt.enabled = false;
        // gameObject.transform.GetComponent<Animation>().Play("Reload");
        anim.Play("Reload");

        // reloadNo = 20;
        // _controllScript.Bullet_reloadNo.text = reloadNo.ToString();

        if (PlayerPrefs.GetInt ("SoundOn") == 0)
        {
            _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Play();
            _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
            _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = true;
            _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        else
        {
            _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            _controllScript.levelManager.LevelController[_controllScript.currentLevel].gun.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            _controllScript.Gun_doubleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
            _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().enabled = false;
            _controllScript.Gun_multipleShot.transform.GetChild(0).GetComponent<AudioSource>().Stop();
        }
        StartCoroutine(BulletShot_start(1.0f));
    }
 
}
