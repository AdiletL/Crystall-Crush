 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpenAI : MonoBehaviour
{
  private NavMeshAgent agent;
    private Animator _animator;
    public BoxCollider _boxcollider;
    public Transform /*player,*/ PosHit;
    //public GameObject EndCheck, Foreman;
   /* public GameObject[] End, Foreman;
    private Vector3 _checkbox;
    public float dist, maxdist;
    public static int score;
    public ParticleSystem[] _emojy;
    public LayerMask crystall, Player;
    public bool  m_Detec;
    public static float enemydamage = 3;
    public static bool EmojyAngry;
    RaycastHit hit;

    private void Start()
    {   
        _checkbox = new Vector3(.3f, 0.3f, .3f);
        //player = GameObject.Find("Player");
        //EndCheck = GameObject.FindGameObjectWithTag("EndBot");
        //Foreman = GameObject.FindGameObjectWithTag("Foreman");
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _emojy[0].Play();
    }
    private void Update()
    {
        if (score <= 500)
        {
            if (Physics.CheckBox(transform.localPosition, _checkbox, transform.localRotation, crystall))
            {
                agent.speed = 0;
                _boxcollider.enabled = true;
                _animator.SetInteger("Anim", 2);
                if (Physics.CheckBox(transform.localPosition, _checkbox, transform.localRotation, Player))
                {
                    EmojyAngry = true;
                    _emojy[2].Play();
                }
                else
                {
                    EmojyAngry = false;
                }
            }
            else
            {
                _boxcollider.enabled = false;
                agent.speed = 2;
                agent.SetDestination(End[0].transform.position);
                transform.LookAt(End[0].transform.position);
                _animator.SetInteger("Anim", 1);
            }
        }
        else if (score >= 500)
        {
            if (Physics.CheckBox(transform.localPosition, _checkbox, transform.localRotation, crystall))
            {
                agent.speed = 0;
                _boxcollider.enabled = true;
                _animator.SetInteger("Anim", 2);
            }
            else
            {
                _emojy[0].Play();
                agent.speed = 2;
                agent.SetDestination(Foreman[ActiveStart.BotForeman].transform.position);
                _boxcollider.enabled = false;
                transform.LookAt(Foreman[ActiveStart.BotForeman].transform.position);
                _animator.SetInteger("Anim", 1);
            }
        }

    }
    //private void FixedUpdate()
    //{
    //    Invoke("Distan", 5f);
    //}
    // private void PRS() 
    //{
    //         if (dist < 8)
    //         {
    //        _animator.SetInteger("Anim", 2);
    //         enemydamage = 2;
    //         }
    //         if (dist > 8)
    //         {
    //        _animator.SetInteger("Anim", 4);
    //         enemydamage = 4;
    //         }
    // }
    //private void Distan()
    //{
    //    dist = Vector3.Distance(transform.position, player.transform.position);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lvl1") || other.CompareTag("Lvl2")|| other.CompareTag("Lvl3")|| other.CompareTag("Lvl4") || other.CompareTag("Lvl5")||other.CompareTag("Lvl6")||other.CompareTag("Lvl7"))
        {
            score += 1;
        }

        if (other.CompareTag("Foreman"))
        {
            _emojy[1].Play();
        }
    }
*/
}
