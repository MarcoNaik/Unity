using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units
{
    public abstract class AbstractUnit : MonoBehaviour, IUnit
    {
        public UnitController UnitController { get; set; }
        
        public int powerLevel;
        public int maxHP;
        public int moveRange;
        private int CurrentHP { get; set; }
        public int CurrentMoveRange { get; set; }
        
        
        private bool Attacked { get; set;}
        public bool Alive { get; set;}
        

        private UnitMovementController movementController;
        
           
        private Rigidbody rb;
        private Collider _collider;

        public void CleanAttack()
        {
            Attacked = false;
        }


        private void Awake()
        {
            _collider = GetComponent<Collider>();
            UnitController = GetComponent<UnitController>();
            movementController = GetComponent<UnitMovementController>();
            CurrentHP = maxHP;
            CurrentMoveRange = moveRange;
            rb = GetComponent<Rigidbody>();
            Alive = true;
            Attacked = false;
        }

        public bool HasAttacked()
        {
            return Attacked;
        }
        

        public int getPowerLever()
        {
            return powerLevel;
        }


        public void Attack(IUnit attackReceiver)
        {
            attackReceiver.TakeDamage(powerLevel);
            Attacked = true;
        }
        public IEnumerator AttackCoroutine(AbstractUnit attackReceiver, bool bUnitAlive)
        {
            Vector3 endPos = attackReceiver.transform.position;
            Vector3 startPos = transform.position;
            float distance = (startPos - endPos).magnitude;
            Vector3 directionNorm = (endPos - startPos).normalized;
            float speed = 0.3f;
            
            while (distance > 0.2f)
            {
                Vector3 position = transform.position;
                
                directionNorm = (endPos - position).normalized;
                distance = (endPos - position).magnitude;
                
                transform.position += directionNorm *speed* Time.fixedDeltaTime;
                
                
                yield return null;
            }

           
            if (!bUnitAlive) StartCoroutine(attackReceiver.DieCoroutine(directionNorm));
            
            
            
            distance = (transform.position - startPos).magnitude;
            while (distance>0.01f)
            {
                Vector3 position = transform.position;
                
                directionNorm = (startPos- position).normalized;
                distance = (startPos- position).magnitude;

                transform.position += directionNorm * speed * Time.fixedDeltaTime;
                
                yield return null;
            }
            
        }
        


        public void TakeDamage(int powerLevel)
        {
            CurrentHP -= powerLevel;
            if (CurrentHP <= 0) Alive = false;
        }
        private IEnumerator DieCoroutine(Vector3 directionNorm)
        {
            directionNorm.y = 1;
            _collider.enabled = false;
            rb.AddForce(directionNorm*200);
            yield break;
        }
        
        public abstract void AddToTile(GameObject tile);

        public void ExitTile()
        {
            CurrentMoveRange--;
            Debug.Log("current move range : " + CurrentMoveRange);
        }
    }
}