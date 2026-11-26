using UnityEngine;

public class GravityDisabler : MonoBehaviour
{
    [SerializeField] private bool debugButton;
    [SerializeField] private float centerForce = 1;

    Rigidbody2D[] bRbs;

    bool gravityDisabled;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bRbs = GetComponentsInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugButton)
        {
            debugButton = false;
            if (gravityDisabled)
            {
                EnableGravity();
            }
            else
            {
                DisableGravity();
            }
        }
    }

    void FixedUpdate()
    {
        if (gravityDisabled)
        {
            foreach (var rb in bRbs)
            {
                Vector2 dif = transform.position - rb.transform.position;
                rb.AddForce(dif * centerForce);
            }
        }
    }

    void DisableGravity()
    {
        foreach (var rb in bRbs)
        {
            rb.gravityScale = 0;
        }
        gravityDisabled = true;
    }

    void EnableGravity()
    {
        foreach (var rb in bRbs)
        {
            rb.gravityScale = 1;
        }
        gravityDisabled = false;
    }
}
