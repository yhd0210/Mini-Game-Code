using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    public Vector2 direction;
    public void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        target = GameObject.Find("player").transform;
        direction = (Vector2) (target.position - transform.position);
        direction.Normalize();
        transform.Translate(new Vector3(target.position.x+direction.x,target.position.y+direction.y)*speed*Time.deltaTime); 
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("Green"))
        {
            Destroy(gameObject);
        }
    }
}
