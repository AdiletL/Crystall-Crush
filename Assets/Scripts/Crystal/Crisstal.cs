using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crisstal : MonoBehaviour
{
    public List<ActiveCristal> crist = new List<ActiveCristal>();
    public EarthCrystal[] earth;
    public float Playerfullhp, counter;
    //private int num;
    public int numberplayer, valueCristal/*, sum*/;
    //public GameObject[] activcrysstal;
    private bool Droj;
    private BoxCollider _boxcol;
    private Vector3 posCrystal;
    private void Awake()
    {
         posCrystal = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    private void Start()
    {
        _boxcol = GetComponent<BoxCollider>();
       
    }
    private void LateUpdate()
    {
        //num = valueCristal - sum; 
        if (Droj == true)
        {
            transform.position = new Vector3(posCrystal.x + Random.Range(-.05f, .05f), posCrystal.y, posCrystal.z);

        }
        if (crist[8].enabled)
        {
            for (int i = 0; i < 8; i++)
            {
                crist[i].enabled = true;
                EndCrystal();
                counter += Time.deltaTime;
        if (counter >= 1.5f)
        {earth[0].enabled = true;
            if (counter >= 1.6f)
            {earth[1].enabled = true;
                if (counter >= 1.7f)
                {earth[2].enabled = true;
                    if (counter >= 1.8f)
                    {earth[3].enabled = true;
                    }
                }
            }
        }
            }
        }
        }

    private void TriggerWeapon() 
    {
        for (int i = 0; i < valueCristal; i++)
            {
                if (Playerfullhp < SaveGame.damage * i)
                {
                    crist[i].enabled = true;
                       //sum= i;
                }   
            }
    }
    private void PlayDroj()
    {
        Droj = true;
        Invoke("StopDroj", .05f);
    }
    private void StopDroj() { Droj = false; transform.position = posCrystal; }
    private void EndCrystal() 
    {
        if (crist[0].enabled == true)
        {
            _boxcol.enabled = false;
            Invoke("TimingDestroy", 2);
        } 
    }
    private void TimingDestroy()
    {
      Destroy(gameObject); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {PlayDroj();
            numberplayer = 0;
            Playerfullhp = Playerfullhp - SaveGame.damage * 2;
            TriggerWeapon();
            EndCrystal();
        }
        //if (other.CompareTag("WeaponEnemy"))
        //{
        //    numberplayer = 1;
        //    Playerfullhp = Playerfullhp - SaveGame.damage * OpenAI.enemydamage;
        //    TriggerWeapon();
        //    EndCrystal();
        //}
    }
}
