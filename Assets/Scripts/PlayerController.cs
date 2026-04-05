using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    Rigidbody2D playerRB;
    Animator playerAnim;

    private bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRB.linearVelocity = new Vector2(horizontalInput, verticalInput) * 5f;

        
        ChangeDirection();

    }

    void Update()
    {
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            playerAnim.SetBool("isRunning", true);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            StartCoroutine(Attack());
        }

    }
    IEnumerator Attack()
    {
        isAttacking = true;
        playerAnim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        isAttacking = false;

    }

    void ChangeDirection()
    {
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }
}
