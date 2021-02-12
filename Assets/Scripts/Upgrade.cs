using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
    public static int dd;
    public ParticleSystem particle;
    public TMP_Text _text;
    public PlayerControll play;

    private void Start()
    {
        if (PlayerPrefs.HasKey("dd"))
        {
            dd = PlayerPrefs.GetInt("dd");
        }
            _text.text = " " + CostCrystal.costWeaponText[dd];
    }
    public void UpgradeClick()
    {
        switch (0)
        {
              case 0:
                if (CostCrystal.costWeapon[dd] <= Glasses.Gold && Glasses.Gold != 0)
                {
                    SaveGame.damage+=2;
                    particle.Play();
                    play.Emojy[0].Play();
                    Glasses.PointCrystall = Glasses.PointCrystall - CostCrystal.costWeapon[dd];
                    Glasses.Gold = Glasses.Gold - CostCrystal.costWeapon[dd];
                    dd++;
                    PlayerPrefs.SetInt("dd", dd);
                }
                else
                {
                    play.Emojy[1].Play();
                }
                break;
        }_text.text = " " + CostCrystal.costWeaponText[dd];
    }
}
