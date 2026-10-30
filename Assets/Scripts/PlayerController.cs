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
    public float HitTime;

    void Start()
    {
        PrincessBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Health <= 0)
        {
            Debug.Log("GAME OVER");
        }
       
    }
  
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("0");
        

        if (collision.gameObject.CompareTag("Enemy") && HitTime !<= 0)
        {
            Debug.Log("HEALTHLOST");
            Health -= 5;
            HitTime = 5f;

        }
    }
}
