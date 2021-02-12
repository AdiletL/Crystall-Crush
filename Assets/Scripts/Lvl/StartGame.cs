using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject Background;
    [SerializeField] PlayerControll _playercontroller;
    [SerializeField] MainCamera _maincamera;
    private void Start()
    {
        if (PlayerPrefs.GetInt("StartGame") !=0)
        {
            Background.SetActive(false);
            _playercontroller.enabled = true;
            _maincamera.enabled = true;
        }
    }
   public void StartingGame() { _playercontroller.enabled = true; _maincamera.enabled = true; PlayerPrefs.SetInt("StartGame", 1); Background.SetActive(false); }
}
