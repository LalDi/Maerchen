using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DANTreeScrits : MonoBehaviour
{
    [SerializeField] private float DorN;
    [SerializeField] private float Speed;

    Vector3 vector;

    [SerializeField] private GameObject D_N;
    [SerializeField] private GameObject N_D;

    // Start is called before the first frame update
    void Start()
    {
        D_N = transform.Find("D_N").gameObject;
        N_D = transform.Find("N_D").gameObject;
        DorN = Singleton.singleton.DAN.Delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.singleton.DAN.IsTreeGo)
        {
            vector = transform.localPosition;
            if (vector.x < -40)
            {
                transform.localPosition = new Vector3(-26, 0, 0);
                Singleton.singleton.DAN.IsTreeGo = false;
            }
            else
            {
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            if (Singleton.singleton.DAN.DAN)
            {
                D_N.SetActive(true);
                N_D.SetActive(false);
            }
            else if (!Singleton.singleton.DAN.DAN)
            {
                D_N.SetActive(false);
                N_D.SetActive(true);
            }
        }
    }
}
