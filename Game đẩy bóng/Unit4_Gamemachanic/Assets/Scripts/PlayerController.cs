using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidPlayer;
    private GameObject focalPoint;
    public float speed=5;
    public bool haspowerup = false;
    public float strength = 10.0f;
    public GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        rigidPlayer = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwarfInput = Input.GetAxis("Vertical");
        rigidPlayer.AddForce(focalPoint.transform.forward*speed*forwarfInput, ForceMode.Force);
        powerup.transform.position = this.transform.position +new Vector3(0, -0.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("power up"))
        {
            haspowerup = true;
            powerup.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(countdown());
        }    
    }
    IEnumerator countdown()
    {
        yield return new WaitForSeconds(5);
        haspowerup = false;
        powerup.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy")&&haspowerup)
        {
            Debug.Log("Power!!!!");
            Rigidbody enemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away_player = (collision.gameObject.transform.position-transform.position);
            enemy.AddForce(away_player*strength, ForceMode.Impulse);
        }    
    }
}
