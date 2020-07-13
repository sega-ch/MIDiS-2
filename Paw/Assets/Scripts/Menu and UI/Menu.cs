using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Controller Controller;
    public GameObject Cam;
    public Text MenuText;

    // Start is called before the first frame update
    void Start()
    {
        Controller = Cam.GetComponent<Controller>();
        if(SceneTransfer.ScoreInt > 0){
            MenuText.text = "Сокровищ найдено на " + SceneTransfer.ScoreInt.ToString() + " колбасок";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnClick(){
        if(SceneTransfer.TreasureAmmount > 0)SceneTransfer.TreasureAmmount += 1;
        //Controller.TreasureAmmount+=1;
        SceneManager.LoadScene("Level1");
    }
}
