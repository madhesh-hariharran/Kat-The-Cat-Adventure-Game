using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public GameObject player;
    Transform post;
    Vector3 pos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        post = player.GetComponent<Transform>();
        pos = post.position;
        pos.z = -10;
        gameObject.transform.position = pos;
        

    }
}
