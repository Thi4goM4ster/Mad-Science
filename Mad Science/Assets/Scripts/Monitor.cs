using UnityEngine;

public class ComputadorSecreto : MonoBehaviour
{
    private GameManagerSecreto gerente;
    private bool pertoDoPc = false;

    void Start()
    {
        // Acha o GameManager automaticamente
        gerente = FindObjectOfType<GameManagerSecreto>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pertoDoPc = true;
            Debug.Log("Pressione E para interagir com o PC.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pertoDoPc = false;
        }
    }

    void Update()
    {
        // Se o jogador apertar E perto do PC
        if (pertoDoPc)
        {
            // Avisa o gerente para tentar ler a próxima mensagem
            gerente.TentarInteragir();
        }
    }
}
