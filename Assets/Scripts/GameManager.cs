using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float CenterHealth;
    public float GameTime;
    public float Happiness;
    public TextMeshProUGUI HappyDisplay;
    void Start()
    {
        CenterHealth = 200;
        GameTime = 60f;
        Happiness = 100;

    }

    // Update is called once per frame
    void Update()
    {
        HappyDisplay.text = "Happiness Level" + "\n" + Happiness;
        GameTime -= Time.deltaTime;
        if (CenterHealth <= 0)
        {
            Debug.Log("GAME OVER VIA CENTER");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            CenterHealth--;
        }
    }
}
