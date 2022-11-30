using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public Text CoinText;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int Coinamount;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // küredeki rigidbody eklentisinden bilgiyi al
        Coinamount = 0;
        SetCoinText();

    }

    void OnMove(InputValue movementValue)   //gelen inputlarý movementValue diye isimlendir
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  // inputlarý x,y ye göre yansýtma

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            Coinamount = Coinamount + 1;
            SetCoinText();
        }
    }

    void SetCoinText()
    {
        CoinText.text = "Coins : " + Coinamount.ToString();
    }




}
