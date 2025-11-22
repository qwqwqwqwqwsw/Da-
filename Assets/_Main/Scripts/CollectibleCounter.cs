using TMPro;
using UnityEngine;

public class CollectibleCounter : MonoBehaviour
{
    public GameObject winPanel;
    public TextMeshProUGUI counterText;
    private int _counter = 0;
    
    public void IncrementCounter()
    {
        _counter++;
        counterText.text = "Collectibles: " + _counter;
        if (_counter >= 5)
        {
            winPanel.SetActive(true);
        }
    }
}
