using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //GameObject rad1, rad2, rad3, rad4;
    public bool SpeedChanged = false;
    public float SpeedReduce;
    public int TreasureAmmount;

    //treasure editor's here to reset score
    TreasureEditor treasureEditor;
    //SceneTransfer SceneTransfer;

    void Start()
    {
        //treasure editor's here to reset score
        treasureEditor = GameObject.Find("Data").GetComponent<TreasureEditor>();

        OnLevelUI.OnRestartButtonClick += OnRestartBtnClick;
        TreasureAmmount = OnLevelUI.initialSpawnPointsAmmountOnTheField;
        if (SceneTransfer.TreasureAmmount > 0) TreasureAmmount = SceneTransfer.TreasureAmmount;
    }

    void Update()
    {
        //if(TreasureAmmount < 0) TreasureAmmount = 0;
        if (SceneManager.GetActiveScene().name == "Level1" && TreasureAmmount == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }


    //Event that works when u click on restart button in "level menu"
    void OnRestartBtnClick(bool restart)
    {
        TreasureAmmount = OnLevelUI.initialSpawnPointsAmmountOnTheField;

        //treasure editor's here to reset score
        treasureEditor.score = 0;
    }
}
