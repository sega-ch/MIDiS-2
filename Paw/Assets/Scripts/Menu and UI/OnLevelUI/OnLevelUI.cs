using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelUI : MonoBehaviour
{
    public GameObject PausePnl;
    public GameObject OnLevelUIPnl;


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
}
