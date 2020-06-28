using UnityEngine;


public abstract class AbstractUnit : MonoBehaviour
{
    public int hitPoints;
    protected int currentHitPoints;
    public bool isAlive;


    protected abstract void Kill();
    protected void CheckHp()
    {
        if (isAlive)
        {
            if (currentHitPoints <= 0)
            {
                Kill();
                isAlive = false;
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHitPoints -= damage;
    }
    public void HealBy(int amount)
    {
        currentHitPoints += amount;
    }
    
}
