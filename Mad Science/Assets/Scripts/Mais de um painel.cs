using UnityEngine;
using TMPro; 

public class DialogoComSetaTexto : MonoBehaviour
{
    [Header("Componentes da UI")]
    public GameObject painelDialogo;      
    public TextMeshProUGUI textoHistoria; // O texto grande da história
    public GameObject objetoSetaTexto;    // O objeto de texto que faz a vez da setinha

    [Header("Configuração")]
    [TextArea(3, 10)] 
    public string[] frases; // Digite suas frases aqui no Inspector

    private int indexAtual = 0; 
    private bool playerPerto = false;
    private bool dialogoAberto = false;

    void Update()
    {
        // Se o player está perto, o diálogo está aberto e aperta Enter
        if (playerPerto && dialogoAberto)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                AvancarTexto();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = true;
            AbrirDialogo();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerPerto = false;
            FecharDialogo();
        }
    }

    void AbrirDialogo()
    {
        dialogoAberto = true;
        painelDialogo.SetActive(true);
        indexAtual = 0;
        AtualizarUI();
    }

    void FecharDialogo()
    {
        dialogoAberto = false;
        painelDialogo.SetActive(false);
        indexAtual = 0;
    }

    void AvancarTexto()
    {
        // Se ainda não é a última frase, avança
        if (indexAtual < frases.Length - 1)
        {
            indexAtual++;
            AtualizarUI();
        }
        else
        {
            // Se já é a última, fecha
            FecharDialogo();
        }
    }

    void AtualizarUI()
    {
        // 1. Muda o texto da história
        textoHistoria.text = frases[indexAtual];

        // 2. Controla a Seta de Texto
        // Se NÃO for a última frase, mostra a seta. Se for a última, esconde.
        if (indexAtual < frases.Length - 1)
        {
            objetoSetaTexto.SetActive(true);
        }
        else
        {
            objetoSetaTexto.SetActive(false);
        }
    }
}