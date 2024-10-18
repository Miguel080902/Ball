using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public float fuerzaDeSalto = 10.0f; // Ajusta la fuerza del salto según tu preferencia.
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(touchPos);

            if (hit != null && hit.gameObject == gameObject)
            {
                Saltar(touchPos);
            }
        }
    }

    void Saltar(Vector3 touchPos)
    {

        Vector2 direction = (transform.position - touchPos).normalized;
        if (direction.y < 0)
        {
            direction.y *= -1;
        }
        direction.y += 0.05f;
        Debug.Log(direction);
        rb.velocity = Vector2.zero;
        rb.velocity = direction * fuerzaDeSalto;

    }
    
}
