using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    //이름,계절,날짜,시간
    public string name;
    public string [] season= new string[2];
    public int [] date= new int[3];
    public string [] hour= new string[2];
}
public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();

    public string path;
    
    public int nowSlot;
     private void Awake() {
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        path= Application.persistentDataPath+"/save" ;
    }
    
    void Start()
    {
        
    }

    
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path +nowSlot.ToString(),data);
    }
    public void LoadData()
    {
       string data= File.ReadAllText(path + nowSlot.ToString());
       nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
    public void DataClear(){
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}
