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
    public float minTime= 20f;
    public float maxTime = 40f;
    public GameObject NeedsHelpUI;
    void Start()
    {
        Helped = false;
        
        HelpingTimer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (!NeedsHelp)
        {
            HelpingTimer -= Time.deltaTime;

            if (HelpingTimer <= 0)
            {
                NeedsHelp = true;
                NeedsHelpUI.gameObject.SetActive(true);
                Helped = false;
                TimeToHelp = 10f;
            }

        }

        if (NeedsHelp && !Helped)
        {
            TimeToHelp -= Time.deltaTime;
            if (TimeToHelp <= 0)
            {
                Manager.Happiness -= 10;
                NeedsHelp = false;
                NeedsHelpUI.gameObject.SetActive(false);
                HelpingTimer = Random.Range(minTime, maxTime);
            }
            if (Helped && TimeToHelp > 0)
            {
                HelpingTimer = 10f;

            }

        }
        

    }
    public void OnTriggerStay(Collider other)
    {   
        if (PlayerController.Player.HelpMode == true && other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.LeftShift)&& TimeToHelp >= 0)
        {

            Debug.Log("Helped");
            Helped = true;
            NeedsHelp = false;
            NeedsHelpUI.gameObject.SetActive(false);

            if (Manager.Happiness < 100)
            {
                Debug.Log("Happy up!");
                Manager.Happiness += 10;
            }
           
            HelpingTimer = Random.Range(minTime, maxTime);
            
        }
       
      
    }
    
}
