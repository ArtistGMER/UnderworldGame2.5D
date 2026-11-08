using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float CenterHealth;
    public float WaitTime;
    public float GameTime;
    public float Happiness;
    public TextMeshProUGUI HappyDisplay;
    public TextMeshProUGUI CenterHealthDisplay;
    public TextMeshProUGUI TimerDisplay;
    public static GameManager GM;
    public static GameObject EndScreen;
    void Start()
    {
        CenterHealth = 100;
        GameTime = 120f;
        Happiness = 100;
        EndScreen.gameObject.SetActive(false);

    }


    void Update()
    {
        HappyDisplay.text = "Happiness Level" + "\n" + Happiness;
        CenterHealthDisplay.text = "Center Health" + "\n" + CenterHealth;
        WaitTime -= Time.deltaTime;
        if (GameTime >= 0)
        {
            GameTime -= Time.deltaTime;
            UpdateTimerDisplay(GameTime);
        }
        else
        {
            GameTime = 0;
            TimerDisplay.text = "00:00";

        }

        if (CenterHealth <= 0)
        {
            Debug.Log("GAME OVER VIA CENTER");
            EndScreen.gameObject.SetActive(true);
        }
        if (GameTime <= 0)
        {
            EndScreen.gameObject.SetActive(true);
        }
    }
    public void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && WaitTime !<= 0)
        {
            CenterHealth -= 2;
            WaitTime = 5F;
            Debug.Log("HEALTHDOWN");
        }
    }
    public void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        TimerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
