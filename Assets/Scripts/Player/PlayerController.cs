using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private float originalMoveSpeed = 5f;
    public float boostSpeed;  // 스피드 부스트 속도
    private bool isBoosting = false;  // 스피드 부스트 상태
    private Vector2 curMovementInput;
    public float jumpPower;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    public Action inventory;
    private Rigidbody rigidbody;
    private AnimationHandler animationHandler;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animationHandler = GetComponent<AnimationHandler>();
        originalMoveSpeed = moveSpeed; // 원래 속도 저장
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }

    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            animationHandler.SetRunState(true);
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            animationHandler.SetRunState(false);
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            animationHandler.SetJumpTrigger();
        }
    }

    public void ActiveSpeedBoost(float duration)
    {
        if (!isBoosting)
        {
            StartCoroutine(ActiveSpeedBoostCoroutine(duration));
        }
    }

    private IEnumerator ActiveSpeedBoostCoroutine(float duration)  // 스피드 부스트 관련 함수
    {
        isBoosting = true;
        moveSpeed *= 4;  // 이동 속도를 조절하고 싶다면 이 부분을 조절,
                         // duration을 조절하고 싶다면 ScriptableObjcet에서 duration을 조절하면 됨
        yield return new WaitForSeconds(duration);
        moveSpeed = originalMoveSpeed;  // 원래 속도로 복귀
        isBoosting = false;
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;

    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.3f, groundLayerMask))
            {
                return true;
            }
        }

        return false;

    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle? CursorLockMode.None :  CursorLockMode.Locked;
        canLook = !toggle;
    }

    public void OnJumpPad(float jumpForce)
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
