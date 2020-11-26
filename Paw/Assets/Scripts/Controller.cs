using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public bool SpeedChanged = false;
    public float SpeedReduce;
    public int TreasureAmmount = 5;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" && TreasureAmmount == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
