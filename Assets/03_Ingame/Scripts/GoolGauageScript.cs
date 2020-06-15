using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoolGauageScript : MonoBehaviour
{
    public GameObject PlayerIcon;
    public GameObject WolfIcon;

    float i = 0.1f;

    private float PlayerX;
    private float WolfX;
    private float StartX;
    private float GoolX;

    private float PlayerDistance;
    private float WolfDistance;

    // Start is called before the first frame update
    void Start()
    {
        StartX = Singleton.singleton.Wolf.transform.position.x;
        GoolX = Singleton.singleton.Clear.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerX = Singleton.singleton.Player.transform.position.x;
        WolfX = Singleton.singleton.Wolf.transform.position.x;

        PlayerDistance = Mathf.Lerp(-16.7f, 16.7f, (PlayerX - StartX) / (GoolX - StartX));
        WolfDistance = Mathf.Lerp(-16.7f, 16.7f, (WolfX - StartX) / (GoolX - StartX));

        Vector3 PlayerPos = new Vector3(PlayerDistance, PlayerIcon.transform.localPosition.y);
        Vector3 WolfPos = new Vector3(WolfDistance, WolfIcon.transform.localPosition.y);

        PlayerIcon.transform.localPosition = PlayerPos;
        WolfIcon.transform.localPosition = WolfPos;

        //print(PlayerDistance);
    }
}
