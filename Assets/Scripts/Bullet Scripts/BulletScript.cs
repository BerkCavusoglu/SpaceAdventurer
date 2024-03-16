using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 1f;
    [HideInInspector]
    public bool is_EnemyBullet = false;
    
    void Start()
    {
        if (is_EnemyBullet)
        
            speed *= -1f;
        
        Invoke("DeactivateGameObject", deactivate_Timer);
        
    }


    void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy1")
        {
            ScoreManager.instance.AddScore(6);
        }
        else if (target.tag == "Enemy2")
        {
            ScoreManager.instance.AddScore(4);
        }
        else if (target.tag == "Enemy3")
        {
            ScoreManager.instance.AddScore(3);
        }
        else if (target.tag == "Enemy4")
        {
            ScoreManager.instance.AddScore(15);
        }

        gameObject.SetActive(false);
    }

}
