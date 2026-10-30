using UnityEngine;
using UnityEngine.AI;

public class RegularNPC : MonoBehaviour
{
    public bool Helped;
    public bool NeedsHelp;
    public float HelpingTimer;
    public float TimeToHelp;
    public GameManager Manager;
    public NavMeshAgent RegNPC;
    void Start()
    {
        Helped = false;
        NeedsHelp = true;
        HelpingTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        HelpingTimer  -= Time.deltaTime;
        TimeToHelp -= Time.deltaTime;
        if (HelpingTimer <= 0)
        {
            NeedsHelp = true;
            Helped = false;
            TimeToHelp = 10f;
            if (TimeToHelp == 10f)
            {
                HelpingTimer = 10f;
                TimeToHelp -= Time.deltaTime;
            }
            
        }
        
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("Enter");
        if (Input.GetKeyDown(KeyCode.Q) && HelpingTimer <= 0 && TimeToHelp > 0)
        {
            Debug.Log("Helped");
            Helped = true;
            NeedsHelp = false;
            
            if (Manager.Happiness < 100)
            {
                Debug.Log("Happy up!");
                Manager.Happiness += 10;
            }
           
            HelpingTimer = 5f;
            
        }
        else if (Input.GetKeyDown(KeyCode.Q) && HelpingTimer < 0 && TimeToHelp < 0)
        {
            Manager.Happiness -= 10;

        }
      
    }
    
}
