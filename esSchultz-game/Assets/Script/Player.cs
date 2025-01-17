using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // variavel para o rigidBody
    private Rigidbody2D rig;
    //vetor da posicao Inicial do Player
    private Vector3 posInicial;
    // variavel da velocidade
    private float speed = 5;
    // componente animator
    public Animator animator;
    public bool isJumping = false;
    private float JumpForce = 8;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        posInicial = new Vector3(-0.83f, -0.42f, 0f);
        transform.position = posInicial;
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
            //verifica se a tecla A foi pressionada e o valor X da escala est� positivo
            if (Input.GetKeyDown(KeyCode.A) && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * - 1,
            transform.localScale.y, transform.localScale.z);
            //Debug.Log("Tecla A pressionada")
        }
        //verifica se a tecla D foi pressionada e o valor X da escala est� negativo
        if (Input.GetKeyDown(KeyCode.D) && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * - 1,
            transform.localScale.y, transform.localScale.z);
            //Debug.Log("Tecla D pressionada")
        }
    }
}
