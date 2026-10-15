using UnityEngine;

// Player script managing character movement based on horizontal keyboard input
public class Player : MonoBehaviour
{
    // Reference to the CharacterController component handling collisions and movement
    private CharacterController characterController;
    
    // Vector holding the directional movement input values
    private Vector3 Vector3Player;
    
    // Movement speed multiplier for the player
    public float Velocidade;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Cache the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Capture horizontal input (A/D or Left/Right arrows) and assign it to the X axis
        Vector3Player = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        
        // Move the player character using the input vector, speed, and delta time for smooth motion
        characterController.Move(Vector3Player * Time.deltaTime * Velocidade);
    }
}
