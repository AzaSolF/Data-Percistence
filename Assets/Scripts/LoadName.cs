using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadName : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI displayPlayer;

    public void Awake()
    {
        
        displayPlayer.text = Scene1.menu.playerName;
    }
}
