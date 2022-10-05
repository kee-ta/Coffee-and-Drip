using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : SingletonController<DataPersistenceManager>
{
    [Header("File Storage Settings")]
    [SerializeField] private string fileName;

    private FileDataHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistent> dataPersistents;

    private void Start()
    {
        dataHandler = new FileDataHandler(Application.persistentDataPath,fileName);
        this.dataPersistents = FindAllDataPersistents();
        LoadGame();
        SaveGame();
        
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No Data found, initializing default...");
            NewGame();
        }
        foreach (IDataPersistent obj in dataPersistents)
        {
            obj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistent obj in dataPersistents)
        {
            obj.SaveData(gameData);
        }
        dataHandler.Save(gameData);
    }

    private List<IDataPersistent> FindAllDataPersistents()
    {
        IEnumerable<IDataPersistent> dataPersistents = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistent>();
        return new List<IDataPersistent>(dataPersistents);
    }
}
