
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;

    SpriteRenderer sRenderer;

    float currentHealth;


    bool isDead;
    Color originalColor;

    [Serializable]
    public class SerializableEvent : UnityEvent { }

    [SerializeField] public SerializableEvent onTakeDamage;
    [SerializeField] public SerializableEvent onDie;


    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        originalColor = sRenderer.color;
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetHealthFraction()
    {
        return currentHealth / maxHealth;
    }

    public void RestoreHealth(float value)
    {
        if (isDead) return;

        currentHealth = Mathf.Min(currentHealth + value, maxHealth);
    }

    public void TakeDamage(float damage, bool autoDamage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        if (isDead) return;

        if (!autoDamage)
        {
            onTakeDamage.Invoke();

            StopAllCoroutines();
            StartCoroutine(ChangeColor());
        }

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private IEnumerator ChangeColor()
    {
        sRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sRenderer.color = originalColor;
    }

    private void Die()
    {
        onDie.Invoke();
        isDead = true;
        Destroy(gameObject);
    }

}
