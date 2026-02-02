using UnityEngine;

public class PortaPuzzleQuadros : MonoBehaviour
{
    [Header("Configuração")]

    public GameObject Shard1;
    public GameObject Shard2;
    public GameObject PortaPreta;
    // Função que os quadros vão chamar quando forem consertados
    public void Update()
    {
    if (Shard1.activeInHierarchy && Shard2.activeInHierarchy){
        AbrirPorta();
    }
    }

    void AbrirPorta()
    {
        Debug.Log("PORTA DESTRANCADA!");
        PortaPreta.SetActive(true); // A porta some (ou toca animação de abrir)

    }
}