using System;
using UnityEngine;

public class EnemyController : AbstractUnit
{
    private PlayerController player;

    public float movementSpeed;
    public bool isEnemyEnabled = true;
    public int damage;
    public String enemyName;

    private Rigidbody rb;
    private Vector3 movement;
    
    private EnemyPooler pooler;

    private DropManager dropManager;

    private void Start()
    {
        isAlive = true;
        currentHitPoints = hitPoints;
        rb = GetComponent<Rigidbody>();
        pooler = EnemyPooler.Instance;
        player = FindObjectOfType<PlayerController>();
        dropManager = DropManager.Instance;
    }

    public void setCurretHitPoints(int newCurrentHp)
    {
        currentHitPoints = newCurrentHp;
    }

    void Update()
    {
        CheckHp();
        transform.LookAt(player.transform.position);


        movement = player.transform.position - transform.position;
        
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Attack(player);
            rb.MovePosition(rb.position - movement * movementSpeed);
        }
    }


    private void Attack(PlayerController player)
    {
        player.TakeDamage(damage);
    }

    protected override void Kill()
    {
        dropManager.DropRandomFood(gameObject);
        gameObject.SetActive(false);
        pooler.enqueueEnemy(gameObject);
        Debug.Log("Enemy ded");
        
    }
}
