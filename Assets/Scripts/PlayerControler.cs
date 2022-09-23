using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 6.0f;
    public bool hasPowerUp = false;
    private float powerUpStrenght = 15.0f;
    public GameObject powerUpIndicator;
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
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        

    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerCountDownRoutine());
            powerUpIndicator.gameObject.SetActive(true);

        }

    }

    IEnumerator PowerCountDownRoutine()
    {
        yield return new WaitForSeconds(8);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided wit " + collision.gameObject.name + "with powerUp set to" + hasPowerUp);
            enemyRigidody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);

        }
    }
}
