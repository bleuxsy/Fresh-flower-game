using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject creat;
    public Text[] slotText;
    bool[] savefile= new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<4; i++)
        {
         if( File.Exists(DataManager.instance.path+ $"{i}"))
            {
                savefile[i] = true;
             DataManager.instance.nowSlot =i;
             DataManager.instance.LoadData();
             slotText[i].text = DataManager.instance.nowPlayer.name;
           
             }
         else
            {
             slotText[i].text = "비어있음";
            }
        }
        DataManager.instance.DataClear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Slot(int number){
        DataManager.instance.nowSlot = number;
        if(savefile[number]){
            DataManager.instance.LoadData();
            GoGame();
        }
        
        
    }
    public void Creat(){
        creat.gameObject.SetActive(true);
    }
    public void GoGame(){
       if(savefile[DataManager.instance.nowSlot]){
        SceneManager.LoadScene(1);
       }
    }
}
