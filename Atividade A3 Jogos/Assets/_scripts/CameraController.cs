using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform focoPlayer;
    public Transform camPlayer;
       void Start()
    {
        transform.position = camPlayer.position;
        transform.rotation = camPlayer.rotation;
        transform.LookAt(focoPlayer);
        
    }
    void Update()
    {
        transform.position = camPlayer.position;
        transform.rotation = camPlayer.rotation;
        transform.LookAt(focoPlayer);
        
    }
}
