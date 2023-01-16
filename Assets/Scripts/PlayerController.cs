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

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //foreach (Touch touch in Input.touches)
        //{
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        transform.Translate(touch.position * speed * Time.deltaTime);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    transform.Translate(Input.mousePosition * speed * Time.deltaTime);
        //}
        if (Input.touchCount>0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                phasesDisplayText.text = theTouch.phase.ToString();
                timeTounchEnded = Time.time;
            }
            else if (Time.time - timeTounchEnded > displayTime)
            {
                phasesDisplayText.text = theTouch.phase.ToString();
                timeTounchEnded = Time.time;
            }
        }
        else if(Time.time - timeTounchEnded > displayTime)
        {
            phasesDisplayText.text = "";
        }
    }
    void SpawnObject(Vector3 pos)
    {
        // spawn object
        Instantiate(projectile, pos, transform.rotation);

    }
}
