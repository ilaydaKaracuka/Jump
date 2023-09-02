using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yosun : MonoBehaviour
{
  
    public float speed;
    public Vector3 vect;
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        speed = 30;
        vect=new Vector3(0f, 0f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vect * speed * Time.deltaTime);

       // timer += Time.deltaTime;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="carp")
        {
            print("carp");
          
            vect = new Vector3(0f, 0f, -2f);
        }
        if (other.gameObject.tag == "carp2")
        {
            print("carp2");
            vect = new Vector3(0f, 0f, 2f);

        }
    }


}
