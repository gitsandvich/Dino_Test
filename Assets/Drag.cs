using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour{   
    public GameObject detector;
    Vector3 fossil_awal, scale_awal;
    bool on_fossil = false;
    // Use this for initialization
    void Start()
    {
        fossil_awal = transform.position;
        scale_awal = transform.localScale;
    }

    void OnMouseDrag()
    {
        Vector3 fossil_mouse = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y, Input.mousePosition.z));
        transform.position = new Vector3 (fossil_mouse.x, fossil_mouse.y, -1f);
        transform.localScale = new Vector2 (1f,1f);
    }

    void OnMouseUp()
    {
        if(on_fossil)
        {
           transform.position = detector.transform.position;
           transform.localScale = new Vector2 (1f,1f);
        }
        else
        {
           transform.position = fossil_awal;
           transform.localScale = scale_awal;
        }
    }
    void OnTriggerStay2D(Collider2D objek)
    {
        if (objek.gameObject == detector)
        {
            on_fossil = true;
        }
    }

    void OnTriggerExit2D(Collider2D objek)
    {
        if (objek.gameObject == detector)
        {
            on_fossil = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
