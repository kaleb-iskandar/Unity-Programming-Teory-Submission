using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private float bulletLifetime = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveUpward(speed);
        Destroy(gameObject, bulletLifetime);
    }
    void MoveUpward(float speed)
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
