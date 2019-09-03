using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
   public static Projection Instance;
    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
     Vector3 pos;
    Vector3 newpos;
    LineRenderer lr;
    void Awake()
    {
        Instance=this;
    }
    Vector3 p1position;
    

    // Start is called before the first frame 
    void Start()
    {
        p1position=p1.transform.position;
        p1position.z=(p0.transform.position.z+p2.transform.position.z)/2;
        p1position.y=8f;
        p1.transform.position=p1position;//yae
        lr=gameObject.GetComponent<LineRenderer>();
        lr.enabled=false;
        lr.positionCount=10;
    }

    
    // Update is called once per frame
    void Update()    
    {
        if(Input.GetMouseButtonDown(0))
        {
             lr.enabled=true;
        }
        if(Input.GetMouseButtonUp(0))
        {
             //lr.enabled=false;
        }
         if(newpos!=p1.transform.position)
        {
            float t=0;
            for(int i=0;i<10;i++)
            {
                pos.x=((sqr(1-t))*p0.transform.position.x)+((1-t)*t*p1.transform.position.x)+sqr(t)*p2.transform.position.x;
                pos.y=((sqr(1-t))*p0.transform.position.y)+((1-t)*t*p1.transform.position.y)+sqr(t)*p2.transform.position.y;
                pos.z=((sqr(1-t))*p0.transform.position.z)+((1-t)*t*p1.transform.position.z)+sqr(t)*p2.transform.position.z;
                lr.SetPosition(i,pos);
                t+=.1f;
            }
            newpos=p1.transform.position;
        }
    }

    public float getGenericPositionOfP1y()
    {
        return p1position.y;
    }
     public float getGenericPositionOfP1z()
    {
        return p1position.z;
    }

    float sqr(float x)
    {
        return x*x;
    }
    void givePosition()
    {
        
    }




}
