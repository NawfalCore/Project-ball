using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjection : MonoBehaviour
{
    bool shoot=false;//false hai
   public Vector3 target;
    LineRenderer lineRenderer;
    float min=10f;
    float pre=0;
    int i=2;
    public float forwardspeed;
    public Vector3 forwardtrans;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
     rb=GetComponent<Rigidbody>();
     lineRenderer=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if(shoot==false)
        {
          
        }
        if(Input.GetMouseButtonUp(0))
        {
            shoot=true;
            target=lineRenderer.GetPosition(i);
            transform.LookAt(target);
            forwardtrans=transform.forward;
            rb.AddForce(transform.forward*forwardspeed);

        }
        if(shoot)
        {
            pre=Vector3.Distance(transform.position,target);

            transform.LookAt(target);
            Debug.Log("min="+min+" ,pre="+pre);
            if(min<pre)
            {
                Debug.Log("andr");
                i++;
                if(i==lineRenderer.positionCount-1)
                    shoot=false;
                //Debug.Log(" ,i="+i);
                target=lineRenderer.GetPosition(i);
                pre=Vector3.Distance(transform.position,target);
                transform.LookAt(target);
                rb.AddForce(transform.forward*forwardspeed);
            }
            min=pre;

        }
    }
    /* 
    IEnumerator Shootprocess()
    {

    }
    */





}
