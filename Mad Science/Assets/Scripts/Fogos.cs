using UnityEngine;

public class SistemaDeRespawn : MonoBehaviour
{
    private Vector2 posicaoInicial;
    private Rigidbody2D rb;

    void Start()
    {
        // 1. Assim que a fase começa, ele memoriza onde está pisando
        posicaoInicial = transform.position;
        
        // Pega o componente de física (se você estiver usando)
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {
        // 2. Verifica se o que ele encostou tem a etiqueta "Fogo"
        if (outro.CompareTag("Fogo"))
        {
            Debug.Log("Ai! Queimei. Voltando pro início...");

            // 3. Teletransporta o boneco de volta
            transform.position = posicaoInicial;

            // 4. (Opcional) Zera a velocidade para ele não continuar escorregando
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}