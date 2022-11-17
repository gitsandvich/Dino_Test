using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtManager : MonoBehaviour
{
    public GameObject[] Dirts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ResetCaller()
    {
        for(int i = 0; i < Dirts.Length;i++)
        {
            Dirts[i].GetComponent<new_scratch>().ResetDirt();
        }
        
    }
    
}
