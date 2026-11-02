 using UnityEngine;
using UnityEngine.InputSystem;

public class birdscript : MonoBehaviour
{
    public float flapStrength;
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public bool birdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (logic == null)
        {
            logic = FindFirstObjectByType<LogicScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (birdIsAlive && Camera.main != null)
        {
            Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            if (viewportPosition.y < 0f || viewportPosition.y > 1f)
            {
                EndGame();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PipeMiddleScript>() == null)
        {
            EndGame();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PipeMiddleScript>() == null)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        if (!birdIsAlive)
        {
            return;
        }

        birdIsAlive = false;

        if (logic != null)
        {
            logic.gameOver();
        }
    }
}
