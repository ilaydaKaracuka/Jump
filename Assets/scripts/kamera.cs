using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    
  
    public Transform cam;
    public float sensivity;
    public float maxXRot,minXRot;
    private float curXRot;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; //play de mouse imleci g�z�kmez
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        
    }
 
    void Look()
    {
        float x = Input.GetAxis("Mouse X") * sensivity;
        float y = Input.GetAxis("Mouse Y") * sensivity;
        transform.eulerAngles += Vector3.up * x;  //y ekseninde d�nd�r
        curXRot += y;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot); //curXRot de�erini s�n�rlar 
        cam.localEulerAngles = new Vector3(-curXRot, 0.0f, 0.0f);  //local kendi i�inde yukar� a�a�� d�ner
    }
}
