using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform startPosition;
    public Transform endPosition;
    public float moveSpeed = 2.0f;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition.position, endPosition.position);
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition.position, endPosition.position, fractionOfJourney);

        if (fractionOfJourney >= 1.0f)
        {
            // Llegamos al final, así que invertimos las posiciones para moverse en sentido contrario
            Vector3 temp = startPosition.position;
            startPosition.position = endPosition.position;
            endPosition.position = temp;
            startTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Balon"))
        {
            GameObject.Find("Pelota").SetActive(false);
            //collision.gameObject.SetActive(false);
        }
    }
}
