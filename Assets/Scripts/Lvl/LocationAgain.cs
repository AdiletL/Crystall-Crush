using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAgain : MonoBehaviour
{
    public bool locationAgain = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!locationAgain)
            {
SaveGame.damage = 2;
                Upgrade.dd = 0;
                locationAgain = true;
            }
            
        }
    }
}
