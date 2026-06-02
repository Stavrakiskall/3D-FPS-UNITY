using UnityEngine;
using TMPro;


public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI promptMessage;

    public void updateText(string message)
    {
        promptMessage.text = message;
    }
}