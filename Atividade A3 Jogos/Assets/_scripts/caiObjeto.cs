using UnityEngine;

public class caiObjeto : MonoBehaviour
{
    public GameObject objeto;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
           objeto.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
