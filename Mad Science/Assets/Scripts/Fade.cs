using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necessário para usar Corrotinas (IEnumerator)

public class LevelLoader : MonoBehaviour
{
    [Header("Configurações")]
    public Animator transition; // Arraste o componente Animator do painel aqui
    public float transitionTime = 1f; // Tempo que a tela fica preta (deve ser igual ao da animação)

    // Esta função é chamada pela porta ou pelo menu
    public void CarregarProximaFase(string nomeDaCena)
    {
        StartCoroutine(LoadLevel(nomeDaCena));
    }

    // A Corrotina que espera a animação acontecer
    IEnumerator LoadLevel(string levelIndex)
    {
        // 1. Toca a animação de escurecer (Fade Out)
        // Certifique-se que criou um Trigger chamado "Start" no Animator
        transition.SetTrigger("Start");

        // 2. Espera o tempo da animação terminar
        yield return new WaitForSeconds(transitionTime);

        // 3. Carrega a nova cena
        SceneManager.LoadScene(levelIndex);
    }
}