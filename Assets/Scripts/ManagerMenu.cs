using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static ManagerMenu activePlayer;
    public TMP_InputField setName;
    public string playerName;
    

    public void Start()
    {
       
    }
    public void ResetPlayer()
    {
        setName.text = " " ;
    }

}
