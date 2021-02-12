using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Glasses : MonoBehaviour
{
    public int  zero;
    public bool foreman;
    public float[] scorePlayer = new float[10];
    public static int  pl, goldUp,Gold,  hold,PointCrystall;
    public GameObject UpgradeWeapon;
    public TMP_Text[] _text;
    public GameObject[] textGame, Animation_Crystal, UIPlayer;
    public PlayerControll play;
    //public ForemanEmojy _foremanemojy;
    public Upgrade _upgrade;
    public Animation[] _animation;
    public Sprite[] _CrysSprite;
    public Slider BoostImage;
    public Image[] _CrysImage;
    private void Start()
    {
        play = GetComponent<PlayerControll>();
    }

    private void Update()
    { 
        if (play.BoostTrue == true)
        {
            play.timeBoost -= Time.deltaTime;
            textGame[3].SetActive(true);
            BoostImage.value = play.timeBoost;
            _text[4].text = "Boost: " + Mathf.Round(play.timeBoost).ToString();
        }
        else
        {
            textGame[3].SetActive(false);
        }
        if (play.score[play.viewCrystal[0]] >= 60)
        {
            textGame[0].SetActive(true);
            scorePlayer[play.viewCrystal[0]]++;
            PointCrystall += CostCrystal.cost[play.viewCrystal[0]];
            Pointscore();
            _CrysImage[0].sprite = _CrysSprite[play.viewCrystal[0]];
           play.score[play.viewCrystal[0]] = 0;
        }_text[1].text = scorePlayer[play.viewCrystal[0]].ToString();
        if (play.score[play.viewCrystal[1]] >= 60)
        {
            textGame[1].SetActive(true);
            scorePlayer[play.viewCrystal[1]]++;
            PointCrystall += CostCrystal.cost[play.viewCrystal[1]];
            Pointscore();
            _CrysImage[1].sprite = _CrysSprite[play.viewCrystal[1]];
            play.score[play.viewCrystal[1]] = 0;
        }
         _text[2].text =scorePlayer[play.viewCrystal[1]].ToString();
        if (play.score[play.viewCrystal[2]] >= 60)
        {
            textGame[2].SetActive(true);
            scorePlayer[play.viewCrystal[2]]++;
            PointCrystall += CostCrystal.cost[play.viewCrystal[2]];
            Pointscore();
            _CrysImage[2].sprite = _CrysSprite[play.viewCrystal[2]];
            play.score[play.viewCrystal[2]] = 0;
        }
        _text[3].text =scorePlayer[play.viewCrystal[2]].ToString();
        if (foreman == true)
        {
                scorePlayer[0] = 0;
                scorePlayer[1] = 0;
                scorePlayer[2] = 0;
                scorePlayer[3] = 0;
                scorePlayer[4] = 0;
                scorePlayer[5] = 0;
                scorePlayer[6] = 0;
                scorePlayer[7] = 0;
                scorePlayer[8] = 0;
                scorePlayer[9] = 0;
                scorePlayer[10] = 0;
            Gold = PointCrystall;  
        } hold = Gold; _text[0].text =" " + GetSuffixValue();
        string GetSuffixValue() { int zero = 0;
            while (hold >= 1000) { ++zero; hold /= 1000; } string suffinx = string.Empty;
            switch (zero) { case 1: suffinx = "K"; break; case 2: suffinx = "M"; break; case 3: suffinx = "B"; break; case 4: suffinx = "T"; break; case 5: suffinx = "P"; break; } return $"{hold:0.##}{suffinx}";
        }
    }
    private void Pointscore() { _animation[0].Play("cr 1"); }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Foreman"))
        {
            foreman = true;
            if (Gold < PointCrystall)
            {
            //_foremanemojy.emojy.Play();
            play.Emojy[0].Play();
            }
        }
        if (collision.CompareTag("Upgrade"))
        {
            UpgradeWeapon.SetActive(true);
        }
        if (collision.CompareTag("Enemy"))
        {
            play.Emojy[1].Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Foreman"))
        {
            foreman = false;
        }
        if (other.CompareTag("Upgrade"))
        {
            UpgradeWeapon.SetActive(false);
            _upgrade.particle.Stop();
        }
    }
} 