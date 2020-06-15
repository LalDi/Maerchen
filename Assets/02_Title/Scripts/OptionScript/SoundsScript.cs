using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsScript : MonoBehaviour
{
    [SerializeField] private int BGM_value;
    [SerializeField] private Slider BGM_Slider;
    [SerializeField] private InputField BGM_input;

    [SerializeField] private int SE_value;
    [SerializeField] private Slider SE_Slider;
    [SerializeField] private InputField SE_input;

    void Start()
    {
        BGM_value = PlayerPrefs.GetInt("BGM_Value", 50);
        SE_value = PlayerPrefs.GetInt("SE_Value", 50);

        BGM_input.text = BGM_value.ToString();
        BGM_Slider.value = BGM_value;
        SE_input.text = SE_value.ToString();
        SE_Slider.value = SE_value;
    }

    public void SetBGMScroll()
    {
        BGM_value = (int)BGM_Slider.value;
        BGM_input.text = BGM_value.ToString();
        PlayerPrefs.SetInt("BGM_Value", BGM_value);
    }

    public void SetBGMInput()
    {
        if (BGM_input.text == "")
        {
            BGM_input.text = "0";
        }
        BGM_value = int.Parse(BGM_input.text);
        BGM_Slider.value = BGM_value;
        PlayerPrefs.SetInt("BGM_Value", BGM_value);
    }

    public void SetSEScroll()
    {
        SE_value = (int)SE_Slider.value;
        SE_input.text = SE_value.ToString();
        PlayerPrefs.SetInt("SE_Value", SE_value);
    }

    public void SetSEInput()
    {
        if (SE_input.text == "")
        {
            SE_input.text = "0";
        }
        SE_value = int.Parse(SE_input.text);
        SE_Slider.value = SE_value;
        PlayerPrefs.SetInt("SE_Value", SE_value);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();

        BGM_value = PlayerPrefs.GetInt("BGM_Value", 50);
        SE_value = PlayerPrefs.GetInt("SE_Value", 50);

        BGM_input.text = BGM_value.ToString();
        BGM_Slider.value = BGM_value;
        SE_input.text = SE_value.ToString();
        SE_Slider.value = SE_value;
    }
}
