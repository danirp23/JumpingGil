using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementback : MonoBehaviour
{
    [Range(0f, 0.20f)]//pa ponerle un rango
    public float parallaxSpeed = 0.02f;//velocidad en que se mueve
    public UnityEngine.UI.RawImage background;//imagen de fondo de las montañitas

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Parallax();
    }
    void Parallax()
    {//El efecto parallax es que el fondo y el piso se muevan 
     //pero que el piso se mueva mas rapido que el fondo
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
    }
}
