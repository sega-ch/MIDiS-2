using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockAndTimer : MonoBehaviour
{
    public GameObject transferBtn;
    Text timer;
    public float timeLeft;
    bool takingAway = false;

    IEnumerator TimerTick(){
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft--;
        if(timeLeft < 10) timer.text = "00:0" + timeLeft.ToString();
        else timer.text = "00:" + timeLeft.ToString();
        takingAway = false;
    }

    // Start is called before the first frame update
    void Start(){
        timer = this.gameObject.GetComponent<Text>();
        if(timeLeft < 10) timer.text = "00:0" + timeLeft.ToString();
        else timer.text = "00:" + timeLeft.ToString();
    }

    // Update is called once per frame
    void Update(){   
        if(takingAway == false && timeLeft > 0){
            StartCoroutine(TimerTick());
        } 
        else if(timeLeft <= 0) transferBtn.SetActive(true);
    }

    public void OnTransferButtonClick(){
        timeLeft = 30;
        if(timeLeft < 10) timer.text = "00:0" + timeLeft.ToString();
        else timer.text = "00:" + timeLeft.ToString();
        transferBtn.SetActive(false);
    }
}
