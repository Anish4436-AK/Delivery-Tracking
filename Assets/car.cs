using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class car : MonoBehaviour
{
    [SerializeField] private float steering = 80f;
    [SerializeField] private float accelertion = 8f;

    [SerializeField] private bool istriggered = false;

    [SerializeField] private Color32 pickup = new Color32();
    [SerializeField] private Color32 delivery = new Color32();

    public TextMeshProUGUI Score;
    public int playerscore = 0;

    [SerializeField] private VariableJoystick Joystick;
    [SerializeField] private VariableJoystick Joystick2;

    public GameObject pickupobj;
    public GameObject deliveryobj;

    [SerializeField] private TextMeshProUGUI GameOver;

    float timer = 0;
    public float limit = 1;
    public int Countdown = 11;
    public TextMeshProUGUI timerr;

    //public TextMeshProUGUI triggered;
    //public TextMeshProUGUI collided;
    //int trigger = 0;
    //int collide = 0;
    private void Start()
	{
        deliveryobj.SetActive(false);
	}


	// Update is called once per frame
	void Update()
    {
         var HorizontalInput =Input.GetAxis("Horizontal") * -steering * Time.deltaTime;
         var VerticalInput = Input.GetAxis("Vertical") * accelertion * Time.deltaTime;

        //var VerticalInput = Joystick.Vertical * accelertion * Time.deltaTime;
        //var HorizontalInput = Joystick2.Horizontal * -steering * Time.deltaTime;
        // Debug.Log(posz + " " + posy);
        transform.Rotate(0, 0, HorizontalInput);
        transform.Translate(0, VerticalInput, 0);
        //Debug.Log("Hi...");
        //triggered.text = "Triggered=" + trigger;
        //collided.text = "Collided=" + collide;

        countdownn();
        if (Countdown == 0)
        {
            GameOver.text = ("Game Over");
        }
            
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag.Equals("PickUp") && istriggered == false)
        {
            Debug.Log("Pickup...");
            istriggered = true;
            GetComponent<SpriteRenderer>().color = pickup;
            pickupobj.SetActive(false);
            deliveryobj.SetActive(true);

            Countdown = 11;
           // playerscore += 1;
           // Debug.Log(playerscore);
            //Score = playerscore.ToString();
        }

        if (collision.tag.Equals("Delivery") && istriggered == true)
        {
            Debug.Log("Delivery...");
            istriggered = false;
            GetComponent<SpriteRenderer>().color = delivery;
            deliveryobj.SetActive(false);
            pickupobj.SetActive(true);

            Countdown = 11;
        }
        playerscore += 1;
        Score.text = (playerscore.ToString());
        Debug.Log(playerscore);
    }

	private void countdownn()
	{

        if (timer < limit)
        {
            timer = timer + Time.deltaTime;

        }
        
        else
        {
            Countdown -= 1;
            timerr.text = (Countdown.ToString());
            timer = 0;

        }
       if (Countdown == 0)
        {
            Countdown = 10;
        }
    }
}

