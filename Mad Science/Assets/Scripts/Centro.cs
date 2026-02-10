using UnityEngine;

public class MesaFinal : MonoBehaviour
{
    [Header("Requisitos")]
    public string nomeDoItemNecessario = "AmostraPronta"; // Tem que ser IGUAL ao da Prateleira
    
    [Header("Cena")]
    public GameObject beckerNaMesa; // O objeto do becker que vai aparecer na mesa (começa invisível)
    public GameObject portaDeSaida; // A porta que vai abrir
    public GameObject portaSecreta;
    public GameObject beckerComAndrew; 

    //private bool puzzleCompleto = false;

    private void Start()
    {
        // Garante que o becker da mesa comece invisível
        if (beckerNaMesa != null) beckerNaMesa.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player") && beckerComAndrew.activeInHierarchy)
        {
            beckerComAndrew.SetActive(false);
            beckerNaMesa.SetActive(true);
            portaDeSaida.SetActive(true);
            portaSecreta.SetActive(true);
            //VerificarEntrega();
        }
    }

    /*void VerificarEntrega()
    {
        // Pergunta ao inventário se temos a amostra
        if (GerenciadorInventario.instancia.TemOItem(nomeDoItemNecessario))
        {
            Debug.Log("Amostra entregue! Fase concluída.");

            // 1. Faz o becker aparecer na mesa
            if (beckerNaMesa != null) beckerNaMesa.SetActive(true);

            // 2. Abre a porta
            if (portaDeSaida != null) portaDeSaida.SetActive(false);

            puzzleCompleto = true;
        }
        else
        {
            Debug.Log("Você precisa preparar a amostra na prateleira primeiro.");
        }
    }*/
}
