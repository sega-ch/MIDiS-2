using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureTextBox : MonoBehaviour
{
    Controller Controller;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GameObject.Find("Data").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = Controller.TreasureAmmount.ToString();
    }
}
