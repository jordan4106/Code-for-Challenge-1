using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText ();
        SetLivesText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        if (Input.GetKey("escape"))
        { 
            Application.Quit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pickup"))
        { 
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag("BadPickup"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }

    }

    void SetCountText()
    {
        countText.text = "<b>Count:</b> " + count.ToString ();
        if (count == 12)
        {
            transform.position = new Vector2(89.6f, -0.2f);
        }

        if (count >= 20)
        {
            winText.text = "<i>You Win! Game Created by Jordan Marr!</i>";
        }
    }
    void SetLivesText()
    {
        livesText.text = "<b>Lives:</b> " + lives.ToString ();
        if (lives <= 0)
        {
            Destroy(this);
            loseText.text = "<i>Sorry, You Lost! Please Exit and Try Again!</i>";
        }
    }

}
