using UnityEngine;

public class Player : MonoBehaviour
{
    //移動
    [SerializeField] private float moveSpeed = 10.0f;

    //ジャンプ
    [SerializeField] private float jumpForce = 15.0f;
    //プレイヤーの足元オブジェクト
    [SerializeField] private Transform GroundCheker;
    //地面チェックする円の半径
    [SerializeField] private float checkerRadius = 0.1f;
    //地面のレイヤー
    [SerializeField] private LayerMask groundLayer;
    //多段ジャンプ防止
    private bool isGround;

    //プレイヤー
    private Rigidbody2D rb;

    private SpriteRenderer sr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }
    private void Walk() 
    { 
        float direction = Input.GetAxisRaw("Horizontal");
        Debug.Log(direction);
        rb.linearVelocityX = direction * moveSpeed; 
        if (direction >= 0) 
        { 
            sr.flipX = false; 
        } else if (direction < 0) 
        { 
            sr.flipX = true;
        }
    }

    private void Jump()
    {
        if (Physics2D.OverlapCircle(GroundCheker.position, checkerRadius, groundLayer))
        {
            isGround = true;
            
        }
        else
        {
            isGround = false;
            
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGround == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           
        }

    }

}