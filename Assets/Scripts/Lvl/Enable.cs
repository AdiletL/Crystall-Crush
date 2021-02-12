using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject  Location;
    private void OnBecameVisible()
    {
        Location.SetActive(true);
    }
}
