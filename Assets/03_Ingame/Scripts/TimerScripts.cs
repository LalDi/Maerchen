using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScripts : MonoBehaviour
{
    [SerializeField] private float Delay;

    float Timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Delay = Singleton.singleton.DAN.Delay;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        //if(Timer )
        transform.eulerAngles = new Vector3(0, 0, Timer * (180 / Delay) - 90);
    }
}
