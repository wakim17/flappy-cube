using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float pipeSpeed = 2f;

    public float[] spawnHeights = { 1f, 2f, 3f };

    void Start()
    {
        InvokeRepeating("SpawnPipe", 0f, spawnInterval);
    }

    void SpawnPipe()
    {

        float randomY = spawnHeights[Random.Range(0, spawnHeights.Length)];

        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);

        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        newPipe.transform.parent = transform;

        Rigidbody2D pipeRb = newPipe.GetComponent<Rigidbody2D>();
        pipeRb.velocity = new Vector2(-pipeSpeed, 0f);
    }
}
