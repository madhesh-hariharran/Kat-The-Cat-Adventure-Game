using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

[System.Serializable]
public class SaveObject
{
    public float timeTaken;
}

public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject unitGameObject;
    private IUnit unit;
    private float timeTaken;
    private void Awake()
    {
        unit = unitGameObject.GetComponent<IUnit>();
        SaveSystem.Init();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    private void Save()
    {
        timeTaken = Time.time;

        SaveObject saveObject = new SaveObject
        {
            timeTaken = timeTaken
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);

        CMDebug.TextPopupMouse("Saved!");
    }
    private void Load()
    {
        string lowestTime = SaveSystem.LoadLowestTime(); 

        if (lowestTime != "No save data found")
        {
            Debug.Log("Lowest Time Taken: " + lowestTime);
        }
        else
        {
            CMDebug.TextPopupMouse("No save");
        }
    }
}
