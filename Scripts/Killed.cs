using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Killed : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentKilled = 0;

    private void Start()
    {
        text.text = "0";
    }

    public void UpdateKilled()
    {
        currentKilled++;
        text.text = currentKilled.ToString();
    }
}
