using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt ("SoundOn") == 0)
        {
            this.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            this.GetComponent<AudioSource>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        StartCoroutine(DestroyParticle(0.5f));                                              //Destroy Fruits burst particle after specifies delay
    }

    IEnumerator DestroyParticle( float delay )
    {
        yield return new WaitForSeconds(delay);
        Exploder.FragmentPool _fragmentpool = FindObjectOfType<Exploder.FragmentPool>();
        _fragmentpool.DestroyFragments();
        Destroy(this.gameObject);
    }
}
