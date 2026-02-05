using UnityEngine;
using TMPro; // Necessário para o Input Field

public class PrateleiraQuimica : MonoBehaviour
{
    [Header("Configuração do Puzzle")]
    public string formulaCorreta = "H2O"; // A resposta exata (pode ser "2H 1O", "C6H12O6", etc)
    
    [Header("Recompensa")]
    public string nomeDoItemEntregue = "AmostraPronta"; // Nome para o inventário
    public Sprite iconeDoInventario; // A imagem do becker cheio para aparecer na tela
    public GameObject Potion;

    [Header("Interface (UI)")]
    public GameObject painelInput;      // O painel onde digita
    public TMP_InputField campoDeTexto; // O campo de texto
    public MonoBehaviour scriptMovimento; // Para travar o player
    public Animator Andrew;

    private bool jaPegou = false;

    private void Start()
    {
        painelInput.SetActive(false);
        // Configura o Enter para chamar a checagem
        campoDeTexto.onSubmit.AddListener(delegate { VerificarFormula(); });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Só abre se for o Player e se ele ainda não pegou a amostra
        if (other.CompareTag("Player") && !jaPegou)
        {
            if (Andrew != null){
            Andrew.enabled = false;
            Andrew.Play("Parado");
        }
            AbrirPainel();
        }
    }

    private void Update()
    {
        if (painelInput.activeSelf && Input.GetKeyDown(KeyCode.Escape))
            FecharPainel();
    }

    void AbrirPainel()
    {
        painelInput.SetActive(true);
        campoDeTexto.text = "";
        campoDeTexto.ActivateInputField();

        if (scriptMovimento != null) scriptMovimento.enabled = false;
    }

    void VerificarFormula()
    {
        // Verifica se o que digitou é igual à fórmula (ignora maiúsculas/minúsculas se quiser)
        if (campoDeTexto.text.ToUpper() == formulaCorreta.ToUpper())
        {
            Debug.Log("Fórmula Correta! Amostra criada.");
            
            Potion.SetActive(true);
            jaPegou = true;

            FecharPainel();
        }
        else
        {
            Debug.Log("Fórmula Errada...");
            campoDeTexto.text = ""; // Limpa
            campoDeTexto.ActivateInputField(); // Mantém o foco
        }
    }

    void FecharPainel()
    {
        painelInput.SetActive(false);
        if(scriptMovimento != null) scriptMovimento.enabled = true;
        Andrew.enabled = true;   
        if (scriptMovimento != null)
        scriptMovimento.enabled = true;
    }
}
