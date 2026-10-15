using System.Collections;
using UnityEngine;

// Spawner script managing continuous random enemy generation at set time intervals
public class Spawner : MonoBehaviour
{
    // Array holding different enemy prefabs that can be spawned
    public GameObject[] Inimigos;
    
    // Stores the calculated random position vector for spawning
    private Vector3 Vector3Aleatorio;
    
    // Time interval between each enemy spawn wave
    public float TempoSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Begin the continuous spawn loop coroutine when the game starts
        StartCoroutine(LoopDeSpawn());
    }

    // Coroutine that runs an infinite loop to spawn enemies repeatedly based on a time delay
    IEnumerator LoopDeSpawn()
    {
        while (true)
        {
            // Call the method to spawn an enemy
            SpawnarInimigos();
            
            // Wait for the specified spawn time before continuing the loop
            yield return new WaitForSeconds(TempoSpawn);
        }
    }

    // Method that handles random enemy selection and random X position offset calculation
    void SpawnarInimigos()
    {
        // Pick a random index to select an enemy prefab from the array
        int IndiceAleatorio = Random.Range(0, Inimigos.Length);
        
        // Generate a random horizontal position offset within specified bounds
        float PozicaoAleatoria = Random.Range(-3.8f, 3.8f);

        // Calculate the final spawn position by adding the random offset to the spawner's position
        Vector3Aleatorio = transform.position + new Vector3(PozicaoAleatoria, 0, 0);

        // Instantiate the randomly chosen enemy at the calculated position with no rotation
        Instantiate(Inimigos[IndiceAleatorio], Vector3Aleatorio, Quaternion.identity);
    }
}
