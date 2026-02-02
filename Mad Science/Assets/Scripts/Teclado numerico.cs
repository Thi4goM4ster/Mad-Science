using UnityEngine;
using TMPro; // Necessário para mexer no Input Field

public class SistemaSenha : MonoBehaviour
{
    [Header("Configurações")]
    public string senhaCorreta = "1234";
    public GameObject portaParaAbrir; // O objeto que vai sumir (a porta)

    [Header("UI")]
    public GameObject painelSenha;
    public TMP_InputField campoDeTexto;

    [Header("O Jogador")]
    // Arraste aqui o script de movimento do seu player (ex: PlayerController)
    // Usamos 'MonoBehaviour' para aceitar qualquer nome de script que você criou
    public MonoBehaviour scriptMovimentoPlayer; 

    public Animator Andrew;
    private bool PainelAberto = false;
    private void Start()
    {
        painelSenha.SetActive(false);

        // Configura o InputField para chamar a função ChecarSenha quando apertar ENTER
        campoDeTexto.onSubmit.AddListener(delegate { ChecarSenha(); });
    }

    private void Update(){
        if (/*PainelAberto && */Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("pressionando ESC");
            FecharPainel();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
                    Debug.Log("Tentando parar a animação");

        if (other.CompareTag("Player"))
        {
            PainelAberto = true;
            painelSenha.SetActive(true);
            
            // Limpa o texto anterior e foca o cursor para digitar na hora
            campoDeTexto.text = ""; 
            campoDeTexto.ActivateInputField(); 

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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FecharPainel();
        }
    }

    public void ChecarSenha()
    {
        // Verifica se o texto digitado é igual à senha
        if (campoDeTexto.text == senhaCorreta)
        {
            Debug.Log("Acesso Permitido!");
            portaParaAbrir.SetActive(true); // "Abre" a porta (desativa o objeto)
            FecharPainel();
        }
        else
        {
            Debug.Log("Senha Incorreta!");
            campoDeTexto.text = ""; // Limpa para tentar de novo
            campoDeTexto.ActivateInputField(); // Mantém o foco no campo
        }
    }

    void FecharPainel()
    {
        Andrew.enabled = true;
        PainelAberto = false;
        if (painelSenha != null)
        painelSenha.SetActive(false);
        
        // DESTRAVA O PLAYER
        if (scriptMovimentoPlayer != null)
            scriptMovimentoPlayer.enabled = true;
    }
}
