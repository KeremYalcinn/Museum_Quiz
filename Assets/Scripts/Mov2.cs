using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov2 : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 200.0f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveCharacter();
        RotateCharacter();
        UpdateAnimator();
    }

    void MoveCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        // Karakter hareket ettiðinde Animator'daki "IsMoving" parametresini true olarak ayarla
        animator.SetBool("IsMoving", movement.magnitude > 0);
    }

    void RotateCharacter()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // Y eksenindeki rotasyonu sýfýrla
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
    }

    void UpdateAnimator()
    {
        // Karakter durduðunda Animator'daki "IsMoving" parametresini false olarak ayarla
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
