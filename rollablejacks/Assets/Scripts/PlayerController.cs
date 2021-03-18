using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float ballSpeed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Debug.Log(count);
        SetCountText();
        winTextObject.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/12";
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * ballSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
        other.gameObject.SetActive(false);
        count++;

        SetCountText();
        Debug.Log(count);
        }
    }
}
