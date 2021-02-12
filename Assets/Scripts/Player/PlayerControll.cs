using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public BoxCollider _box;
    private Animator _animator;
    public LayerMask crystall;
    [SerializeField]
    private CharacterController CharacContr;
    public FloatingJoystick flot;
    private Glasses _glasses;
    public float speed, timeBoost;
    private float counter;
    private int addTimer;
    private Vector3 moveVect, _checkbox;
    public bool m_Detec, BoostTrue;
    public GameObject particleBoost, weapon, WeaponParticle, HeroEffect;
    public ParticleSystem[] Emojy;
    public int[] score = new int[10], viewCrystal = new int[4], _sprite = new int[10];

    private void Start()
    {
        
        _glasses = GetComponent<Glasses>();
        _checkbox = new Vector3(.35f, 0.3f, .35f);
        _animator = GetComponent<Animator>();
        CharacContr = GetComponent<CharacterController>();
             if (PlayerPrefs.HasKey("PosX") && PlayerPrefs.HasKey("PosY") && PlayerPrefs.HasKey("PosZ"))
            {
                transform.position = new Vector3(PlayerPrefs.GetFloat("PosX"), PlayerPrefs.GetFloat("PosY"), PlayerPrefs.GetFloat("PosZ"));
            }        
    }
    private void Update()
    {
         moveVect = Vector3.zero;
        moveVect.x = flot.horizont() * speed;
        moveVect.z = flot.vertic() * speed;
    }
    private void LateUpdate()
    {
        if (Vector3.Angle(Vector3.forward, moveVect)>1f|| Vector3.Angle(Vector3.forward, moveVect) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVect, 1f, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        CharacContr.SimpleMove(moveVect *2.5f);
        if (moveVect.x != 0 || moveVect.z != 0)
        {
            _box.enabled = false;
            _animator.SetInteger("Anim", 1);
            //if (OpenAI.EmojyAngry == true)
            //{
            //    Emojy[1].Play();
            //}
            counter = 0;
        }
        else
        {
            if (m_Detec)
            {
                counter += Time.deltaTime;
                if (BoostTrue == true)
                {
                    _animator.SetInteger("Anim", 4);
                }
                else
                {
                    _animator.SetInteger("Anim", 2);
                }
                if (counter >= 0.3f)
                {
                    _box.enabled = true;
                }
            }
            else
            {
                //transform.LookAt(cristal);
                counter = 0;
                _box.enabled = false;
            _animator.SetInteger("Anim", 3);
            }
        }

        if (BoostTrue == true)
        {
            if (timeBoost < 0)
            {
                WeaponParticle.SetActive(false);
                HeroEffect.SetActive(false); 
                Emojy[3].Play();
                SaveGame.damage -= 8;
                BoostTrue = false;
            }
        }
        else
        {
         timeBoost = 0;
        }
    }
    private void FixedUpdate()
    {
                if (Physics.CheckBox(transform.localPosition, _checkbox, transform.localRotation, crystall))
        {
            m_Detec = true;
        }
        else
        {
            m_Detec = false;
        }
        if (Boost.BoostCrystal == true)
        {
            Emojy[4].Play();
            Boost.BoostCrystal = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lvl1"))
        {
            _sprite[0] = 0;
            viewCrystal[0] = 0;
            score[0] += 1;
        }
        if (other.CompareTag("Lvl2"))
        {
            _sprite[1] = 1;
            viewCrystal[1] = 1;
            score[1] += 1;
        }
        if (other.CompareTag("Lvl3"))
        {
            _sprite[0] = 2;
            viewCrystal[2] = 2;
            score[2] += 1;
        }
        if (other.CompareTag("Lvl4"))
        {
            _sprite[0] = 3;
            viewCrystal[0] = 3;
            score[3] += 1;
        }
        if (other.CompareTag("Lvl5"))
        {
            _sprite[0] = 4;
            viewCrystal[1] = 4;
            score[4] += 1;
        }
        if (other.CompareTag("Lvl6"))
        {
            _sprite[0] = 5;
            viewCrystal[2] = 5;
            score[5] += 1;
        }
        if (other.CompareTag("Lvl7"))
        {
            _sprite[0] = 6;
            viewCrystal[0] = 6;
            score[6] += 1;
        }
        if (other.CompareTag("Lvl8"))
        {
            _sprite[0] = 7;
            viewCrystal[1] = 7;
            score[7] += 1;
        }

        if (other.CompareTag("Boost"))
        {
            BoostTrue = true;
            timeBoost += 30;
            _glasses.BoostImage.maxValue = timeBoost;
           SaveGame.damage += 8;
            Emojy[0].Play();
            HeroEffect.SetActive(true);
            WeaponParticle.SetActive(true);
            
        }
    }

    
}
