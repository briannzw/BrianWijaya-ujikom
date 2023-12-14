using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;

    [Header("Parameters")]
    [SerializeField] private float moveSpeed = 350;

    private float moveDirection;

    private void Awake()
    {
        // Adjustments
        moveSpeed /= 50;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        moveDirection = GetMovementAxis();

        // Movement
        transform.position += moveDirection * moveSpeed * Time.deltaTime * transform.right;

        // Animation
        animator.SetFloat("Move", moveDirection);
    }

    private float GetMovementAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }
}
