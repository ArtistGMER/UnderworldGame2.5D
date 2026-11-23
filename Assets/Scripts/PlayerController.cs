
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PrincessBody;
    public SpriteRenderer sr;
    public LayerMask LandLayer;

    public float speed;
    public float groundDistance;
    public int Health = 100;
    public TextMeshProUGUI PlayerHealth;
    public float HitTime;
    public bool FightMode;
    public bool HelpMode;
    public static PlayerController Player;
    
    void Start()
    {
        Player = this;
        PrincessBody = gameObject.GetComponent<Rigidbody>();
        FightMode = false;
        HelpMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealth.text = "Health" + "\n" + Health;

        HitTime -= Time.deltaTime;
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, LandLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDistance;
                transform.position = movePos;
            } 
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        PrincessBody.linearVelocity = moveDir * speed;

        if (x != 0 && x < 0)
        {
            sr.flipX = true;

        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }

        

       SwitchModes();
    }
  
    public void OnCollisionEnter(Collision collision)
    {
        
        

        if (collision.gameObject.CompareTag("Enemy") && HitTime !<= 0)
        {
            Debug.Log("HEALTHLOST");
            Health -= 5;
            HitTime = 5f;

        }
    }
    //This is how she will swap from HELP to FIGHT modes. Need to make it so that the player can only cause damage in FIGHT MODE, and can only help in HELP MODE
    public void SwitchModes()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            FightMode = false; HelpMode = true;
            sr.color = Color.softRed;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            FightMode = true; HelpMode = false;
            sr.color = Color.lightPink;
        }
    }
   
}
