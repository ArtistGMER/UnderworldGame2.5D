using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startscreen : MonoBehaviour
{
    public Button StartButton;
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        
        if (StartButton != null)
        {
            SceneManager.LoadScene(1);
        }
    }
}
