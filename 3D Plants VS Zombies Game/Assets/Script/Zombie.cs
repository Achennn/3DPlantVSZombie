using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Zombie : MonoBehaviour
{
    public float movingSpeed = 0.0f;
    public float gravity = -9.8f;

    private bool isAlive;

    private CharacterController zombieController;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        animator = GetComponent<Animator>();
        zombieController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.forward;
        movement *= movingSpeed;
        movement *= Time.deltaTime;

        zombieController.Move(movement);
    }
}
