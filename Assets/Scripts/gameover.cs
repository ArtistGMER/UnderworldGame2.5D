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
    private void Update()
    {

        
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;

        }

    }
    //public void OnMouseDown()
    //{
    //    if (Retry)
    //    {

    //        SceneManager.LoadScene(1);
    //    }
    //    if (Quit)
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}
    //void Update()
    //{
        
    //}
}
