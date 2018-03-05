using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    //Name the colors RGB for quick access and efficent speeds
    enum Colors {NONE, RED, GREEN, BLUE};

    public Text winText;
    public int thrust;
    public float maxVelocity;
    public Material default_color, red, green, blue;

    private Rigidbody rb;
    private MeshRenderer ren;
    private Colors color;
    private float sqrMaxVelocity;

    //When all objects have been initialized
    void Awake()
    {
        winText.text = "";
        color = Colors.NONE;
        rb = GetComponent<Rigidbody>();
        ren = GetComponent<MeshRenderer>();
        SetMaxVelocity(maxVelocity);
    }
    private void FixedUpdate()
    {

        //Obtain user force input
        float hForce = Input.GetAxis("Horizontal");
        float vForce = Input.GetAxis("Vertical");

        //Set direction based on u-input
        Vector3 direction = new Vector3(hForce, 0, vForce);

        //Add force
        rb.AddForce(direction * thrust, ForceMode.Acceleration);

        //Enforce maximum velocity
        Vector3 v = rb.velocity;
        if(v.sqrMagnitude > sqrMaxVelocity)
        {
            rb.velocity = v.normalized * maxVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Trigger the finish
        if(other.gameObject.CompareTag("Finish"))
        {
            winText.text = "Level-Complete";
        }

        //Key pickup
        if (other.gameObject.CompareTag("Key-Red"))
        {
            color = Colors.RED;
            other.gameObject.SetActive(false);
            ren.material = red;
            Debug.Log("Touched Red Key");
        }
        else if (other.gameObject.CompareTag("Key-Green"))
        {
            color = Colors.GREEN;
            other.gameObject.SetActive(false);
            ren.material = green;
            Debug.Log("Touched Green Key");
        }
        else if (other.gameObject.CompareTag("Key-Blue"))
        {
            color = Colors.BLUE;
            other.gameObject.SetActive(false);
            ren.material = blue;
            Debug.Log("Touched Red Key");
        }

        //If we trigger a default door
        if (other.gameObject.CompareTag("Door-Collider-None"))
        {
            ren.material = default_color;
            other.transform.parent.gameObject.SetActive(false);
        }
        else if(other.gameObject.CompareTag("Door-Collider-Red") && color == Colors.RED)
        {
            ren.material = default_color;
            other.transform.parent.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Door-Collider-Green") && color == Colors.GREEN)
        {
            ren.material = default_color;
            other.transform.parent.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Door-Collider-Blue") && color == Colors.BLUE)
        {
            ren.material = default_color;
            other.transform.parent.gameObject.SetActive(false);
        }

    }

    private void SetMaxVelocity(float maxVelocity)
    {
        this.maxVelocity = maxVelocity;
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }
}
