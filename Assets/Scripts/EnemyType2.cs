using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class EnemyType2 : Enemy
{
    private bool isMovingLeft=true;
    // POLYMORPHISM
    public override void Move()
    {
        transform.Translate(Vector3.down * GetSpeed() * Time.deltaTime);
        if (transform.position.x<-3.5f)
        {
            isMovingLeft = false;
            transform.Translate(Vector3.right * GetSpeed() * Time.deltaTime);
        }else
        if (transform.position.x>3.5f)
        {
            isMovingLeft = true;
            transform.Translate(Vector3.left * GetSpeed() * Time.deltaTime);
        }
        else
        {
            if (isMovingLeft)
            {
                transform.Translate(Vector3.left * GetSpeed() * Time.deltaTime);
            }else            
            {
                transform.Translate(Vector3.right * GetSpeed() * Time.deltaTime);
            }
        }
    }
}
