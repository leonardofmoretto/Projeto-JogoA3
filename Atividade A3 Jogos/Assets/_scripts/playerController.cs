using UnityEngine;

public class playerController : MonoBehaviour
{

    public float velocidade =5f; //velocidade do boneco
    public float velRot = 10f; // velocidade de giro
    public float forcaSalto = 1f; //força do pulo
    public float alturaSalto = 0f; // altura atual do boneco
    public float alturaMax = 1.0f; //altura max do pulo
    public float ccgravidade = 0.5f; //força da gravidade
    
    private Vector3 moveDirection = Vector3.zero; //vetor pra determinar a posição
    private CharacterController cc; // controle do jogador
    private bool pulando = false; // verifica se o boneco está pulando

   public float sensibilidadeMouse = 2f; // Sensibilidade do mouse
    public float limiteRotacao = 90f;    // Limite do ângulo vertical da câmera
    private float rotacaoX = 0f;         // Ângulo atual da rotação vertical

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        
    }

       void Update()
    {
      
        // Controle da rotação com o mouse
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse;

        // Rotação horizontal do personagem
        transform.Rotate(0, mouseX, 0);

        // Rotação vertical da câmera (limite superior e inferior)
        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -limiteRotacao, limiteRotacao);

        // Aplica a rotação vertical na câmera
        Camera.main.transform.localRotation = Quaternion.Euler(rotacaoX, 0, 0);

        float horiz = Input.GetAxisRaw("Horizontal") *Time.deltaTime*velRot;
        float vert = -Input.GetAxisRaw("Vertical") *Time.deltaTime * velocidade;

        if(cc.isGrounded){

            moveDirection = new Vector3(0, 0,vert);
            moveDirection = transform.TransformDirection(moveDirection);
        }

        if(pulando==true && transform.localPosition.y<alturaSalto){

            moveDirection.y += forcaSalto * Time.deltaTime;
        }
        else{

            moveDirection.y -= ccgravidade * Time.deltaTime;
            pulando = false;
        }

        cc.Move(moveDirection);
       // transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        if(Input.GetKeyDown(KeyCode.Space)){

            alturaSalto = transform.localPosition.y + alturaMax;
            pulando = true;
        }

        
    }
}
