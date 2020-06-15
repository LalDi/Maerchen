using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScripts : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float Strength = 3f;
    public float Duration = 1.5f;

    private Vector3 initialPosition;
    private bool PlayMove = false;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleton.singleton.Player.IsSlow)
        {
            if (Duration >= 0)
            {
                transform.localPosition = transform.localPosition + Random.insideUnitSphere * amplitude * Strength;
                //transform.DOShakePosition(3, new Vector3(1, 0, 0), 7, 90, true);
                Duration -= Time.deltaTime;
            }
            if (Strength >= 0)
                Strength -= Time.deltaTime;
            if (Duration <= 0 && !PlayMove)
            {
                transform.DOMove(new Vector3(transform.position.x, 2.5f, -15f), 1);
                PlayMove = true;
            }
        }
        else
        {
            Strength = 2f;
            Duration = 1.5f;
            //transform.position = new Vector3(transform.position.x, 1f, -15);
            //transform.DOMove(new Vector3(transform.position.x, 1f, -15f), 1);
            PlayMove = false;
        }
    }
}
