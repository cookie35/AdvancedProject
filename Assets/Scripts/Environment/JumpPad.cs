using UnityEngine;

// 점프대 구현 (ForceMode, Impulse 사용) 

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // 점프 높이
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>(); 
            player.OnJumpPad(jumpForce);  // // 플레이어컨트롤러에 있는 OnJumpPad 메서드 발동

            animator.SetTrigger("IsJump");  // 애니메이션 실행
        }
    }

}
