using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{

    public static MemoryManager Instance;
    public string playerName = "";
    public int highScore;
    public string highScoreName;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            highScore = 0;
            highScoreName = "";
            //Load Information
            loadData();
        }
        else {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        Debug.Log(playerName);
    }

    // Update is called once per frame

    [System.Serializable]
    public class SaveClass
    {
        public int score;
        public string name;
    }

    public void saveData()
    {
        SaveClass save = new SaveClass();
        save.score = highScore;
        save.name = highScoreName;

        string json = JsonUtility.ToJson(save);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveClass save = JsonUtility.FromJson<SaveClass>(json);

            highScoreName = save.name;
            highScore = save.score;
        }
    }
}
