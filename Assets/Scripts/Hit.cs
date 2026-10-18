using Unity.VisualScripting;
using UnityEngine;

public class HitPoints : MonoBehaviour
{
    [SerializeField] int hitPoints = 1;
    [SerializeField] int scoreValue = 100;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] ScoreManager scoreManager;

    public void TakeHit(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            // Add score
            if (ScoreManager.Instance != null)
            {
                var manager = ScoreManager.Instance as ScoreManager;
                manager?.AddScore(scoreValue);
            }

            // Play the explosion
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // Disable this target instead of destroying it
            gameObject.SetActive(false);
        }
    }
}