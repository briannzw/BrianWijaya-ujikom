using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<GameObject> animalList = new();
    [SerializeField] private ScoreManager scoreManager;

    [Header("Spawn Area")]
    [SerializeField] private float spawnArea;

    [Header("Spawn Values")]
    [SerializeField] private int spawnCount = 1;
    [SerializeField] private float spawnInterval = 2;

    private void OnEnable()
    {
        StartCoroutine(DoSpawn());
    }

    private IEnumerator DoSpawn()
    {
        while (true)
        {
            for(int i = 0; i < spawnCount; i++)
            {
                var animalObj = Instantiate(animalList[Random.Range(0, animalList.Count)], RandomSpawnPos(), transform.rotation);
                animalObj.GetComponent<AnimalController>().Initialize(scoreManager);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 RandomSpawnPos()
    {
        float randomX = Random.Range(-spawnArea / 2, spawnArea / 2);

        return transform.position + new Vector3(randomX, 0f, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea, 1f, 1f));
    }
}
