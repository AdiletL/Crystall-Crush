using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCrystal : MonoBehaviour
{
    private MeshCollider mesh;
    public Crisstal _crisstal;
    private Rigidbody rb;
    private void Start()
    {
        mesh = GetComponent<MeshCollider>();
        mesh.enabled = true;
    }

    private void Update()
    {
          mesh.isTrigger = true;
            if (_crisstal.numberplayer == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, PlayerPos.PosPlayer,  5 * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, EnemyPos.PosEnemy,  5 * Time.deltaTime);
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
