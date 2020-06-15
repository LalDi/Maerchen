using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfcameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && (!(Singleton.singleton.Wolf.WolfJumpWaiting)) )
        {
            GameObject.Find("SoundsManager").GetComponent<IGSoundManagerScripts>().SoundManage("SoundWolf1");
            Singleton.singleton.Wolf.WolfJumpWaiting = true;
        }
    }
}
