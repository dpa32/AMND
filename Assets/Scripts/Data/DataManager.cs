using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static GameObject container;

    static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (!instance)
            {
                container = new GameObject();
                container.name = "DataManager";
                instance = container.AddComponent(typeof(DataManager)) as DataManager;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }

    string GameDataFileName = "GameData.json";

    public GameData gameData = new GameData();
    public bool isNew = true;

    // 불러오기
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        //Debug.Log(filePath);

        if (File.Exists(filePath))
        {
            string FromJsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(FromJsonData);
            Debug.Log("불러오기 완료");
            isNew = false;

            //LoadInven();
            //itemList = Instance.gameData.InvenList;
        }
        else
        {
            Debug.Log("불러오기 실패");
            isNew = true;
        }
    }



    // 저장하기
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData, true);
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        //string jsonString = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("저장 완료");
    }
    public void DeleteGameData()
    {
        string filePath = Application.persistentDataPath + "/" + GameDataFileName;
        System.IO.File.Delete(filePath);

    }


    private void Awake()
    {
        //SaveGameData();
        LoadGameData();
    }
}
