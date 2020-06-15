using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    public Sprite[] DANObj = new Sprite[2];
    public SpriteRenderer DAN_Image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.singleton.DAN.DAN)
            gameObject.GetComponent<Image>().sprite = DANObj[0];

        else
            gameObject.GetComponent<Image>().sprite = DANObj[1];

    }
}
