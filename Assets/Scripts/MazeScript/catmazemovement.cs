using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catmazemovement : MonoBehaviour
{
    Transform trans;
    Rigidbody2D rb;
    [SerializeField] int movespeed;
    private void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * movespeed;   
    }
}
