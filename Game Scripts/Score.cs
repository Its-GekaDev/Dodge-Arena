using UnityEngine;
using TMPro;
public class Pontuacao : MonoBehaviour
{
    // Variables
    private float tempo;
    private bool JogoAtivo;
    public TextMeshProUGUI Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JogoAtivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        // this part is the timer of the game
        if (JogoAtivo)
        {
            tempo += Time.deltaTime * 1f;
            Text.text = "Tempo Passado " + Mathf.RoundToInt(tempo) + " Segundos";
        }
    }
}
