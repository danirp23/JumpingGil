using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float velocidad = 2f;
    //Rigi de personaje
    private Rigidbody2D Rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Vector2.left* velocidad;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENTRO");
        BrayanMovement brayan = other.GetComponent<BrayanMovement>();
        if (brayan != null)
        {
            brayan.Hit();
        }
    }
}
