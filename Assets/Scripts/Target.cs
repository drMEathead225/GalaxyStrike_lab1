using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private float score;
    [SerializeField] GameObject boomVFX;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            ExecuteDeath();
        }
    }

    void ExecuteDeath()
    {
        Instantiate(boomVFX, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}