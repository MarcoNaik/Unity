using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Transform player;
    private Vector3 startPos = new Vector3(0 , 4 , -2);


    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position;
        newPos += startPos;

        transform.position = newPos ;
    }
}
