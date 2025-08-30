using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 5f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0.5f;
    Coroutine firingCoroutine;

    [HideInInspector] public bool isFiring;
    AudioPlayer audioPlayer;


    void Start()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
        if (useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                                transform.position,
                                                Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(1 / GetRandomFiringRate());
        }
    }
    
    float GetRandomFiringRate()
    {
        float randRate = Random.Range(firingRate - firingRateVariance,
                                        firingRate + firingRateVariance);

        return Mathf.Clamp(randRate, minFiringRate, float.MaxValue);
    }
}
