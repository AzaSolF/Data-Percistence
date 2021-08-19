using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class ButtonStart : MonoBehaviour
{

    public Button startButton;


    // Start is called before the first frame update
  
    public void LoadMain()
    {
        SceneManager.LoadScene(1);
       
    }

    public void ExitGame()
    {

#if UNITY_EDITOR

    EditorApplication.ExitPlaymode();
#else
    Application.Quit(); // original code to quit Unity Player

#endif
    }


}
