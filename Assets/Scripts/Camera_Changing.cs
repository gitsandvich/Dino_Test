using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Changing : MonoBehaviour
{
    public GameObject AR,Main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Camera_AR_Off()
    {
        
        Main.SetActive(true);
        AR.SetActive(false);
    }
    public void Camera_AR_On()
    {
        
        Main.SetActive(false);
        AR.SetActive(true);
    }
}
