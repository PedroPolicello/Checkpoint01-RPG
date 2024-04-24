using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;
    
    [Header("XP Info")]
    [SerializeField] private Slider xpSlider;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI xpAtual;
    [SerializeField] private TextMeshProUGUI xpParaSubirDeNivel;

    [Header("Life Info")] 
    [SerializeField] private Slider lifeSlider;
    [SerializeField] private TextMeshProUGUI maxLifeText;
    [SerializeField] private TextMeshProUGUI currentLifeText;

    [Header("Pause Info")] 
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        pauseMenu.SetActive(false);
    }
    
    public void UpdateXpUi(int level, int currentXp, int xpToLevelUp)
    {
        xpSlider.maxValue = xpToLevelUp;
        xpSlider.value = currentXp;
        
        levelText.text = level.ToString();
        xpAtual.text = currentXp.ToString();
        xpParaSubirDeNivel.text = xpToLevelUp.ToString();
    }

    public void UpdateLifeUi(float maxLife, float currentLife)
    {
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = currentLife;
        
        maxLifeText.text = maxLife.ToString();
        currentLifeText.text = currentLife.ToString();
    }

    public void Despause()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
