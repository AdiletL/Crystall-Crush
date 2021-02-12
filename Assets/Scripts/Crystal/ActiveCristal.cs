using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCristal : MonoBehaviour
{
    private MeshCollider mesh;
    private bool fd;
    private float  counter;
    public Crisstal _crisstal;
    private Rigidbody rb;
    private void Start()
    {
        mesh = GetComponent<MeshCollider>();
        mesh.enabled = true;
        rb = gameObject.AddComponent<Rigidbody>();
            rb.mass = .01f; ;
            rb.AddExplosionForce(10, transform.position, 10);
    }
    
    private void Update()
    {
         counter += Time.deltaTime;
            if (counter >= 1.5f)
            {
            fd = true;
            rb.useGravity = false;
            mesh.isTrigger = true;
            if (_crisstal.numberplayer == 0)
            {
               transform.position = Vector3.MoveTowards(transform.position, PlayerPos.PosPlayer, 6 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, EnemyPos.PosEnemy, 6 * Time.deltaTime);
            }
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (fd == true)
        {
            if (other.CompareTag("Player"))
            {
                gameObject.SetActive(false);
            }
            if (other.CompareTag("Enemy"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
