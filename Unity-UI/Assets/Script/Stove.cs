using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stove : MonoBehaviour
{
    [SerializeField]
    Slider temp;

    [SerializeField]
    TextMeshProUGUI tempCounter;


    private void Start()
    {
        tempCounter.text = $"0 °C";
    }


    public void stoveTemp()
    {
        tempCounter.text = temp.value.ToString() + $" °C ";
    }
}
