using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float pipeSpeed = 2f;

    public float[] spawnHeights = { 1f, 2f, 3f };

    void Start()
    {
        InvokeRepeating("SpawnPipes", 0f, spawnInterval);
    }

    void SpawnPipes()
    {
    
        float randomY = spawnHeights[Random.Range(0, spawnHeights.Length)];
 
        SpawnPipeAtPosition(randomY);
 
        float oppositeY = -randomY;
 
        SpawnPipeAtPosition(oppositeY);
    }

    void SpawnPipeAtPosition(float yPosition)
    {
 
        Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
 
        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
 
        newPipe.transform.parent = transform;
 
        Rigidbody2D pipeRb = newPipe.GetComponent<Rigidbody2D>();
        pipeRb.velocity = new Vector2(-pipeSpeed, 0f);
    }
}
