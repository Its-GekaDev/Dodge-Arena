ityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// GameOver script managing the game over state, pause mechanics, and scene restarting
public class GameOver : MonoBehaviour
{
    // Reference to the TextMeshPro UI component for game over text display
    public TextMeshProUGUI GameOverText;
    
    // Reference to the Game Over UI panel/GameObject
    public GameObject gameOver;
    
    // Flag that tracks whether the game has ended
    private bool JogoAcabou;

    // Update is called once per frame
    void Update()
    {
        // Check if the game is over and the player presses the 'R' key to restart
        if (JogoAcabou && Input.GetKeyDown(KeyCode.R)) 
        {
            // Hide the game over panel before reloading
            gameOver.SetActive(false);
            
            // Resume normal game time scale
            Time.timeScale = 1;
            
            // Reload the current active scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Public method triggered when the player dies to activate the game over state
    public void GameOverFunction()
    {
        // Mark the game over flag as true
        JogoAcabou = true;
        
        // Pause all game action by setting time scale to zero
        Time.timeScale = 0;
        
        // Activate and show the game over UI panel
        gameOver.SetActive(true);
    }
}
