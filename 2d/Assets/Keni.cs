using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keni : MonoBehaviour
{
    /*private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

    }


    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x,y,0);

        if(moveDelta.x > 0)
            transform.localScale = Vector3.one ;
        else if(moveDelta.x < 0 )
            transform.localScale = new Vector3(-1,1,1);

        //Make sure we can move in this direction, by casting a box there first, if the box return null, we are free to move
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
        if(hit.collider == null)
        {
            //make this thing move!
            transform.Translate(0,moveDelta.y *Time.deltaTime,0);
        }

        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x * Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
        if(hit.collider == null)
        {
            //make this thing move!
            transform.Translate(0,moveDelta.x *Time.deltaTime,0,0);
        }
    }*/


    public float speed = 5f; // oyuncunun hareket hızı
    private Rigidbody2D rb;
    public float jumpForce;
    private Vector2 direction;
    private bool isGrounded = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // oyuncunun Rigidbody bileşenini al
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal"); // oyuncunun hareket yönü
        // Jump if on the ground and the jump button is pressed
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                rb.velocity = Vector2.up * jumpForce;
                isGrounded=false;     
        }
         rb.velocity = new Vector2(move * speed, rb.velocity.y); // oyuncunun hareket yönüne ve hızına göre Rigidbody'yi hareket ettir
    
    
    }
    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

    // Karakterin yönünü belirle
    if (direction.x > 0) {
        transform.localScale = new Vector3(1, 1, 1); // sağa bak
    } else if (direction.x < 0) {
        transform.localScale = new Vector3(-1, 1, 1); // sola bak
    }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") // oyuncu duvara çarptığında
        {
            rb.velocity = Vector2.zero; // oyuncunun hızını sıfırla
        }
        if(collision.gameObject.tag == "Zemin")
        {
            isGrounded = true;
        }
        
    }
}

    


