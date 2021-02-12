using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruePlayer : MonoBehaviour
{
    public BoxCollider boxcoll;
    [SerializeField] GameObject StartObj;
    [SerializeField] GameObject[] Location;
    public static bool trueplayer = false;
        public int  numberLocation;

    private void Start()
    {
        if (PlayerPrefs.GetInt("numberLocation") == numberLocation)
        {
            StartObj.SetActive(true);
            boxcoll.isTrigger = false;
        }
    }

    private void Update()
    {
        if (ActiveStart.truePlayerR == true)
        {

            StartObj.SetActive(true); 
            for (int i = 0; i < Location.Length; i++)
            {
              Destroy(Location[i]);
            }
             trueplayer = false; boxcoll.isTrigger = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (boxcoll.isTrigger == true)
            {
                PlayerPrefs.SetInt("numberLocation", numberLocation);
                Debug.Log(numberLocation);
                trueplayer = true;
            }
            else
            {
                trueplayer = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trueplayer = false;  
        }
    }
}
