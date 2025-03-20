using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetRunState(bool isRunning)
    {
        animator.SetBool("IsRun", isRunning);
    }

    public void SetJumpTrigger()
    {
        animator.SetTrigger("IsJump");
    }
}
