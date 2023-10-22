using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Define minhas variaveis
    CharacterController controller; // Recebe o objeto do meu player

    // Variaveis de movimento
    Vector3 forward;  // Personagem para frente
    Vector3 strafe;   // Personagem para os lados
    Vector3 vertical; // Personagem para cima

    float forwardSpeed = 5f; // Velocidade para frente
    float strafeSpeed = 5f;  // Velocidade para os lados

    float gravity; // Gravidade do personagem
    float jumpSpeed; // Velocidade do pulo
    float maxJumpHeight = 2f; // Altura maxima que o pulo pode chegar
    float timeToMaxHeight = 0.5f; // Tempo que meu personagem leva para chegar na altura maxima

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Capturo o componente (corpo) do personagem

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight); // Defino minha gravidade
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight; // Defino minha velocidade do pulo
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");  // Capturo minhas teclas para andar para frente
        float strafeInput = Input.GetAxis("Horizontal"); // Capturo minhas teclas para andar para os lados

        //force = input * speed * direction => Calculo da forca
        forward = forwardInput * forwardSpeed * transform.forward; // Calcula minha força para ir pra frente
        strafe = strafeInput * strafeSpeed * transform.right; // Calcula minha força para ir pros lados

        vertical += gravity * Time.deltaTime * Vector3.up; // Calcula minha força para ir para cim
           
        // Verifica se meu personagem está no chão, caso sim, desce meu personagem para baixo
        if (controller.isGrounded)
            vertical = Vector3.down;

        // Verifica se meu usuario apertou a tecla 'Space' e se o personagem esta no chão, caso sim,
        // adiciono uma força para cima
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            vertical = jumpSpeed * Vector3.up;

        // Verifica se meu personagem esta no ar e se teve alguma colisão acima de sua cabeça, caso sim,
        // desce meu personagem para baixo (Serve para não ficar preso no teto)
        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
            vertical = Vector3.zero;

        // Junta todos meus dados para ir pra frente, tras e cima em um unico vetor
        Vector3 finalVelocity = forward + strafe + vertical;

        // Transforma todos os dados no movimento
        controller.Move(finalVelocity * Time.deltaTime);
    }
}
