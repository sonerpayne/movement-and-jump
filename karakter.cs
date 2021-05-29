using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter : MonoBehaviour
{
    public float hiz, input, ziplamaGucu;
    public Rigidbody2D rb;
    public bool yerde, ziplayabilir;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        input = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && yerde == true) ziplayabilir = true;
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(input, 0, 0) * hiz * Time.deltaTime;
        karakteriDondur();
        if (ziplayabilir == true)
        {
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse);
            ziplayabilir = false;
            yerde = false;
        }
    }


    void karakteriDondur()
    {
        if (input < 0) transform.rotation = new Quaternion(0, 180, 0, 0);
        else if (input > 0) transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin")) yerde = true;
    }
}
