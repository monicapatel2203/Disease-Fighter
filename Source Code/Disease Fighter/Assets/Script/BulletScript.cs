using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public GameObject Bulletparticle;
    public GameObject Particletransform;
    GameObject boxParticle;
    public ExploderObject Exploder;
    public static int bulletcount_doubleShot;
    public static int bulletcount_multiShot;
    // Start is called before the first frame update
    // void Start()
    // {
    //     Debug.Log("Bullet Script....");
    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    // void OnTriggerStay( Collider coll )
    // {
    //     Debug.LogError("Bullet Script Trigger stay....");
    //     if( coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Terrain" )
    //     {
    //         Destroy(this.gameObject);
    //         GameObject boxParticle = Instantiate (Bulletparticle)as GameObject;
    //         boxParticle.transform.position = this.transform.position;
    //         // Debug.Log("Trigger Stay..." + coll.gameObject.name);
    //     }
    // }


    void OnTriggerEnter( Collider coll )
    {
        // ClickOrTapToExplode _explodeparticle = FindObjectOfType<ClickOrTapToExplode>();
        if( coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Terrain" || coll.gameObject.tag == "Gun_1" || coll.gameObject.tag == "Gun_2" )
        {
            boxParticle = Instantiate (Bulletparticle)as GameObject;
            // boxParticle.transform.position = this.transform.position;
            boxParticle.transform.position = Particletransform.transform.position;

            // StartCoroutine(DestroyParticle(0.001f));

            Exploder.Explode();

            StartCoroutine( ExplodeFruits(0.05f) );
            // _explodeparticle.StartExplosion();
        }
        if( coll.gameObject.tag == "Gun_1" )
        {
            bulletcount_doubleShot = bulletcount_doubleShot + 1;
        }
        if( coll.gameObject.tag == "Gun_2" )
        {
            bulletcount_multiShot = bulletcount_multiShot + 1;
        }
        if( coll.gameObject.tag == "Enemy" )
        {
            coll.gameObject.GetComponent<EnemyMovement>().Health -= coll.gameObject.GetComponent<EnemyMovement>().hit_health;
            coll.gameObject.GetComponent<EnemyMovement>().Ehealth_Bar.transform.GetComponent<Image>().fillAmount -= coll.gameObject.GetComponent<EnemyMovement>().hit_health / 100f;
        }
    }

    IEnumerator ExplodeFruits( float delay )
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }

    // IEnumerator DestroyParticle( float delay )
    // {
    //     yield return new WaitForSeconds(delay);
    //     // Debug.LogError("BoxParticle Name..." + boxParticle.name);
    //     Destroy(boxParticle);
    // }

}
