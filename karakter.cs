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
        rb = GetComponent<Rigidbody2D>(); // rigidbody'nin tanımlanması
    }
    private void Update()
    {
        input = Input.GetAxis("Horizontal"); // unity kütüphanesinden girdi alıyoruz. Durunca 0, sağa gidince 1, sola gidince -1.
        if (Input.GetKeyDown(KeyCode.Space) && yerde == true) ziplayabilir = true; // kullanıcıdan girdi alıyoruz
    //  bunun yerine if (Input.GetButtonDown("Jump") && yerde == true) ziplayabilir = true; yazabilirsiniz.
    }
    private void FixedUpdate()
    {
        // hareket kodu
        transform.position += new Vector3(input, 0, 0) * hiz * Time.deltaTime;
        karakteriDondur();
        // ziplama kodu
        if (ziplayabilir == true)
        {
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode2D.Impulse); // y ekseninde (yukarı doğru) güç uygular
            // sürekli zıplamamak için iki değişkeni de false yapıyoruz...
            ziplayabilir = false; 
            yerde = false;
        }
    }

    // karakteri döndürmek için fonksiyon
    void karakteriDondur()
    {
        // videodakinde new Quaternion yazıyor fakat kafanız karışmasın diye böyle de yapabilirsiniz, iki türlü de çalışır.
        if (input < 0) transform.rotation = Quaternion.Euler(0,180,0);
        else if (input > 0) transform.rotation = Quaternion.identity;
    }

    // zemin kontrolü
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin")) yerde = true;
    }
}
