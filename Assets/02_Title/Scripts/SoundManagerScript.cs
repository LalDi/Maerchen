using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource SE;

    private float BGM_Volume;
    private float SE_Volume;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BGM_Volume = (float)PlayerPrefs.GetInt("BGM_Value", 50) / 200f;
        SE_Volume = (float)PlayerPrefs.GetInt("SE_Value", 50) / 100f;

        BGM.volume = BGM_Volume;
        SE.volume = SE_Volume;
    }
}
