using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controler;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    void Update()
    {
       horizontalMove=  Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }
     void FixedUpdate()
    {
        controler.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}
