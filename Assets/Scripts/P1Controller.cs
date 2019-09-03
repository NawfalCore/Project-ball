using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    bool mousehold=false;
    Vector3 firstClickPos;
    Vector3 NewPoint;
    Vector3 pos;
    public float InputSmothness;
    public float speed;
    void Start()
    {
        pos.y=8f;
    }

    // Update is called once per frame

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
             mousehold=true;
            firstClickPos=(Input.mousePosition);
        }
        if(Input.GetMouseButtonUp(0))
        {
            mousehold=false;
        }
        if(mousehold)
        {
            Debug.Log("mousehold true");
            NewPoint=(Input.mousePosition);
            float difference=NewPoint.x-firstClickPos.x;
            pos.x=difference/InputSmothness;
            pos.x = Mathf.Clamp(pos.x*Time.fixedDeltaTime*speed,-InputSmothness,InputSmothness);
           // print(pos.x);
           
            pos.y=Projection.Instance.getGenericPositionOfP1y();
            pos.z=Projection.Instance.getGenericPositionOfP1z();
            gameObject.transform.localPosition = pos;
        }
        
    }
}
