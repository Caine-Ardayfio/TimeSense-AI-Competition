using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Generation : MonoBehaviour
{
    public Text textComponent;

    private int myGen = 0;
    private int myDist = 0;
    private double oldDistance = 300;
    private int convergence = 0;
    private int count = 1;
    void Update(){
        GameObject theCont = GameObject.Find("GA Controller");         
        GAController gController = theCont.GetComponent<GAController>();        
        int gen = gController.myGen;
        double distance = gController.dist;
        //Every 5 seconds
        if(count % 60 == 0){        
            Debug.Log("Distances");
            Debug.Log(oldDistance);
            Debug.Log(distance);            
            if((oldDistance - 1) < distance && convergence == 0){
                convergence = gen;
                Debug.Log("Woo Hoo-we converged at ");
                Debug.Log(convergence);
                
            }
            oldDistance = distance;
            count = 1;
        }
        count++;
        UpdateText(gen,distance);
    }
    void Awake () {
        //If text hasn't been assigned, disable ourselves
        if (textComponent == null)
        {
            Debug.Log("You must assign a text component!");
            this.enabled = false;
            return;
        }
        UpdateText(myGen, myDist);
    }

    void UpdateText (int gen, double distance) {
        //Update the text shown in the text component by setting the `text` variable                        
        textComponent.text = ($"Generation: {gen} - Distance: {distance.ToString("F1")}");
    }
}
