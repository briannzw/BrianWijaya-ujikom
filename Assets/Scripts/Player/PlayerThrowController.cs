using UnityEngine;

public class PlayerThrowController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject throwablePrefab;
    [SerializeField] private AudioSource audioSource;

    [Header("Parameters")]
    [SerializeField] private float throwSpeed = 300;
    [SerializeField] private float hungerValue = 25;
    [SerializeField] private Vector3 throwOffset;

    private void Awake()
    {
        // Adjustments
        throwSpeed /= 50;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject throwableObj = Instantiate(throwablePrefab, transform.position + throwOffset, Quaternion.identity);
            throwableObj.GetComponent<FoodController>().Initialize(throwSpeed, hungerValue);

            animator.SetTrigger("Throw");
            audioSource.Play();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + throwOffset, 1f);
    }
}
