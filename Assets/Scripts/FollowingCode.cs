using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCode : MonoBehaviour
{
    
    public float speed; 
    private int current;
  

    void Update()
    {
        GameObject theCont = GameObject.Find("GA Controller");         
        GAController gController = theCont.GetComponent<GAController>();
        float targx = gController.targetx[current];        
        float targy = gController.targety[current];
        int tarlen = gController.targetx.Length;
        Vector3 target = new Vector3(targx, targy, 0);    
        if(transform.position != target){            
            Vector3 pos = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime); 
            GetComponent<Rigidbody>().MovePosition(pos);            
        }
        else {
            current = (current + 1) % tarlen;
        }        
        
    }    
    
}
