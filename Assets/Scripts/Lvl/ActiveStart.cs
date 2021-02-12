using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveStart : MonoBehaviour
{
    //public GameObject Bot;
    public GameObject[] StartUI;
    public static bool /*Yestrue = false,*/ truePlayerR = false/*, Bot = false*/;
    //public static int BotForeman = 0;

    private void Update()
    {
        if (TruePlayer.trueplayer == true)
        {
            StartUI[0].SetActive(true);
        }
        else
        {
            StartUI[0].SetActive(false);
        }
    }
    public void YesStart()
    {
        //Yestrue = true;
        truePlayerR = true;
        //Bot = true;
        //BotForeman++;
        StartUI[1].SetActive(true);
        StartUI[0].SetActive(false);
        Invoke("NO", .5f);
    }   
    void NO() 
    {
        truePlayerR = false;
        StartUI[1].SetActive(false);        
    }
}
