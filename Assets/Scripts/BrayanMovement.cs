using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrayanMovement : MonoBehaviour
{
    public float JumpForce;
    public float velocityRun;

    //Rigi de personaje
    private Rigidbody2D Rigidbody2D;
    private float Vertical;

    //variable para la tierra
    private bool Grounded;
    private Animator Animator;

    public GameObject generadorEnemigo;

    // Use this for initialization
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        generadorEnemigo.SendMessage("comenzarGenerador");
    }

    // Update is called once per frame
    void Update()
    {
        //si oprime horizontal
        Vertical = Input.GetAxisRaw("Vertical");
        //pinta una linea roja desde el personaje hasta el piso
        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);
        //valida la posicion si salta desde el suelo o desde el aire
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.3f))
            Grounded = true;
        else Grounded = false;
        //velocidad a la que aumenta a corredor
        if(Animator.speed < 3.9f)
            Animator.speed = Animator.speed + velocityRun;

        //verifica si se mueve y si si vale true y se pone a correr
        Animator.SetBool("Jump", !Grounded);

        //valida que se oprima la tecla arriba o w y que el salto sea desde el piso y no del cielo   
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        //Funcion de salto
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    public void Hit()
    {
        //funcion de vida
        Animator.SetBool("Dead", true);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        //Destroy(gameObject);
    }
}
