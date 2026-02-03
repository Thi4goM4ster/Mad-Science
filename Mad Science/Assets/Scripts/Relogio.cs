
using UnityEngine;
using TMPro; // Necessário para o Input Field

public class RelogioInterativo : MonoBehaviour
{
    [Header("Puzzle")]
    public string horaCorreta = "12:00"; // A senha específica DESTE relógio
    public PortaRelogios scriptDaPorta;  // Quem eu aviso quando acertar?
    
    [Header("Interface (Canvas)")]
    public GameObject painelInput;       // O painel que abre na tela
    public TMP_InputField campoDeTexto;  // Onde digita
    
    [Header("Player")]
    public MonoBehaviour scriptMovimento; 
    public Animator Andrew;

    private bool jaResolvido = false; // Para não contar o mesmo relógio 2 vezes

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Só abre se for o Player e se o relógio ainda NÃO estiver resolvido
        if (other.CompareTag("Player") && !jaResolvido)
        {
            AbrirPainelRelogio();
            if (Andrew != null){
            
            //Andrew.SetFloat("InputX",0);
            //Andrew.SetFloat("InputY",0);
            Andrew.enabled = false;
            Andrew.Play("Parado");
        }
        }
        
    }

    void AbrirPainelRelogio()
    {
        painelInput.SetActive(true);
        campoDeTexto.text = "";
        campoDeTexto.ActivateInputField();

        // --- O TRUQUE DE MESTRE ---
        // 1. Removemos qualquer função antiga que o "Enter" tinha (de outros relógios)
        campoDeTexto.onSubmit.RemoveAllListeners();
        
        // 2. Adicionamos a função DESTE relógio específico
        campoDeTexto.onSubmit.AddListener(delegate { VerificarHora(); });

        // Trava o player
        if(scriptMovimento != null) scriptMovimento.enabled = false;
    }

    // Função chamada ao apertar Enter
    void VerificarHora()
    {
        if (campoDeTexto.text == horaCorreta)
        {
            Debug.Log("Hora Correta!");
            jaResolvido = true; // Trava este relógio
            
            // Avisa a porta
            scriptDaPorta.RegistrarRelogioCorreto();

            // Feedback visual (Opcional): Mudar a cor do relógio para verde
           // GetComponent<SpriteRenderer>().color = Color.green;

            FecharPainel();
        }
        else
        {
            Debug.Log("Hora Errada...");
            campoDeTexto.text = ""; // Limpa para tentar de novo
            campoDeTexto.ActivateInputField();
        }
    }

    void FecharPainel()
    {
        painelInput.SetActive(false);
        // Destrava o player
        if(scriptMovimento != null) scriptMovimento.enabled = true;
        Andrew.enabled = true;   
        if (scriptMovimento != null)
        scriptMovimento.enabled = true;
    }

    private void Update()
    {
        // Permite sair com ESC
        if (painelInput.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            FecharPainel();
            
        }
    }
}