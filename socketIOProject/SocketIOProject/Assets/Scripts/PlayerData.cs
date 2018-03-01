using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string json;
    string gameDataFilePath = "/StreamingAssets/data.json";
    void Start()
    {
        GameData jsonObj = new GameData();
        jsonObj.playerName = "Charles";
        jsonObj.score = 2002;
        jsonObj.timePlayed = 15000.23f;
        jsonObj.lastLogin = "March 1, 2018";

        json = JsonUtility.ToJson(jsonObj);
        string filePath = Application.dataPath + gameDataFilePath;
        System.IO.File.WriteAllText(filePath, json);
        Debug.Log(json);

    }

}
