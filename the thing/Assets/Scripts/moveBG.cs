using Unity.VisualScripting;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    public GameObject backgroundImage;
    int interval = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            interval += 19;
            GameObject Clone = Instantiate(backgroundImage);

            Clone.transform.position = new Vector2(interval, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
