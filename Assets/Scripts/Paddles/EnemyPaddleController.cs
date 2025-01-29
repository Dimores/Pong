using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;
    private GameObject ball;

    public Vector2 limits = new Vector2(-4.5f, 4.5f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); // Encontra o objeto da bola na cena
    }

    private void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y); // Limita y
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }
}
