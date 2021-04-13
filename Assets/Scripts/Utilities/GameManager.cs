using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    //Stats
    public int Score, Coins, CurrentLevel;
    public int LastLevel = 1, MaxLevel = 1;
    public int[] LevelHigh;

    //References
    public static GameManager instance;

    public bool Music, Sounds;

    private void Awake()
    {
        MakeSingleton();
        Load();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();

        //Check if current score is bigger than the current record in the current level
        if (Score >= LevelHigh[CurrentLevel])   LevelHigh[CurrentLevel] = Score;

        if (LastLevel > MaxLevel) MaxLevel = LastLevel;

        //Save high scores and levels
        data.LevelHigh = LevelHigh;
        data.CurrentLevel = CurrentLevel;
        data.Coins = Coins;
        data.LastLevel = LastLevel;
        data.MaxLevel = MaxLevel;
        data.LevelHigh = LevelHigh;
        data.Music = Music;
        data.Sounds = Sounds;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Stats
            LevelHigh = data.LevelHigh;
            CurrentLevel = data.CurrentLevel;
            Coins = data.Coins;
            LastLevel = data.LastLevel;
            LevelHigh = data.LevelHigh;
            Music = data.Music;
            Sounds = data.Sounds;
            MaxLevel = data.MaxLevel;
        }
    }
}

[Serializable]
class PlayerData
{
    //Stats
    public int Score, Coins, CurrentLevel;
    public int LastLevel, MaxLevel;
    public int[] LevelHigh;

    public bool Music, Sounds;
}
