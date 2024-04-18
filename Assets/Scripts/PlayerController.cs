using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f; // Fuerza de salto
    private bool isGrounded; // Variable para verificar si el jugador est� en el suelo
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true; // Al inicio, el jugador est� en el suelo
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (horizontalInput, 0f, verticalInput)*speed*Time.deltaTime;
        transform.Translate (movement);
        // Verificar si la tecla espacio est� siendo presionada y el jugador est� en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Aplicar fuerza hacia arriba para simular un salto
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // El jugador ya no est� en el suelo despu�s de saltar
        }
    }
    // M�todo para detectar cuando el jugador entra en contacto con el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // El jugador est� en el suelo
        }
    }
}
