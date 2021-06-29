using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemydestroyParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyParticle(0.5f));
    }

    IEnumerator DestroyParticle( float delay )
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
