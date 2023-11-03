using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Define minhas variaveis
    public Transform characterBody; // Captura meu objeto do corpo
    public Transform characterHead; // Captura meu objeto da cabe�a
   
    float sensitivityX = 2f; // Define a sensibilidade do mouse em X
    float sensitivityY = 2f; // Define a sensibilidade do mouse em Y

    float rotationX = 0; // Define a rota��o de X
    float rotationY = 0; // Define a rota��o de Y

    float angleYmin = -90; // Define meu angulo minimo da cabeca
    float angleYMax = 90; // Define meu angulo maximo da cabeca

    /*float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.005f;
    float smoothCoefy = 0.005f;*/

    bool canMouseMove = true;

    void Start()
    {
        Cursor.visible = false; // Faz com que meu cursor fique invisivel
        Cursor.lockState = CursorLockMode.Locked; // Curso trave na tela
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position; // Transforma a posi��o na posi��o da minha cabe�a
    }

    void Update()
    {
        if (canMouseMove)
        {
            float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY; // Define as posi��es do mouse de cima e baixo
            float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX; // Define as posi��es do mouse para os lados

            /*smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
            smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);
            rotationX += smoothRotx;
            rotationY += smoothRoty;*/

            rotationX += horizontalDelta; // Recebe os valores da posi��o em X
            rotationY += verticalDelta; // Recebe os valores da posi��o em Y

            rotationY = Mathf.Clamp(rotationY, angleYmin, angleYMax);

            characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        } 
    }

    public void CancelCamera(bool value)
    {
        canMouseMove = value;
    }
}
