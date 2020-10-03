using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //GameObject rad1, rad2, rad3, rad4;
    public bool SpeedChanged = false;
    public float SpeedReduce;
    public int TreasureAmmount = 5;
    //SceneTransfer SceneTransfer;

    void Start()
    {
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
}
