using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public PlayerControll _player;
    public Glasses _glasses;
    public GameObject _PlayerPos, _MainCamera;
    [SerializeField] GameObject[] Location;
    public List<GameObject> CrystallStart;
    public static bool isPaused = true;
    public static float damage = 2;
    private void Awake()
    {// находим все яблоки на сцене
        Location[PlayerPrefs.GetInt("numberLocation")].SetActive(true);
        CrystallStart = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cristal"));
        // загружаем настройки состояния яблок
        load();
        _player.score[0] = PlayerPrefs.GetInt("score0");
        _player.score[1] = PlayerPrefs.GetInt("score1");
        _player.score[2] = PlayerPrefs.GetInt("score2");
        _player.score[3] = PlayerPrefs.GetInt("score3");
        _player.score[4] = PlayerPrefs.GetInt("score4");
        _player.score[5] = PlayerPrefs.GetInt("score5");
        _player.score[6] = PlayerPrefs.GetInt("score6");
        _player.score[7] = PlayerPrefs.GetInt("score7");
        _player.viewCrystal[0] = PlayerPrefs.GetInt("viewCrystal0");
        _player.viewCrystal[1] = PlayerPrefs.GetInt("viewCrystal1");
        _player.viewCrystal[2] = PlayerPrefs.GetInt("viewCrystal1");
        Glasses.Gold = PlayerPrefs.GetInt("Gold");
        Glasses.PointCrystall = PlayerPrefs.GetInt("PointCrystal");
        _glasses.scorePlayer[0] = PlayerPrefs.GetFloat("ScorePlayer0");
        _glasses.scorePlayer[1] = PlayerPrefs.GetFloat("ScorePlayer1");
        _glasses.scorePlayer[2] = PlayerPrefs.GetFloat("ScorePlayer2");
        _glasses.scorePlayer[3] = PlayerPrefs.GetFloat("ScorePlayer3");
        _glasses.scorePlayer[4] = PlayerPrefs.GetFloat("ScorePlayer4");
        _glasses.scorePlayer[5] = PlayerPrefs.GetFloat("ScorePlayer5");
        _glasses.scorePlayer[6] = PlayerPrefs.GetFloat("ScorePlayer6");
        _glasses.scorePlayer[7] = PlayerPrefs.GetFloat("ScorePlayer7");
        if (PlayerPrefs.HasKey("Damage"))
        {
            damage = PlayerPrefs.GetFloat("Damage");
        }
    }
    public void load()
    {
        // если строка с состояниями яблок уже сохранена, то удаляем то яблоко,
        // индекс которого в сохранённой строке равен 0.
        string CrystalStatePrefs = PlayerPrefs.GetString("CrystallStates");
        if (CrystalStatePrefs.Length != 0)
        {
            for (int i = 0; i < CrystalStatePrefs.Length; i++)
            {
                if (CrystalStatePrefs[i] == '0') Destroy(CrystallStart[i]);
            }
        }
        string LocationPrefs = PlayerPrefs.GetString("LocationStates");
        if (LocationPrefs.Length != 0)
        {
            for (int i = 0; i < LocationPrefs.Length; i++)
            {
                if (LocationPrefs[i] == '0') Destroy(Location[i]);
            }
        }
    }
    public void save()
    {
        // пробегамеся по массиву яблок и создаём строку, в которой 0 - яблока уже нет, 1 - яблоко есть
        // и сохраняем эту строку
        string CrystallStates = "";
        for (int i = 0; i < CrystallStart.Count; i++)
        {
            if (CrystallStart[i] != null) CrystallStates += "1";
            else CrystallStates += "0";
        }
        PlayerPrefs.SetString("CrystallStates", CrystallStates);
        string LocationStates = "";
        for (int i = 0; i < Location.Length; i++)
        {
            if (Location[i] != null) LocationStates += "1";
            else LocationStates += "0";
        }
        PlayerPrefs.SetString("LocationStates", LocationStates);
    }
    private void SaveG() {
        save();
        PlayerPrefs.SetFloat("PosX", _PlayerPos.transform.position.x);
        PlayerPrefs.SetFloat("PosY", _PlayerPos.transform.position.y);
        PlayerPrefs.SetFloat("PosZ", _PlayerPos.transform.position.z);
        PlayerPrefs.SetFloat("X", _MainCamera.transform.position.x);
        PlayerPrefs.SetFloat("Y", _MainCamera.transform.position.y);
        PlayerPrefs.SetFloat("Z", _MainCamera.transform.position.z);
        PlayerPrefs.SetInt("score0", _player.score[0]);
            PlayerPrefs.SetInt("score1", _player.score[1]);
            PlayerPrefs.SetInt("score2", _player.score[2]);
            PlayerPrefs.SetInt("score3", _player.score[3]);
            PlayerPrefs.SetInt("score4", _player.score[4]);
            PlayerPrefs.SetInt("score5", _player.score[5]);
            PlayerPrefs.SetInt("score6", _player.score[6]);
            PlayerPrefs.SetInt("score7", _player.score[7]);
            PlayerPrefs.SetInt("viewCrystal0", _player.viewCrystal[0]);
            PlayerPrefs.SetInt("viewCrystal1", _player.viewCrystal[1]);
            PlayerPrefs.SetInt("viewCrystal1", _player.viewCrystal[2]);
            PlayerPrefs.SetInt("Gold", Glasses.Gold);
            PlayerPrefs.SetInt("PointCrystal", Glasses.PointCrystall);
            PlayerPrefs.SetFloat("ScorePlayer0", _glasses.scorePlayer[0]);
            PlayerPrefs.SetFloat("ScorePlayer1", _glasses.scorePlayer[1]);
            PlayerPrefs.SetFloat("ScorePlayer2", _glasses.scorePlayer[2]);
            PlayerPrefs.SetFloat("ScorePlayer3", _glasses.scorePlayer[3]);
            PlayerPrefs.SetFloat("ScorePlayer4", _glasses.scorePlayer[4]);
            PlayerPrefs.SetFloat("ScorePlayer5", _glasses.scorePlayer[5]);
            PlayerPrefs.SetFloat("ScorePlayer6", _glasses.scorePlayer[6]);
            PlayerPrefs.SetFloat("ScorePlayer7", _glasses.scorePlayer[7]);
            PlayerPrefs.SetFloat("Damage", damage); }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveG();

        }
        
    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveG();
        }
    }

    private void OnApplicationQuit()
    {
        SaveG();
    }

}
