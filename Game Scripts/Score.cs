using UnityEngine;
using TMPro;

// Script managing the game timer and updating the UI text display
public class Pontuacao : MonoBehaviour
{
    // Variables
    // Stores the elapsed time of the game
    private float tempo;
    
    // Flag that determines whether the timer should continue running
    private bool JogoAtivo;
    
    // Reference to the TextMeshPro UI component displaying the time
    public TextMeshProUGUI Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the game state as active when the scene starts
        JogoAtivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        // this part is the timer of the game
        // Checks if the game is active before updating time and text
        if (JogoAtivo)
        {
            // Increment elapsed time based on real-world seconds
            tempo += Time.deltaTime * 1f;
            
            // Update the UI text with the rounded integer value of the timer
            Text.text = "Tempo Passado " + Mathf.RoundToInt(tempo) + " Segundos";
        }
    }
}
