using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject canvas;
    public bool isEsc =false;
    void Start()
    {
        isEsc = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isEsc)
            {
                Time.timeScale = 0;
                isEsc = true;
                canvas.SetActive(true);
                UnityEngine.Cursor.visible = true;
                UnityEngine.Screen.lockCursor = false;
            }
            else
            {
                Time.timeScale = 1;
                isEsc = false;
                canvas.SetActive(false);
                UnityEngine.Cursor.visible = false;
                UnityEngine.Screen.lockCursor = true;
            }
        }
    }
    public void Play()
    {


        SceneManager.LoadScene(1);
    
    
    }
    public void Exit()
    {
        Application.Quit();
    }

}
