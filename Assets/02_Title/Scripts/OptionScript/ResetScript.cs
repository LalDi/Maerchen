using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    [SerializeField] private GameObject Option;
    [SerializeField] private GameObject Record;
    [SerializeField] private GameObject ResetCheck;

    public void Reset()
    {
        Option.SetActive(true);
        ResetCheck.SetActive(false);
        GameObject.Find("OpeningSkip").GetComponent<OpeningSkipScript>().ResetData();
        GameObject.Find("Sounds").GetComponent<SoundsScript>().ResetData();
        GameObject.Find("PlayTimer").GetComponent<PlayTimeScript>().ResetData();
        Record.GetComponent<RecordScript>().ResetData();
    }

    public void CheckReset()
    {
        Option.SetActive(false);
        ResetCheck.SetActive(true);
    }

    public void CancelReset()
    {
        Option.SetActive(true);
        ResetCheck.SetActive(false);
    }
}
