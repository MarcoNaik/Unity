using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class AbstractUnit : IUnit
    {
        private bool alive;

        private Rigidbody rb;

        public GameObject Owner { get; set; }
        

        public GameObject GameObject { get; set; }
        

        private bool attacked;
        public int powerLevel;
        public int maxHP;
        private int currentHP;

        protected AbstractUnit(GameObject thisObject, GameObject owner, int powerLevel, int maxHP)
        {
            Owner = owner;
            this.powerLevel = powerLevel;
            this.maxHP = maxHP;
            currentHP = maxHP;
            attacked = false;
            GameObject = thisObject;
            Alive = true;
            rb = thisObject.GetComponent<Rigidbody>();
        }

        
        
        public bool Alive
        {
            get => alive;
            set => alive = value;
        }

        
        public bool HasAttacked()
        {
            return attacked;
        }

        public int getPowerLever()
        {
            return powerLevel;
        }


        public void Attack(IUnit attackReceiver)
        {
            Debug.Log(GameObject.name + " attacked " + attackReceiver.GameObject.name);

            attackReceiver.TakeDamage(powerLevel);
            attacked = true;
        }
        public void TakeDamage(int powerLevel)
        {
            currentHP -= powerLevel;
            if (currentHP <= 0) Die();

        }
        private void Die()
        {
            Alive = false;
            rb.AddForce(100,100, 100);
        }
        
        public abstract void AddToTile(GameObject tile);
    }
}