using UnityEngine;

public class MostrarImagem : MonoBehaviour
{
    [Header("Arraste aqui a Imagem do Canvas")]
    public GameObject objetoDaImagem; 

    private void Start()
    {
        // Por segurança, garante que a imagem comece desligada
        if (objetoDaImagem != null)
        {
            objetoDaImagem.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Quando o Player entra na área
        if (other.CompareTag("Player"))
        {
            objetoDaImagem.SetActive(true); // Liga a imagem
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Quando o Player sai da área
        if (other.CompareTag("Player"))
        {
            objetoDaImagem.SetActive(false); // Desliga a imagem
        }
    }
}