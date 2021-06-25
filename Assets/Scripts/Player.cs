using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rb;

    [SerializeField]
    private float _jumpForce;

    private string currentColor;

    private SpriteRenderer spriteRenderer;



    //Colors 

    [SerializeField]
    private Color Cyan;

    [SerializeField]
    private Color Yellow;

    [SerializeField]
    private Color Pink;

    [SerializeField]
    private Color Purple;

    private int count;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highScoreText;


    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _jumpForce = 8f;
        count = 0;
        scoreText.text = "Score : " + count.ToString();
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetRandomColor();
    }

    private void Update() {
        

        if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) {
            _rb.velocity = Vector2.up * _jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if(collider.tag == "NewColor") {
            SetRandomColor();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag == "Star") {
            //Add Score            
            AddScore();
            Destroy(collider.gameObject);
            return;
        }

        if (collider.tag != currentColor) {

            if (PlayerPrefs.HasKey("HighScore")) {
                //Compare
                if(PlayerPrefs.GetInt("HighScore") < count) {
                    PlayerPrefs.SetInt("HighScore", count);
                }
            }
            else {
                PlayerPrefs.SetInt("HighScore", count);
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void AddScore() {
        count++;
        scoreText.text = "Score : " + count.ToString();
    }

    private void SetRandomColor() {

        int rnd = Random.Range(0, 4);

        switch (rnd) {
            case 0:
                currentColor = "Cyan";
                spriteRenderer.color = Cyan;
                break;
            case 1:
                currentColor = "Yellow";
                spriteRenderer.color = Yellow;
                break;
            case 2:
                currentColor = "Pink";
                spriteRenderer.color = Pink;
                break;
            case 3:
                currentColor = "Purple";
                spriteRenderer.color = Purple;
                break;
        }
    }
}
