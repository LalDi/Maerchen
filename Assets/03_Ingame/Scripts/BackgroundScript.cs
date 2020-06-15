using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Day;
    [SerializeField] private GameObject Night;

    // Start is called before the first frame update
    void Start()
    {
        Day = transform.Find("Day").gameObject;
        Night = transform.Find("Night").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= transform.position.x + (43.5 * transform.localScale.x))
        {
            transform.position = new Vector3(transform.position.x + (42.4f * transform.localScale.x * 2), transform.position.y, transform.position.z);
        }
        if (Player.transform.position.x <= transform.position.x - (43.5 * transform.localScale.x))
        {
            transform.position = new Vector3(transform.position.x - (42.4f * transform.localScale.x * 2), transform.position.y, transform.position.z);
        }
        if (Singleton.singleton.DAN.DAN)
        {
            Day.SetActive(true);
            Night.SetActive(false);
        }
        else if (!Singleton.singleton.DAN.DAN)
        {
            Day.SetActive(false);
            Night.SetActive(true);
        }
    }

}