using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform player;
    Vector3 starDistance, moveVec;
    private void Start()
    {
        if (PlayerPrefs.HasKey("X") && PlayerPrefs.HasKey("Y") && PlayerPrefs.HasKey("Z"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        }
    starDistance = transform.position - player.position;
    }
    private void Update()
    {
              moveVec = player.position + starDistance;
        //moveVec.y = 8.25f;
    }
    void LateUpdate()
    {//  transform.position = moveVec;
        if (moveVec.x <= -3f)
            moveVec.x = -3f;
        if (moveVec.x >= -0.8f)
        { moveVec.x = -0.8f; }
        transform.position = Vector3.Lerp(transform.position, moveVec, .7f * Time.deltaTime*1.5f);
    }
}
