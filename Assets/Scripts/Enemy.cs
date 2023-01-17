using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int Health = 1;
    [SerializeField]
    private float Speed = 5f;
    [SerializeField]
    private int score = 1;
    [SerializeField]
    private float Lifetime = 8.0f;

    // POLYMORPHISM // INHERITANCE
    public virtual void Move()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // ENCAPSULATION
    public void SetHealth(int health)
    {
        this.Health = health;
    }
    public int GetHealth()
    {
        return this.Health;
    }
    // ENCAPSULATION
    public void SetSpeed(float speed)
    {
        this.Speed = speed;
    }
    public float GetSpeed()
    {
        return this.Speed;
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy(gameObject, Lifetime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {            
            Destroy(other.gameObject);
            Health--;
            if (Health < 1)
            {
                Destroy(gameObject);
                GameManager.Instance.AddScore(score);
            }
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.HitByEnemy(Health);
        }
    }
}
