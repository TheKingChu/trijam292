using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public Transform waterLevel;
    public List<Transform> holes;
    public float riseAmount = 0.1f;
    public float fallAmount = 0.1f;
    public float riseSpeed = 0.1f;
    public float fallSpeed = 0.1f;
    public float maxHealth = 10f;
    private float currentHealth;

    public GameObject gameOver;
    public TMP_Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
        gameOver.SetActive(false);
    }

    public void RiseWaterLevel()
    {
        currentHealth -= 1;
        StartCoroutine(RiseWaterEffect());

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void LowerWaterLevel()
    {
        currentHealth += 1;
        StartCoroutine(LowerWaterEffect());
    }

    private IEnumerator RiseWaterEffect()
    {
        float targetY = waterLevel.position.y + riseAmount;
        SoundManager.instance.PlaySoundEffect(2);

        while(waterLevel.position.y < targetY)
        {
            float step = riseSpeed * Time.deltaTime;
            waterLevel.position += new Vector3(0, step, 0);
            foreach(Transform hole in holes)
            {
                hole.position += new Vector3(0, step, 0);
            }
            yield return null;
        }
    }

    private IEnumerator LowerWaterEffect()
    {
        float targetY = waterLevel.position.y - fallAmount;
        while (waterLevel.position.y > targetY)
        {
            float step = fallSpeed * Time.deltaTime;
            waterLevel.position -= new Vector3(0, step, 0);
            foreach (Transform hole in holes)
            {
                hole.position -= new Vector3(0, step, 0);
            }
            yield return null;
        }
    }

    private void GameOver()
    {
        finalScoreText.text = "Final Score: " + FindObjectOfType<ScoreManager>().score;
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
