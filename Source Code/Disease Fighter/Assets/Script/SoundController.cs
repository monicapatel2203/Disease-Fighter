using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public GameObject WinAudio, BGMusic, collectibleAudio, GameOverAudio;
    public Sprite SoundOn, SoundOff; // Sound On Off Button...
    public Button MusicBtn;
    public AudioSource BtnSource;
    public Material MusicOn_mat, MusicOff_mat;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt ("SoundOn") == 0)
        {
            BGMusic.GetComponent<AudioSource>().enabled = true;
            MusicBtn.transform.GetComponent<Image> ().sprite = SoundOn;
            MusicBtn.image.material = MusicOn_mat;
        }
        else
        {
            BGMusic.GetComponent<AudioSource>().enabled = false;
            MusicBtn.transform.GetComponent<Image> ().sprite = SoundOff;
            MusicBtn.image.material = MusicOff_mat;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OnSoundOnOff()
    {
        if (PlayerPrefs.GetInt ("SoundOn") == 0) 
		{
			PlayerPrefs.SetInt ("SoundOn", 1);
			MusicBtn.transform.GetComponent<Image> ().sprite = SoundOff;
            BGMusic.GetComponent<AudioSource>().enabled = false;
            MusicBtn.image.material = MusicOff_mat;
		}
		else
		{
			MusicBtn.transform.GetComponent<Image> ().sprite = SoundOn;
            MusicBtn.image.material = MusicOn_mat;
			PlayerPrefs.SetInt ("SoundOn", 0);
            BGMusic.GetComponent<AudioSource>().enabled = true;
		}
    }

    public void PlaySound()
	{
		if (PlayerPrefs.GetInt ("SoundOn") == 0)
		{
			BtnSource.Play();
		}
		else
		{
			BtnSource.Stop();
		}
	}
}
