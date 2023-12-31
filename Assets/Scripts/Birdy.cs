using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdy : MonoBehaviour
{
    public float velocity = 1f;
    public Rigidbody2D rb2d;
    public bool isDead = true;
    private bool loginNow = true;

    public GameManager GameManager;
    public GameObject StartScreen;
    public GameObject DeathScreen;

    void Start()
    {
        if(!loginNow)
        {
            StartScreen.SetActive(false);
        }
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.up * velocity;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "ScoreArea")
        {
            GameManager.UpdateScore();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
        }
    }
    public void StartGame()
    {
        isDead = false;
        loginNow = false;
        Time.timeScale = 1;
        StartScreen.SetActive(false);
    }

}
