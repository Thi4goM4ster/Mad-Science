using UnityEngine;

public class PlayerMovementEstados : MonoBehaviour
{
    public float velocidade = 5f;
    public Animator animator; 

    // Variável para guardar para onde o player estava olhando por último
    // 0 = Baixo/Frente, 1 = Cima/Trás, 2 = Esquerda, 3 = Direita
    //private int ultimaDirecao = 0; 

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 direcao = new Vector3(x, y, 0).normalized;

        // 1. MOVIMENTO (Sem Rigidbody, como você pediu antes)
        if (direcao != Vector3.zero)
        {
            transform.Translate(direcao * velocidade * Time.deltaTime, Space.World);
            
            // 2. DECIDE QUAL ANIMAÇÃO TOCAR
            if (x < 0) 
            {
                animator.Play("Andando pra esquerda");
                //ultimaDirecao = 2;
            }
            else if (x > 0)
            {
                animator.Play("Andando pra direita");
                //ultimaDirecao = 3;
            }
            else if (y > 0)
            {
                animator.Play("Andando pra trás");
                //ultimaDirecao = 1;
            }
            else if (y < 0)
            {
                animator.Play("Andando pra frente");
                //ultimaDirecao = 0;
            }
        }
        else
        {
            // 3. SE PARAR (Toca a animação 'Parado')
            // Nota: Como você só tem UM estado "Parado", ele vai voltar 
            // para a posição padrão (geralmente de frente) quando parar.
            animator.Play("Parado");
        }
    }
}
