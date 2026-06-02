using UnityEngine;

public class AttackState : BaseState
{
    private float losePlayerTimer;
    private float moveTimer;
    private float shootTimer;
    public override void Enter() { }

    public override void Exit() { }

    public override void Perform()
    {
        if (enemy.CanSeePlayer()) 
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shootTimer > enemy.fireRate)
            {
                Shoot();
            }

            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPos = enemy.Player.transform.position; // kratame tin thesi pou eidame teleutaia fora ton player
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 2)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }

    }

    public void Shoot()
    {
        Debug.Log("shoot");

        Transform gunBarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().linearVelocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;
        shootTimer = 0;
    }
}