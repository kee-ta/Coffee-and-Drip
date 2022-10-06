using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : SingletonController<DataPersistenceManager>
{
    [SerializeField] private bool initDataIfNull = false;
    [Header("File Storage Settings")]
    [SerializeField] private string fileName;

    private string selectedProfileID = "0";
    private FileDataHandler dataHandler;
    private GameData gameData;
    private List<IDataPersistent> dataPersistents;

    public static DataPersistenceManager i {get; private set;}

    public override void Awake()
    {
        if(i != null)
        {
            Debug.LogError("More Than One Data Persistance Manager");
            Destroy(this.gameObject);
            return;
        }
        i = this;
        DontDestroyOnLoad(this.gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }
    private void Start()
    {

    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistents = FindAllDataPersistents();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load(selectedProfileID);

        if(this.gameData == null && initDataIfNull )
        {
            NewGame();
        }

        if (this.gameData == null)
        {
            Debug.Log("No Data found, initializing default...");
            return;
        }
        foreach (IDataPersistent obj in dataPersistents)
        {
            obj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if(this.gameData == null)
        {
            Debug.LogWarning("A New game needs to be started before it can be saved!");
            return;
        }
        foreach (IDataPersistent obj in dataPersistents)
        {
            obj.SaveData(gameData);
        }
        dataHandler.Save(gameData,selectedProfileID);
    }

    private List<IDataPersistent> FindAllDataPersistents()
    {
        IEnumerable<IDataPersistent> dataPersistents = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataPersistent>();
        return new List<IDataPersistent>(dataPersistents);
    }

    private void OnApplicationQuit() {
        SaveGame();
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
