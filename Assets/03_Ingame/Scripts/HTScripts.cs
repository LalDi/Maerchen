using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTScripts : MonoBehaviour
{
    Animator HTAnimator;

    [SerializeField] private float WaitingTimer = 0;

    [SerializeField] private GameObject PauseScene;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameOverObj;

    public bool GameEndWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
        HTAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEndWaiting)
        {
            if(WaitingTimer <= 2.3)
                WaitingTimer += Time.deltaTime;
            else
            {
                Singleton.singleton.Wolf.Speed = 0;
                PauseScene.SetActive(true);
                UI.SetActive(false);
                Pause.SetActive(false);
                GameOverObj.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HTAnimator.SetBool("AStart", true);
            GameObject.Find("SoundsManager").GetComponent<IGSoundManagerScripts>().SoundManage("SoundGun");
            GameEndWaiting = true;
        }
    }
}
