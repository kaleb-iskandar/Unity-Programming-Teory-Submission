using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2 : Enemy
{
    [SerializeField]
    private float turningRadius = .5f;
    public override void Move()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
        if (transform.position.x<-3.5f)
        {
            transform.Rotate(Vector3.right * turningRadius);
        }
        if (transform.position.x>3.5f)
        {
            transform.Rotate(Vector3.left * turningRadius);
        }
    }
}
