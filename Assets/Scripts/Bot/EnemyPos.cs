using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPos : MonoBehaviour
{
    public static Vector3 PosEnemy;
    private void LateUpdate()
    {
        PosEnemy = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
