using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    [Header("Velocidade")]
    public float velocidade = 5f;

    private Rigidbody2D rb;
    private Vector2 movimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update é chamado uma vez por frame (bom para Input)
    void Update()
    {
        // Pega as teclas setinhas ou WASD
        // Input.GetAxisRaw faz o movimento ser "seco" (para na hora que solta).
        // Se quiser que ele deslize um pouco, use apenas Input.GetAxis.
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Cria um vetor com a direção (X e Y) e Normaliza
        // .normalized garante que andar na diagonal não seja mais rápido que andar reto
        movimento = new Vector2(moveX, moveY).normalized;
    }

    // FixedUpdate é chamado em intervalos fixos (obrigatório para Física/Rigidbody)
    void FixedUpdate()
    {
        // Move o personagem mudando a velocidade do corpo rígido
        rb.linearVelocity = movimento * velocidade;
    }
}