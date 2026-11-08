using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public TextMeshProUGUI HPScoreText;
    public TextMeshProUGUI CPScoreText;
    public Button Retry;
    public Button Quit;
   
    public void SetUp(int score)
    {
        gameObject.SetActive(true);
        HPScoreText.text = "Happiness Score" + "\n" + GameManager.GM.Happiness;
        CPScoreText.text = "CenterPoint Score" + " \n" + GameManager.GM.CenterHealth;
    }
    public void OnMouseDown()
    {
        if (Retry != null)
        {

            SceneManager.LoadScene(0);
        }
        if (Quit != null)
        {

        }
    }
    void Update()
    {
        
    }
}
