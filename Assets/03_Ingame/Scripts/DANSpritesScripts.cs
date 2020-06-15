using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DANSpritesScripts : MonoBehaviour
{
    public GameObject Day;
    public GameObject Night;

    // Start is called before the first frame update
    void Awake()
    {
        Day = transform.Find("Day").gameObject;
        Night = transform.Find("Night").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.singleton.DAN.DAN)
        {
            Day.SetActive(true);
            Night.SetActive(false);
        }
        else
        {
            Day.SetActive(false);
            Night.SetActive(true);
        }
    }

}
