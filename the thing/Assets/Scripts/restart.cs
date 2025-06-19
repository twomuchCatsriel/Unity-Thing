using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    InputAction reset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset = InputSystem.actions.FindAction("Reset");
    }

    // Update is called once per frame
    void Update()
    {
        if (reset.triggered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
