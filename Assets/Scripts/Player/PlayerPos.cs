using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    public static Vector3 PosPlayer;
    public float x, y, z;
    private void FixedUpdate()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        PosPlayer = new Vector3(x, y, z);
    }

}
