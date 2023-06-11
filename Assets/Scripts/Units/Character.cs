using UnityEngine;
using System.Collections;

public class Character : Unit
{
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private float jumpForce = 15.0F;
    [SerializeField]
    private Transform feetPosition;
    [SerializeField]
    private LayerMask whatIsGround;

    public int idItemInHand;
    public int numberOfSlotHaveItemInHand;

    private bool isGrounded = false;

    public bool GetIsGrounded() { return isGrounded; }


    public GameObject instrument;

    public bool isExtracting = false;


    [SerializeField] private LayerMask enemy;

    public CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        idItemInHand = 0;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
       if (isGrounded && !isExtracting) State = CharState.Idle;

        if (Input.GetButton("Horizontal") && !isExtracting) Run();
        if (isGrounded && Input.GetButtonDown("Jump") && !isExtracting) Jump();

        if (isExtracting) { State = CharState.Loot; }
    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;

        //rotate instrument
        if (direction.x < 0.0F) instrument.transform.rotation = Quaternion.Euler(0, 180, 0);
        else if (direction.x > 0.0F) instrument.transform.rotation = Quaternion.Euler(0, 0, 0);


        if (isGrounded && !isExtracting) State = CharState.Run;
    }

    private void Jump()
    {  
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
      
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, 0.3F, whatIsGround);

        if (!isGrounded) State = CharState.Jump;
    }

    public IEnumerator DoExtract()
    {
        isExtracting = true;

        yield return new WaitForSeconds(4.0f);

        isExtracting = false;
    }

    public override void ReceiveDamage()
    {
        base.ReceiveDamage();
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 6.5F, ForceMode2D.Impulse);
    }

}

public enum CharState
{
    Idle,
    Run,
    Jump,
    Loot
}
