using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody PrincessBody;
    public SpriteRenderer sr;
    public LayerMask LandLayer;

    public float speed;
    public float groundDistance;
    void Start()
    {
        PrincessBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
