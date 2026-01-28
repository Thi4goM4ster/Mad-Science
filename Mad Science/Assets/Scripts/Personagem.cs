using UnityEngine;

public class MovimentoTransform : MonoBehaviour
{
    public float velocidade = 5f;
    public Animator animator; // Arraste seu Animator para cá no Inspector se tiver animação

    void Update()
    {
        // Pega o input (teclas)
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Cria o vetor de direção
        Vector3 direcao = new Vector3(x, y, 0).normalized;

        // Verifica se há movimento para evitar cálculos desnecessários
        if (direcao != Vector3.zero)
        {
            // MOVE O PERSONAGEM
            // Space.World garante que ele ande nos eixos do mundo, não do personagem
            transform.Translate(direcao * velocidade * Time.deltaTime);

            // ATUALIZA A ANIMAÇÃO (Opcional, se você já tiver configurado)
            /*if (animator != null)
            {
                animator.SetFloat("InputX", x);
                animator.SetFloat("InputY", y);
                animator.SetBool("Andando", true);
            }*/
        }
        else
        {
            //if (animator != null) animator.SetBool("Andando", false);
        }
    }
}