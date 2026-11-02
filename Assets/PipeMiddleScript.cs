using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private bool hasScored;
    private void Awake()
    {
        if (logic == null)
        {
            logic = FindFirstObjectByType<LogicScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasScored && collision.GetComponentInParent<birdscript>() != null)
        {
            hasScored = true;
            if (logic != null)
            {
                logic.addScore(1);
            }
        }
    }
}
