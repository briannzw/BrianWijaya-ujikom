using UnityEngine;

public class FoodController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float lifetime = 3;

    private float speed;
    private float hungerValue;

    public void Initialize(float speed, float hungerValue)
    {
        this.speed = speed;
        this.hungerValue = hungerValue;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            other.GetComponent<AnimalController>().Hit(hungerValue);
            Destroy(gameObject);
        }
    }
}
