using Unity.VisualScripting;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    public GameObject backgroundImage;
    int interval = -100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            interval += 19;
            GameObject Clone = Instantiate(backgroundImage);

            Clone.transform.localScale = new Vector2(1.193314f, 1.141491f);
            Clone.transform.position = new Vector2(interval, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
