using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Scene1 : MonoBehaviour
{
    public static Scene1 menu;
    public TMP_InputField setName;
    public string playerName;

    // Start is called before the first frame update
    public void Awake()
    {

        if (menu != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            menu = this;
            playerName =  " " ;
            DontDestroyOnLoad(gameObject);
            
        }

    
    }

    public void LoadPlayer()
    {

        playerName = setName.text;

        Debug.Log("Player Name is : " + playerName);

    }






}
