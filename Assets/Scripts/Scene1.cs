using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{
    public static Scene1 menu;
    public string playerName;

    // Start is called before the first frame update
    public void Awake()
    {
        if (menu == null)
        {
            menu = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
       
    }
    public void LoadName(string name)
    {
        playerName = name;
        Debug.Log("Player Name is : " + playerName);
    }
}
