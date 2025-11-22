using System;
using TMPro;
using UnityEngine;

public class CollectibleCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int _counter = 0;

    private void Start()
    {
        counterText.text = "Collectibles: " + _counter;
    }

    public void IncrementCounter()
    {
        _counter++;
        counterText.text = "Collectibles: " + _counter;
    }
}
