using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float force;

    protected Vector2 trajectoryOrigin;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RestartGame();
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    private void PushBall()
    {
        var angle = Random.Range(-45f, 45f);
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb.AddForce(dir * force);
    }

    private void RestartGame()
    {
        ResetBall();
        Invoke(nameof(PushBall), 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
