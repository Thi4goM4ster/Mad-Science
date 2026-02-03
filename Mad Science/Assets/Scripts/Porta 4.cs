using UnityEngine;

public class PortaRelogios : MonoBehaviour
{
    [Header("Configuração")]
    public int totalRelogios = 4;
    private int relogiosCorretos = 0;
    public GameObject portaSecreta;

    public void RegistrarRelogioCorreto()
    {
        relogiosCorretos++; // Conta +1
        Debug.Log("Relógios Corretos: " + relogiosCorretos + "/" + totalRelogios);

        if (relogiosCorretos >= totalRelogios)
        {
            AbrirPorta();
        }
    }

    void AbrirPorta()
    {
        Debug.Log("TODOS OS RELÓGIOS ESTÃO SINCRONIZADOS!");
        gameObject.SetActive(true); // A porta abre/some
        portaSecreta.SetActive(true);
    }
}