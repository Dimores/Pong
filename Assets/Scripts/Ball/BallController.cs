using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float initialSpeed = 5f;

    public GameManager gameManager;

    public float speedUp = 1.1f;

    public void ResetBall()
    {
        // Resetando a posição da bola para o centro
        transform.position = Vector3.zero;

        // Garantindo que o Rigidbody2D está atribuído
        if (rb == null) rb = GetComponent<Rigidbody2D>();

        // Sorteando uma das 4 diagonais aleatórias
        float randomX = Random.Range(0, 2) == 0 ? -1 : 1; // -1 ou 1
        float randomY = Random.Range(0, 2) == 0 ? -1 : 1; // -1 ou 1

        // Configurando a velocidade inicial na direção sorteada
        Vector2 startingVelocity = new Vector2(randomX, randomY).normalized * initialSpeed;
        rb.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Toca o som independente da colisão
        SoundController.Instance.Play(GetComponent<AudioSource>());

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Salvando a velocidade antiga
            Vector2 newVelocity = rb.velocity;

            // Setando a nova velocidade (inverso)
            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}
