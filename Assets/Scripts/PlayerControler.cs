using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 6.0f;
    public bool hasPowerUp;

    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {

        float forwardInput = Input.GetAxis("Vertical");

        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);

        
    }

    private void onTriggeEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }

    }
}
