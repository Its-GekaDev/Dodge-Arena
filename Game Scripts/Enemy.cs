using UnityEngine;

// AI script controlling enemy movement, lifetime, and collision interaction with the player
public class InimigoIA : MonoBehaviour
{
    // Reference to the CharacterController component used for movement
    private CharacterController characterController;
    
    // Movement speed of the enemy
    public float Velocidade;
    
    // Time before the enemy automatically destroys itself (despawns)
    public float TemmpoDesespawn;
    
    // Reference to the GameOver manager script
    private GameOver gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Cache the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        
        // Schedule the destruction of this enemy object after the specified despawn time
        Destroy(gameObject, TemmpoDesespawn);
        
        // Find the GameOver component in the scene, including inactive objects if necessary
        gameOver = FindAnyObjectByType<GameOver>(FindObjectsInactive.Include);
    }

    // Triggered when the CharacterController hits another collider during movement
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the object collided with has the "Player" tag
        if (hit.gameObject.CompareTag("Player"))
        {
            // Log a message indicating game over
            Debug.Log("GameOver");
            
            // Destroy the player GameObject
            Destroy(hit.gameObject);

            // If the GameOver manager reference exists, trigger its game over function
            if(gameOver != null)
            {
                gameOver.GameOverFunction();
            }
            else
            {
                // Log a message if the GameOver script reference was not found
                Debug.Log("Script não achado");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy backward based on speed and delta time
        characterController.Move(Vector3.back * Velocidade * Time.deltaTime);
        
        // Move the enemy downward to simulate falling or ground alignment
        characterController.Move(Vector3.down * Velocidade * Time.deltaTime);
    }
}
