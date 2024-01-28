using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dichuyen : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private  float speedrun = 10f;
    [SerializeField] private float jumpforce=8f;
    public float leftright;
    public float top;
    public bool ktnhay;
    public bool doujum;
    public Animator aim;
    public SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftright = Input.GetAxisRaw("Horizontal");
        top = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(speedrun * leftright+Time.deltaTime, rb.velocity.y);
        ktswap();
        checknhay();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            ktnhay = true;
        }
    }
    private void ktswap() {
        if (leftright==-1)
        {
            spr.flipX = true;
        }
        else if (leftright==1){
            spr.flipX = false;
        }
        aim.SetFloat("Horizontal", Mathf.Abs(leftright));
    }
    private void checknhay()
    {
        if (ktnhay)
        {
            doujum = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (ktnhay || doujum)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce * top);
                ktnhay = false;
                doujum = !doujum;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("vatcan"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            aim.SetTrigger("die");
        }
    }
    private void loadlv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
