using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    private bool PlayerTr;
    private Animation animat;
    public BonusEarth[] earthCrystall;
    private int number;
    private float tinimg;
    public static bool BoostCrystal;
    private void Start()
    {
        animat = GetComponent<Animation>();
    }
    private void Update()
    {
        if (PlayerTr == true)
        {
            tinimg += Time.deltaTime;
            if (tinimg >= 2) 
            {
                gameObject.layer = 9;
            }
        }
    }
    private void DestroyBonus() { Destroy(gameObject); }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   BoostCrystal = true;
            if (PlayerTr == false)
            {
                animat.Play();
                PlayerTr = true;
            }
        }
        if (other.CompareTag("weapon"))
        {
            
            if (number == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    earthCrystall[i].enabled = true;number++;
                }
            }
            else
            {
                for (int i = 7; i < 12; i++)
                {
                    earthCrystall[i].enabled = true;
                    if (earthCrystall[11].enabled == true)
                    {
                        Invoke("DestroyBonus", 1.5f);
                    }
                }
            }

        }
    }
}
