using NUnit.Framework.Constraints;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI; // NavMesh Components(Nav = Navigation)
public class EnemyScript : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    
    public NavMeshAgent Agent{ get => agent; }
    public GameObject Player { get => player; }

    public string currentState;
    public Path path; // tha einai ena script gia thn diadromi pou tha akolouthei o enemy
    
    private GameObject player;
    
    private Vector3 LastKnownPosition;

    private Vector3 lastKnownPos;
    public Vector3 LastKnownPos { get => lastKnownPos; set => lastKnownPos = value; }
    
    [Header("Sight Values")]
    public float Sightdistance = 20f; //poso makria vlepei ton paikth
    public float fieldofview = 85f;// H gonia pou vlepei ton paikth
    public float eyeHeight = 0.6f;
    
    
    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();// mia sunartish pou tha epistrefei true/false
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < Sightdistance)
            {
                Vector3 targetdirection = player.transform.position - transform.position;
                float angleToplayer = Vector3.Angle(targetdirection, transform.forward);
                if(angleToplayer >=  -fieldofview && angleToplayer <= fieldofview)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up*eyeHeight), targetdirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo ,Sightdistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * Sightdistance, Color.red);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    
}
