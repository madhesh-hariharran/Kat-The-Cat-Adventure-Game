using System.IO;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";
    private const string SAVE_FILENAME = "saveData.txt";
    private const string HIGHSCORE_FILENAME = "highscore.txt";
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }
    public static void Save(string saveString)
    {
        string saveFilePath = SAVE_FOLDER + SAVE_FILENAME;

        if (!File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, saveString + "\n"); 
        }
        else
        {
            File.AppendAllText(saveFilePath, saveString + "\n"); 
        }
    }
    public static void ClearSaveData()
    {
        string saveFilePath = SAVE_FOLDER + SAVE_FILENAME;

        if (File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, string.Empty);
        }
    }
    public static string LoadLowestTime()
    {
        string saveFilePath = SAVE_FOLDER + SAVE_FILENAME;
        if (File.Exists(saveFilePath))
        {
            string[] lines = File.ReadAllLines(saveFilePath);
            if (lines.Length > 0)
            {
                List<float> timeTakenList = new List<float>();
                foreach (string line in lines)
                {
                    SaveObject saveObject = JsonUtility.FromJson<SaveObject>(line);
                    if (saveObject != null)
                    {
                        timeTakenList.Add(saveObject.timeTaken);
                    }
                }
                if (timeTakenList.Count > 0)
                {
                    timeTakenList.Sort(); 
                    string highscorePath = SAVE_FOLDER + HIGHSCORE_FILENAME;
                    int highScoreCount = 0;
                    if (File.Exists(highscorePath))
                    {
                        highScoreCount = File.ReadLines(highscorePath).Count();
                    }
                    string highscoreEntry = "time" + (highScoreCount + 1) + ": " + timeTakenList[0] + "s" + "\n";
                    File.AppendAllText(highscorePath, highscoreEntry);
                    File.WriteAllText(saveFilePath, string.Empty);
                    return "Lowest Time Taken: " + timeTakenList[0] + "s";
                }
            }
        }
        return "No save data found";
    }
}
