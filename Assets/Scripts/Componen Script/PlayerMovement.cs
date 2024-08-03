using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float iphorizontal;
    float jumptimecounter;
    float coyotetime = 0.2f;
    float coyotetimecounter;
    float jumpbuffertime = 0.3f;
    float jumpbuffercounter;
    [SerializeField] float jumptime;
    [SerializeField] float maxdistance;
    [SerializeField] float speedhorizontal ;
    [SerializeField] float speedsprint ;
    [SerializeField] float speedvertical ;
    [SerializeField] float impulsevertical;

    Vector2 horizontalmov;
    Vector2 verticalmov;
    [SerializeField] Vector3 boxsize;

    bool ipvertical;
    bool isjumping;
    bool facingright = false;

    GameObject player;
    Rigidbody2D playerrb;
    CapsuleCollider2D boxcoll;
    [SerializeField] LayerMask platformlayermask;
    RaycastHit2D hit;
    
    Vector3 pos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerrb = player.GetComponent<Rigidbody2D>();

        boxcoll = GetComponent<CapsuleCollider2D>();

        horizontalmov = Vector2.zero;
        verticalmov = new Vector2(0f, 1f);
    }    
    private void FixedUpdate()
    {
        playerrb.velocity = new Vector2(horizontalmov.x * speedhorizontal * Time.deltaTime, playerrb.velocity.y);
    }
    void Update()
    {
        //print(IsGrounded());
        iphorizontal = Input.GetAxis("Horizontal") ;
        horizontalmov.x = iphorizontal;

        if (iphorizontal > 0 && !facingright)
        {
            transform.Rotate(0f, 180f, 0f);
            facingright = true;
        }            
        else if (iphorizontal < 0 && facingright)
        {
            transform.Rotate(0f, 180f, 0f);
            facingright = false;
        }
        ipvertical = Input.GetKeyDown("space");      
        
        if(IsGrounded())
        {
            coyotetimecounter = coyotetime;           
        }
        else
        {
            coyotetimecounter -= Time.deltaTime;                        
        }
        if (ipvertical)
        {
            jumpbuffercounter = jumpbuffertime;
        }
        else
        {
            jumpbuffercounter -= Time.deltaTime;
        }
        if ( coyotetimecounter> 0f   && jumpbuffercounter >0f)
        {
            isjumping = true;
            jumptimecounter = jumptime;
            jumpbuffercounter = 0f;
            playerrb.AddForce(Vector2.up * (impulsevertical+(-playerrb.velocity.y)), ForceMode2D.Impulse);
        }
        if(Input.GetKey("space") && isjumping == true)
        {
            if(jumptimecounter > 0)
            {
                playerrb.AddForce(Vector2.up * speedvertical, ForceMode2D.Force);
                jumptimecounter -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }
        }
        if (Input.GetKeyUp("space"))
        {
            isjumping = false;
            coyotetimecounter = 0f;
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position - transform.up * maxdistance, boxsize);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -transform.up*maxdistance);
    }   
    private bool IsGrounded()
    {        
        /*
         if (Physics2D.BoxCast(transform.position,boxsize,angle , - transform.up , maxdistance, platformlayermask))
         {
             return true;
         }
        */
       if(Physics2D.Raycast(transform.position,-transform.up,maxdistance,platformlayermask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }     
}




 


















