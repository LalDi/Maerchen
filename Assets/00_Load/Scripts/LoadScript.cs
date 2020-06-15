using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadScript : MonoBehaviour
{
    public Text Loading1;

    public float Typing;
    public float Delay;

    private void Start()
    {
        LoadSceneManager.LoaderCallback();
        StartCoroutine(TextEffect());
    }

    IEnumerator TextEffect()
    {
        Loading1.DOText("Loading...", Typing, true);
        yield return new WaitForSeconds(Delay);
        Loading1.DOText("          ", Typing);
        yield return new WaitForSeconds(Delay);
        StartCoroutine(TextEffect());
    }

}
