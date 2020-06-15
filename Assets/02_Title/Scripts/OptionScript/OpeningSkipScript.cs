using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpeningSkipScript : MonoBehaviour
{
    [SerializeField] private Toggle OS_Toggle; // OS = Opening Skip

    void Start()
    {
        OS_Toggle.isOn = PlayerPrefsX.GetBool("SkipOpening", false);
    }

    public void OpeningSkip(bool OS)
    {
        OS = OS_Toggle.isOn;
        PlayerPrefsX.SetBool("SkipOpening", OS);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        OS_Toggle.isOn = false;
    }
}
