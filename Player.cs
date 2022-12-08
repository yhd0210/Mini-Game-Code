using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("HP")] 
    [SerializeField]public float hp;
    [SerializeField]public float damage;

    public Text HpText;
    
    // Start is called before the first frame update
    void Start()
    {
        HpText.text = $"HP: {hp}";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(message: $"object name: {col.gameObject.tag}");
        if (col.gameObject.CompareTag("Monster"))
        {
            hp--;
            HpText.text = $"HP: {hp}";
            if (hp <= 0)
            {
                SceneManager.LoadScene("End");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
