using UnityEngine;
using UnityEngine.SceneManagement; // Biblioteca obrigatória para mexer com cenas

public class PortaFase : MonoBehaviour
{
    [Header("Configuração")]
    [Tooltip("Escreva aqui o nome EXATO da cena para onde quer ir")]
    public string nomeDaProximaCena;
    private LevelLoader loader;

    private void Start()
    {
        // Encontra o LevelLoader automaticamente na cena
        loader = FindObjectOfType<LevelLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se quem pisou na porta foi o Jogador
        if (other.CompareTag("Player"))
        {
            Debug.Log("A carregar a cena: " + nomeDaProximaCena);
            SceneManager.LoadScene(nomeDaProximaCena);
        }
    }
}