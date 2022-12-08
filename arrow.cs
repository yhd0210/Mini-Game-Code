using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class arrow : MonoBehaviour
{
    float angle;
    Vector2 target, mouse;
    public GameObject bulletPrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        target=(Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    void Follow()
    {
        mouse = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);//월드 좌표로 변경
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;//
        transform.rotation=Quaternion.AngleAxis(angle-90,Vector3.forward);
    }
    
}
