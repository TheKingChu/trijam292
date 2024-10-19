using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class CreatureBase : MonoBehaviour
{
    protected bool isPoppedUp = false;
    protected float timer = 0f;

    public KeyCode assignedKey;

    public float popupTime = 2f;
    public float popdownTime = 1f;
    private float currentPopupTime;
    private float currentPopdownTime;

    private ScoreManager scoreManager;
    private WaterManager waterManager;

    public GameObject hitEffect;

    protected virtual void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        waterManager = FindObjectOfType<WaterManager>();

        currentPopupTime = popupTime;
        currentPopdownTime = popdownTime;
    }

    protected virtual void Popup()
    {
        isPoppedUp = true;
        timer = 0f;
        transform.Translate(Vector3.up * 1f);
    }

    protected virtual void Popdown()
    {
        isPoppedUp = false;
        timer = 0f;
        transform.Translate(Vector3.down * 3f);
    }

    protected virtual void Bop()
    {
        isPoppedUp = false;
        SoundManager.instance.PlaySoundEffect(1);
        timer = 0f;
        Debug.Log("Creature bopped");
        transform.Translate(Vector3.up * 1f);

        //add points
        if (scoreManager != null)
        {
            scoreManager.AddPoints(10);
        }

        if (hitEffect != null)
        {
            // Create the effect at the creature's position
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            if (waterManager != null)
            {
                waterManager.RiseWaterLevel();
            }
            if (scoreManager != null)
            {
                scoreManager.MissedHit(); // Reset multiplier on miss
            }
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Bop();
        }
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;

        AdjustSpeed();

        if (!isPoppedUp && timer >= currentPopupTime)
        {
            Popdown();
        }

        if(isPoppedUp && Input.GetKeyDown(assignedKey))
        {
            Bop();
        }
    }

    private void AdjustSpeed()
    {
        float elapsedTime = Time.timeSinceLevelLoad;

        currentPopupTime = Mathf.Max(popupTime - (elapsedTime / 60), 0.5f);
        currentPopdownTime = Mathf.Max(popdownTime - (elapsedTime / 60), 0.5f);
    }
}
