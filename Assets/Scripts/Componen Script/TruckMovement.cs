using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    private bool move;
    public float  spd = 50;
    bool canstart;
    [SerializeField]Rigidbody2D truckrb;
    public GameObject gameobj;
        
    void Update()
    {
        if (move)
        {
            truckrb.AddForce(-transform.right * spd);
        }     
        
        if(Input.GetKeyDown(KeyCode.LeftControl) && canstart)
        {
            move = true;
            gameobj.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canstart = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canstart = false;
        }
    }    
}
