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
    public GameObject ZýplamaSesi,YurumeSesi;
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
        if(GetComponent<BoxCollider>().isTrigger == true) //su üstündeyse
        {
            
                timer += Time.deltaTime;
            if (timer >= 5f)  //5 sn geçtiyse
            {
                GetComponent<Rigidbody>().isKinematic = true; //hareket etmesin
                timer = 0;
            }
            

            



        }
        if (ZýplamaSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)  //1.5 sn geçtiyse zýplama sesi kapansýn ki tekrar space bastýðýnda aktif olsun 1.5sn sonra kapansýn...
            {
                ZýplamaSesi.GetComponent<AudioSource>().enabled = false;
                timer = 0;
            }
        }
        if (YurumeSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.77f)  //0.77 sn geçtiyse yurume sesi kapansýn 
            {
                YurumeSesi.GetComponent<AudioSource>().enabled = false;
                timer = 0;
            }
        }

        if (a==5)   //suya  duserse collision fonksiyonunda a=5 atanýr. suya dusunce yuzme animasyonu
                    //calýsýr a=5 atanýr a=5 olursa 7sn gectikten sonra gameover paneli acýlýr
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 7f)  //7 sn geçtiyse gameover paneli açýlsýn
            {
                gameover.enabled = true; //gameover paneli açýlsýn
                timer2 = 0;
            }
        }

        /*   if (ZýplamaSesi.GetComponent<AudioSource>().enabled == true)
        {
            timer += Time.deltaTime;
            if (timer <= 0.2f)  //0.2 sn geçtiyse yurume sesi kapansýn 
            {
                rb.velocity = Vector3.up * jumpForce;
                timer = 0;
            }
        }
        */
        C.text = can+" "; //texte can sayýsýný güncel olarak yazar
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.W)) //ileri koþ
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 132f) * Time.deltaTime); //z de hareket etsin konum deðiþtirsin
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        
        else if (Input.GetKey(KeyCode.S)) //geri koþ
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, -132f) * Time.deltaTime); //z de hareket etsin konum deðiþtirsin
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
       else    //Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            animator.SetBool("isRunning", false); //tikli deðilse dursun

        if (Input.GetKey(KeyCode.A)) //sola
        {
            animator.SetBool("isLeft", true);
            transform.Translate(new Vector3(-132f, 0, 0) * Time.deltaTime);
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        else
            animator.SetBool("isLeft", false);


        if (Input.GetKey(KeyCode.D)) //saða
        {

            animator.SetBool("isRight", true);
            transform.Translate(new Vector3(132f, 0, 0) * Time.deltaTime);
            YurumeSesi.GetComponent<AudioSource>().enabled = true;
        }
        else
            animator.SetBool("isRight", false);



        
            if (Input.GetKey(KeyCode.Space) ) //Space ile zýpla
            {
            
                animator.SetBool("isJump", true);

                ZýplamaSesi.GetComponent<AudioSource>().enabled = true;
            //rb.AddForce(new Vector3(0, speed, 0)*(-20), ForceMode.Impulse);
            //rb.velocity = Vector3.up * jumpForce;


             }
        else
            animator.SetBool("isJump", false);

        
    }
    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag != "yosun" && col.gameObject.tag != "kurbaga" && col.gameObject.tag != "bitis" && col.gameObject.tag != "carp" && col.gameObject.tag != "carp2" ) //suya düþerse
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
