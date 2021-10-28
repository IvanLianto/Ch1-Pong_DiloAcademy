using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 lastPos;
    private int score;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float yBoundary = 9.0f;

    protected ContactPoint2D lastContactPoint;
    protected Vector2 trajectoryOrigin;

    protected void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
    }

    protected void Move(float multiplier)
    {
        var velocity = rb.velocity;

        velocity.y = multiplier * speed;

        rb.velocity = velocity;

        lastPos = transform.position;
        CheckBoundary(ref lastPos);
        transform.position = lastPos;
    }

    protected void CheckBoundary(ref Vector2 lastPos)
    {
        lastPos.y = Mathf.Clamp(lastPos.y, -yBoundary, yBoundary);
    }

    public void IncrementScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get { return score; }
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
