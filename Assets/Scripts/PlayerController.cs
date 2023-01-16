using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Text phasesDisplayText;
    private Touch theTouch;
    private float timeTounchEnded;
    private float displayTime = 0.5f;
    private float _current, _target, 
        xRange=3.5f, yRange=7.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Shoot), 2, 0.5f);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // desktop/web key input
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        // mobile touches
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                phasesDisplayText.text = theTouch.phase.ToString();
                timeTounchEnded = Time.time;
            }
            else if (Time.time - timeTounchEnded > displayTime)
            {
                if (theTouch.phase == TouchPhase.Stationary || theTouch.phase == TouchPhase.Moved)
                {
                    timeTounchEnded = Time.time;
                    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(theTouch.position.x, theTouch.position.y, 10));
                    _target = _target == 0 ? 1 : 0;
                    _current = Mathf.MoveTowards(_current, _target, speed * Time.deltaTime);
                    phasesDisplayText.text = theTouch.phase.ToString() + " X:" + touchPosition.x + ",Y:" + touchPosition.y+"current : "+ _current;

                    transform.position = Vector3.Lerp(transform.position, touchPosition, _current);
                }
            }
        }
        else if (Time.time - timeTounchEnded > displayTime)
        {
            phasesDisplayText.text = "";
        }
        if (GameManager.Instance.GetPlayerHealth()<0)
        {
            Destroy(gameObject);
            Debug.Log("GameOver!");
        }
        // limit player posisiton to keep inside the camera
        if (transform.position.x>xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, 0);
        }
        if (transform.position.x<-xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, 0);
        }
        if (transform.position.y>yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, 0);
        }
        if (transform.position.y<-yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, 0);
        }
    }
    void Shoot()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(projectile, pos, transform.rotation);
    }
}
