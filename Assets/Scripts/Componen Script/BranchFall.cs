using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchFall : MonoBehaviour
{
    public GameObject boxcoll;
    public GameObject treehinge;
    HingeJoint2D branchhinge;
    int count =0;
    bool cancount = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && cancount == true)
        {
            count += 1;
            cancount = false;
            StartCoroutine(waitjump());
        }        

    }
    
    IEnumerator waitjump()
    {
        yield return new WaitForSeconds(1);
        cancount = true;
    }
    private void Start()
    {        
        branchhinge = gameObject.transform.parent.GetComponent<HingeJoint2D>();
    }
    void Update()
    {
        if(count == 3)
        {
            boxcoll.SetActive(false);
            branchhinge.connectedBody = null;
            branchhinge.enabled = false;
            treehinge.SetActive(false);

        }
        
    }
}
