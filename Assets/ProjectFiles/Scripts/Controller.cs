using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Controller : MonoBehaviour
{

    public Color RayColor = Color.green;
    public float friction = 0;
    public float MoveSpeed = 5;
    public int Accel = 12;
    public int JumpHeight = 8;
    public int RayDistance = 0;
    public int JumpSpeed = 8;

    private bool OnGround = false;
    private bool JumpOn = false;
    
    private Rigidbody2D Rb;

    void Awake() {Rb = GetComponent<Rigidbody2D>();}
    void Start(){}

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RayDistance, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * RayDistance, RayColor);

        if (hit.collider != null)
        {
            float Angle = Vector2.Angle(Vector2.down, hit.normal) - 180;

            if (Angle > 15) {
                RayColor = Color.red; 

            }
            else {RayColor = Color.green;}

            if (hit.collider.gameObject.tag == "Ground")
            {

                Vector2 PlatformCord = new Vector2(0, hit.collider.bounds.max.y);
                Vector2 Player = new Vector2(0, transform.position.y);

                float Magnitude = Vector2.Distance(PlatformCord, Player);
                Debug.Log("Distance:" + Magnitude * 10 );
                
            }
            else
            {

            }
             

            }
        else
        {
             
        }

        }
    
    void FixedUpdate()
    {
        float hA = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float vA = Input.GetAxisRaw("Vertical") * JumpSpeed;

        if (hA > 0)
        {
            Rb.AddForce(Vector2.right * hA * Time.deltaTime * 10, 0);
        }

        if (hA < 0)
        {
            Rb.AddForce(new Vector2(1, 0));
        }

        float Jump = JumpHeight * Rb.mass * 10;
 
        if (Input.GetButtonDown("Jump"))
            {
            // float Direction = transform.position - lastposition;
            Rb.AddForce(Vector2.up * Jump * Time.deltaTime);

           
            }
 
     
        

    }



}
        


    

 
   
 
