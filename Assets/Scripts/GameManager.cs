using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{

    public TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        MemoryManager.Instance.playerName = inputField.text;
        SceneManager.LoadScene("Scenes/main");
    }

    public void ReturnToMenu()
    {
        if(MemoryManager.Instance.highScore < GameObject.Find("MainManager").GetComponent<MainManager>().m_Points)
        {
            MemoryManager.Instance.highScore = GameObject.Find("MainManager").GetComponent<MainManager>().m_Points;
            MemoryManager.Instance.highScoreName = MemoryManager.Instance.playerName;
        }
        SceneManager.LoadScene("Scenes/menu");
    }

    public void gameEnd()
    {
        MemoryManager.Instance.saveData();
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }
}
