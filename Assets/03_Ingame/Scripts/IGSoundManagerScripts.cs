using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSoundManagerScripts : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SE;

    private float BGM_Volume;
    private float SE_Volume;

    public AudioClip SoundGun;
    public AudioClip SoundWolf1;
    public AudioClip SoundWolf2;
    public AudioClip SoundWolfHawling;
    
    private void Update()
    {
        BGM_Volume = (float)PlayerPrefs.GetInt("BGM_Value", 50) / 100f;
        SE_Volume = (float)PlayerPrefs.GetInt("SE_Value", 50) / 100f;

        BGM.volume = BGM_Volume;
        SE.volume = SE_Volume;
    }

    public void SoundManage(string AudioName)
    {
        if (AudioName == "SoundGun")
        {
            SE.panStereo = -0;
            SE.PlayOneShot(SoundGun);
        }
        if (AudioName == "SoundWolf1")
        {
            SE.panStereo = -0.8f;
            SE.PlayOneShot(SoundWolf1);
        }
        if (AudioName == "SoundWolf2")
        {
            SE.panStereo = -0.8f;
            SE.PlayOneShot(SoundWolf2);
        }
        if (AudioName == "SoundWolfHawling")
        {
            SE.panStereo = -0.8f;
            SE.PlayOneShot(SoundWolfHawling);
        }
        if (AudioName == "SoundJump")
        {

        }
        if (AudioName == "SoundHit")//장애물에 부딪힐때
        {

        }
        if (AudioName == "SoundClear")//???
        {

        }
        if (AudioName == "SoundDead")
        {

        }
        //추후 추가
    }
}
