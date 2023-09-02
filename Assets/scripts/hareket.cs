using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
public class hareket : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private float timer,timer2,speed;
    public GameObject Z�plamaSesi,YurumeSesi;
    private int can;
    public Canvas canvas, gameover, congrats;
    public Text C;
    private int a;

    public float jumpForce = 10;
    public float groundDistance = 40f;






    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        a = 0;
        timer = 0f;
        can = 3;
        canvas.enabled = true;
        gameover.enabled = false;
        congrats.enabled = false;
        speed = 3;

    }
    private void Update()
    {
        if(GetComponent<BoxCollider>().isTrigger == true) //su �st�ndeyse
        {
            
                timer += Time.deltaTime;
            if (timer >= 5f)  //5 sn ge�tiyse
            {
                GetComponent<Rigidbody>().isKinematic = true; //hareket etmesin
                timer = 0;
            }
            

            



        }
        if (Z�plamaSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)  //1.5 sn ge�tiyse z�plama sesi kapans�n ki tekrar space bast���nda aktif olsun 1.5sn sonra kapans�n...
            {
                Z�plamaSesi.GetComponent<AudioSource>().enabled = false;
                timer = 0;
            }
        }
        if (YurumeSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.77f)  //0.77 sn ge�tiyse yurume sesi kapans�n 
            {
                YurumeSesi.GetComponent<AudioSource>().enabled = false;
                timer = 0;
            }
        }

        if (a==5)   //suya  duserse collision fonksiyonunda a=5 atan�r. suya dusunce yuzme animasyonu
                    //cal�s�r a=5 atan�r a=5 olursa 7sn gectikten sonra gameover paneli ac�l�r
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 7f)  //7 sn ge�tiyse gameover paneli a��ls�n
            {
                gameover.enabled = true; //gameover paneli a��ls�n
                timer2 = 0;
            }
        }

        /*   if (Z�plamaSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer <= 0.2f)  //0.2 sn ge�tiyse yurume sesi kapans�n 
            {
                rb.velocity = Vector3.up * jumpForce;
                timer = 0;
            }
        }
        */
        C.text = can+" "; //texte can say�s�n� g�ncel olarak yazar
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.W)) //ileri ko�
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 132f) * Time.deltaTime); //z de hareket etsin konum de�i�tirsin
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        
        else if (Input.GetKey(KeyCode.S)) //geri ko�
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, -132f) * Time.deltaTime); //z de hareket etsin konum de�i�tirsin
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
       else    //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            animator.SetBool("isRunning", false); //tikli de�ilse dursun

        if (Input.GetKey(KeyCode.A)) //sola
        {
            animator.SetBool("isLeft", true);
            transform.Translate(new Vector3(-132f, 0, 0) * Time.deltaTime);
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        else
            animator.SetBool("isLeft", false);


        if (Input.GetKey(KeyCode.D)) //sa�a
        {

            animator.SetBool("isRight", true);
            transform.Translate(new Vector3(132f, 0, 0) * Time.deltaTime);
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        else
            animator.SetBool("isRight", false);



        
            if (Input.GetKey(KeyCode.Space) ) //Space ile z�pla
            {
            
                animator.SetBool("isJump", true);

                Z�plamaSesi.GetComponent<AudioSource>().enabled = true;
            //rb.AddForce(new Vector3(0, speed, 0)*(-20), ForceMode.Impulse);
            //rb.velocity = Vector3.up * jumpForce;


             }
        else
            animator.SetBool("isJump", false);

        
    }
    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag != "yosun" && col.gameObject.tag != "kurbaga" && col.gameObject.tag != "bitis" && col.gameObject.tag != "carp" && col.gameObject.tag != "carp2" ) //suya d��erse
        {
            GetComponent<BoxCollider>().isTrigger = true;
            animator.SetBool("isPool", true);
            a = 5;

           


        }
        else
         animator.SetBool("isPool", false); 

        if (col.gameObject.tag == "kurbaga")
        {
            can--; 
            if(can==0)
                gameover.enabled = true;

        }

        if (col.gameObject.tag == "bitis")
        {
            animator.SetBool("isFinish", true);
            congrats.enabled = true;


        }
       

    }
   
   
}
