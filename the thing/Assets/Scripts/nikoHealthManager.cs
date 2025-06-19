using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nikoHealthManager : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("dead");
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectiles"))
        {
            health -= 1;
            healthText.text = "Health: " + health;
        }
    }
}
