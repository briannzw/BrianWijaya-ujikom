using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sfxEat;
    [SerializeField] private AudioClip sfxDestroy;
    [SerializeField] private GameObject vfxDestroy;
    private ScoreManager scoreManager;

    [Header("UI References")]
    [SerializeField] private Image hungerFill;

    [Header("Animal")]
    [SerializeField] private Animal animal;

    private float hunger = 0;

    private void Start()
    {
        // Speed Adjustment
        animal.Speed /= 50;
        rb.velocity = transform.forward * animal.Speed;
    }

    public void Initialize(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    public void Hit(float value)
    {
        hunger += value;

        hungerFill.fillAmount = hunger / animal.HungerNeeded;

        audioSource.PlayOneShot(sfxEat);
        if(hunger >= animal.HungerNeeded)
        {
            hunger = animal.HungerNeeded;

            // Add Score
            scoreManager.Add(animal.Score);

            AudioSource.PlayClipAtPoint(sfxDestroy, transform.position);
            //Instantiate(vfxDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall")) Destroy(gameObject);
    }
}
