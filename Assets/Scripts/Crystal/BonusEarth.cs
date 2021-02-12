using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEarth : MonoBehaviour
{
    private MeshCollider mesh;
    private float counte;
    private Rigidbody br;
    private void Start()
    {
        mesh = GetComponent<MeshCollider>();
        mesh.enabled = true;
        br = gameObject.AddComponent<Rigidbody>();
        br.AddExplosionForce(4000, transform.position, 10);
    }

    private void Update()
    {
         counte += Time.deltaTime;
        if (counte >= 1f)
        {mesh.isTrigger = true;
            br.useGravity = false;
            transform.position = Vector3.MoveTowards(transform.position, PlayerPos.PosPlayer, 7 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
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
