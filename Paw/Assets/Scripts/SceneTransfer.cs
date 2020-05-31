using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransfer : MonoBehaviour
{
    public static int TreasureAmmount;
    public static int ScoreInt;
    Controller Controller;
    Text Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.Find("Score").GetComponent<Text>();
        Controller = GameObject.Find("Data").GetComponent<Controller>();

        TreasureAmmount = Controller.TreasureAmmount;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {   
            ScoreInt = System.Convert.ToInt32(Score.text);
        }
        catch (System.NullReferenceException)
        {
            
        }
    }
}
