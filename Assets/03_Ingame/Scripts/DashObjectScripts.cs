using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DashObjectScripts : MonoBehaviour
{
    public float endValue;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(endValue, 1.5f)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
        
        //DOTween.SetTweensCapacity(2000, 1500);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
