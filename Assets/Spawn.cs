using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnInterval = 2f;
    public float pipeSpeed = 2f;
    public float spawnHeightRange = 3f; // Adjust the range of random Y positions

    void Start()
    {
        InvokeRepeating("SpawnPipes", 0f, spawnInterval);
    }

    void SpawnPipes()
    {
        // Generate random Y positions for both above and below the player
        float randomY1 = Random.Range(-spawnHeightRange / 2f, spawnHeightRange / 2f);
        float randomY2 = Random.Range(-spawnHeightRange / 2f, spawnHeightRange / 2f);

        // Spawn pipes at the random positions
        SpawnPipeAtPosition(randomY1);
        SpawnPipeAtPosition(randomY2);
    }

    void SpawnPipeAtPosition(float yPosition)
    {
        // Create a new position with the specified Y coordinate
        Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);

        // Instantiate the pipe at the new position
        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        // Set the parent to this transform for organization in the Unity Editor
        newPipe.transform.parent = transform;

        // Access the Rigidbody2D component of the pipe and set its velocity to move left
        Rigidbody2D pipeRb = newPipe.GetComponent<Rigidbody2D>();
        pipeRb.velocity = new Vector2(-pipeSpeed, 0f);
    }
}
