using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLevelUI : MonoBehaviour
{
    public static bool Restart = false;
    public GameObject PausePnl;
    public GameObject OnLevelUIPnl;
    public static int initialSpawnPointsAmmountOnTheField;
    public static event ActionOnRestart OnRestartButtonClick;
    public delegate void ActionOnRestart(bool restart);
    public GameObject Dog;

    private void Start()
    {
        initialSpawnPointsAmmountOnTheField = AutoAllocator.currentPointsAmmountOnTheField;
        Debug.Log($"{initialSpawnPointsAmmountOnTheField} - thats initial ammount of spawn points");
    }

    public void OnPauseBtnClick()
    {
        PausePnl.SetActive(true);
        OnLevelUIPnl.SetActive(false);
    }

    public void OnContinueBtnClick()
    {
        OnLevelUIPnl.SetActive(true);
        PausePnl.SetActive(false);
    }

    public void OnMainMenuBtnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnRestartBtnClick()
    {
        Debug.Log(Dog.transform.position);
        Dog.transform.position = new Vector3(0, 4.4f, 0);
        Debug.Log(Dog.transform.position);


        foreach (var SpawnPoint in GameObject.FindGameObjectsWithTag("Klad"))
        {
            Destroy(SpawnPoint);
        }

        OnRestartButtonClick(true);

        OnLevelUIPnl.SetActive(true);
        PausePnl.SetActive(false);
    }
}
