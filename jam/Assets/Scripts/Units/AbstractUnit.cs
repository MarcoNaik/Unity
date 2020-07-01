using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public abstract class AbstractUnit : MonoBehaviour, IUnit
    {
        public UnitController UnitController { get; set; }
        
        public int powerLevel;
        public int maxHP;
        private int CurrentHP { get; set; }
        private bool Attacked { get; set;}
        public bool Alive { get; set;}
        
           
        private Rigidbody rb;


        private void Awake()
        {
            UnitController = GetComponent<UnitController>();
            CurrentHP = maxHP;
            rb = GetComponent<Rigidbody>();
        }

        public bool HasAttacked()
        {
            return Attacked;
        }
        

        public int getPowerLever()
        {
            return powerLevel;
        }


        public void Attack(AbstractUnit attackReceiver)
        {
            Vector3 startPos = transform.position;
            Move(attackReceiver.transform.position, 0.2f);
            attackReceiver.TakeDamage(powerLevel);
            Attacked = true;
            Move(startPos, 0.1f);
            
            
        }

        private void Move(Vector3 endPos, float threshold)
        {
            Vector3 startPos = transform.position;
            float distance = (startPos - endPos).magnitude;
            Vector3 directionNorm = (startPos - endPos).normalized;
            while(distance>threshold)
            {
                transform.position += directionNorm * Time.fixedDeltaTime;
                directionNorm = (startPos - endPos).normalized;
                distance = (startPos - endPos).magnitude;
            }
        }
        
        public void TakeDamage(int powerLevel)
        {
            CurrentHP -= powerLevel;
            if (CurrentHP <= 0) Die();
        }
        private void Die()
        {
            Alive = false;
            rb.GetComponent<Collider>().enabled = false;
            rb.AddForce(Random.Range(-100,100),100, Random.Range(-100,100));
        }
        
        public abstract void AddToTile(GameObject tile);
    }
}