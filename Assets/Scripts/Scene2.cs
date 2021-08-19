using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour
{
    public static Scene2 menu;
    public MainManager update;
    public int updateScore;

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
            DontDestroyOnLoad(gameObject);

        }
        // Start is called before the first frame update

    }

    private void Start()
    {
        update = GameObject.Find("MainManager").GetComponent<MainManager>();
        updateScore = menu.update.highScore;


    }
}
