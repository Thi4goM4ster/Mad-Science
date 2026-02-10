using UnityEngine;

public class GameManagerSecreto : MonoBehaviour
{
    [Header("Visita 1 (11 Mensagens)")]
    public GameObject[] mensagensCollin; // Arraste os Collin 1 ao 11 aqui

    [Header("Visitas Seguintes")]
    public GameObject input1; // Visita 2
    public GameObject input2; // Visita 3
    public GameObject input3; // Visita 4

    [Header("Porta e Controle")]
    public GameObject portaSecreta;
    public MonoBehaviour scriptMovimentoPlayer; // Para travar o boneco lendo

    // Controle de Memória
    private int visitaAtual; // 0=Visita1, 1=Visita2, 2=Visita3, 3=Visita4
    private bool jaLeuTudoHoje = false; // Bloqueia ler a visita de amanhã hoje
    
    // Controle Interno
    private int indiceCollinAtual = 0; // Para contar do 1 ao 11 na primeira visita
    private GameObject painelAbertoAtualmente = null; // Sabe se tem algo na tela

    void Start()
    {
        // Carrega qual visita estamos (começa no 0)
        visitaAtual = PlayerPrefs.GetInt("ProgressoPC", 0);
        
        // Esconde todas as mensagens por garantia
        EsconderTudo();

        // Se já completou tudo no passado, deixa a porta aberta
        if (visitaAtual >= 4 && portaSecreta != null)
        {
            portaSecreta.SetActive(false);
        }
    }

    // Função chamada pelo Computador quando aperta 'E'
    public void TentarInteragir()
    {
        // 1. Se já tem um painel aberto, apertar 'E' fecha ele e avança a lógica
        if (painelAbertoAtualmente != null)
        {
            FecharPainelAberto();
            return;
        }

        // 2. Se não tem painel aberto, verifica se já esgotamos as mensagens de hoje
        if (jaLeuTudoHoje)
        {
            Debug.Log("O computador está em modo de espera. Volte depois.");
            return; // Sai da função, não faz nada
        }

        // 3. Se pode ler, abre a mensagem certa baseada na Visita
        AbrirMensagemDaVisita();
    }

    void AbrirMensagemDaVisita()
    {
        if (visitaAtual == 0) // VISITA 1 (11 mensagens)
        {
            MostrarPainel(mensagensCollin[indiceCollinAtual]);
        }
        else if (visitaAtual == 1) // VISITA 2
        {
            MostrarPainel(input1);
        }
        else if (visitaAtual == 2) // VISITA 3
        {
            MostrarPainel(input2);
        }
        else if (visitaAtual == 3) // VISITA 4
        {
            MostrarPainel(input3);
        }
        else // JÁ TERMINOU TUDO
        {
            Debug.Log("Não há mais arquivos para ler.");
        }
    }

    void FecharPainelAberto()
    {
        // Desativa a tela atual
        painelAbertoAtualmente.SetActive(false);
        painelAbertoAtualmente = null;
        
        // Destrava o player
        if (scriptMovimentoPlayer != null) scriptMovimentoPlayer.enabled = true;

        // --- VERIFICA SE TERMINOU A VISITA ---

        if (visitaAtual == 0) // Lógica especial da Visita 1 (11 telas)
        {
            indiceCollinAtual++; // Vai pro próximo Collin

            // Se chegou no 11 (índice 11 na lista)
            if (indiceCollinAtual >= mensagensCollin.Length)
            {
                FinalizarVisitaDoDia();
            }
        }
        else // Lógica das visitas 2, 3 e 4 (só 1 tela por visita)
        {
            FinalizarVisitaDoDia();
        }
    }

    void FinalizarVisitaDoDia()
    {
        jaLeuTudoHoje = true; // Bloqueia o PC nesta visita
        visitaAtual++; // Vai pra próxima visita
        
        // Salva na memória
        PlayerPrefs.SetInt("ProgressoPC", visitaAtual);
        PlayerPrefs.Save();

        Debug.Log("Visita concluída. Próxima visita será a de número: " + (visitaAtual + 1));

        // Se acabou de completar a Visita 4 (que agora o visitaAtual vira 4)
        if (visitaAtual == 4)
        {
            Debug.Log("ACESSO LIBERADO. PORTA ABERTA!");
            if (portaSecreta != null) portaSecreta.SetActive(false);
        }
    }

    void MostrarPainel(GameObject painel)
    {
        painelAbertoAtualmente = painel;
        painel.SetActive(true);
        if (scriptMovimentoPlayer != null) scriptMovimentoPlayer.enabled = false;
    }

    void EsconderTudo()
    {
        foreach (GameObject collin in mensagensCollin)
            if (collin != null) collin.SetActive(false);

        if (input1 != null) input1.SetActive(false);
        if (input2 != null) input2.SetActive(false);
        if (input3 != null) input3.SetActive(false);
    }
}