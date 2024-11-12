using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;
    public int damageAmount = 1;

    void Update()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceFromPlayer <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);

            //depending on the distance
            if (distanceFromPlayer > attackRange)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                AttackPlayer();
                print("Attacked");
            }
        }
    }

    void AttackPlayer()
    {
        if (attackTimer <= 0f)
        {
            Debug.Log("TargetFound");
            attackTimer = attackCooldown;// might not want this and could have a function that uses this towards the dynamic difficulty
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {

    Debug.Log("Collision detected with: " + other.gameObject.name);

    if (other.CompareTag("Player"))
    {
        Debug.Log("Player detected");

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            Debug.Log("Player has health component");
            playerHealth.TakeDamage(damageAmount);
            Destroy(gameObject);
            Debug.Log("Enemy destroyed after dealing damage");
        }
    }
}
    //private void OnCollisionEnter(Collision collision)
    //{

    //}

    void DestroySelf()
    {
        Destroy(gameObject);
        //Destroy(gameObjectWithTag("ENemy"));
    }
}
