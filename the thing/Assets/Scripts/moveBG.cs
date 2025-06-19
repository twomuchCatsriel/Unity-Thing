using Unity.VisualScripting;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    public GameObject backgroundImage;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        backgroundImage.transform.position = player.transform.position;
    }
}
