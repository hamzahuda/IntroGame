using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 5;
    private Vector3 previousPos;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPositionText;
    public TextMeshProUGUI playerVelocityText;



    void Start()
    {
        count = 0;
        winText.text = "";
        SetCountText();
        previousPos = transform.position;
    }

    void OnMove(InputValue value) {
        moveValue = value.Get<Vector2>();
    }

    void Update() {
    
        playerPositionText.text = "Position: " + transform.position.ToString();
    }

    void FixedUpdate()
    {
        playerVelocityText.text = "Velocity: " + ((transform.position - previousPos).magnitude / Time.fixedDeltaTime).ToString("0.00");
        previousPos = transform.position;
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if(count >= numPickups)
        {
            winText.text = "You win!";
        }
    }
}
