using UnityEngine;

public class GerenciadorCutscene : MonoBehaviour
{
    [Header("Configuração")]
    public float tempoDeDuracao = 10f; // Quanto tempo a cutscene dura (em segundos)
    public string nomeDaFase1 = "Sala 01"; // O nome exato da cena da Fase 1

    private LevelLoader loader;
    private bool jaMudou = false; // Para evitar mudar 2x se apertar botão rápido

    void Start()
    {
        loader = FindObjectOfType<LevelLoader>();

        // Começa a contagem regressiva assim que a cena abre
        // Chama a função 'MudarFase' depois de X segundos
        Invoke("MudarFase", tempoDeDuracao);
    }

    void Update()
    {
        // Opcional: Permitir pular a cutscene com Espaço ou Enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            MudarFase();
        }
    }

    void MudarFase()
    {
        if (jaMudou) return; // Se já está mudando, ignora
        jaMudou = true;

        CancelInvoke(); // Cancela o timer automático (caso tenha sido pulado manualmente)
        
        Debug.Log("Acabou a cutscene, indo para o jogo...");
        Debug.Log("loader: "+loader);

        loader.CarregarProximaFase(nomeDaFase1);
    }
}