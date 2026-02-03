using UnityEngine;
using TMPro;

public class CofreDigital : MonoBehaviour
{
    [Header("Configurações")]
    public string senhaDesteCofre = "1234";
    public GameObject itemParaRevelar; // O pedaço do quadro que está escondido dentro
    public GameObject portaDoCofre;    // A sprite da porta fechada (opcional, para sumir com ela)

    public Animator Andrew;
    [Header("UI")]
    public GameObject painelSenha;
    public TMP_InputField campoDeTexto;
    public MonoBehaviour scriptMovimentoPlayer; 

    // Variável de controle interna
    private bool cofreAberto = false; 

    private void Start()
    {
        painelSenha.SetActive(false);
        // Garante que o item comece escondido
        if(itemParaRevelar != null) itemParaRevelar.SetActive(false);
        
        campoDeTexto.onSubmit.AddListener(delegate { TentarAbrir(); });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Só abre o teclado se o cofre ainda estiver fechado
        if (other.CompareTag("Player") && !cofreAberto)
        {
            AbrirPainel();
        }
                if (Andrew != null){
            
            //Andrew.SetFloat("InputX",0);
            //Andrew.SetFloat("InputY",0);
            Andrew.enabled = false;
            Andrew.Play("Parado");
        }
            // TRAVA O PLAYER (Desliga o script de movimento)
            if (scriptMovimentoPlayer != null)
                scriptMovimentoPlayer.enabled = false;
    }

    private void Update()
    {
        if (painelSenha.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            FecharPainel();
    }

    void AbrirPainel()
    {
        painelSenha.SetActive(true);
        campoDeTexto.text = "";
        campoDeTexto.ActivateInputField();
        if (scriptMovimentoPlayer != null) scriptMovimentoPlayer.enabled = false;
    }

    void TentarAbrir()
    {
        if (campoDeTexto.text == senhaDesteCofre)
        {
            Debug.Log("Cofre Aberto!");
            cofreAberto = true; // Marca como resolvido para não pedir senha de novo
            
            // Lógica Visual
            if(itemParaRevelar != null) itemParaRevelar.SetActive(true); // O item aparece!
            if(portaDoCofre != null) portaDoCofre.SetActive(true);      // A porta do cofre some (ou abre)

            FecharPainel();
        }
        else
        {
            campoDeTexto.text = "";
            campoDeTexto.ActivateInputField();
        }
    }

    void FecharPainel()
    {
        painelSenha.SetActive(false);
        if (scriptMovimentoPlayer != null) scriptMovimentoPlayer.enabled = true;
        Andrew.enabled = true;
    }
}