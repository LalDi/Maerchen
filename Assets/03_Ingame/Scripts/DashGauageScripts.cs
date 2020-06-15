using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashGauageScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, (Singleton.singleton.Player.DashGauge) * 1.4f, 0);
    }
}
