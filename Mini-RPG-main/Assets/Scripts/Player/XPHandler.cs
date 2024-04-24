using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPHandler : MonoBehaviour
{
    public static XPHandler instance;

    [SerializeField] private int xpToLevelUp;
    [SerializeField] private int newXpRange;
    private int level = 1;
    private int currentXp = 0;

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
    }
	
    public void AddXP(int xp)
    {
        currentXp += xp;
        CheckXP();
    }

    private void CheckXP()
    {
        if (currentXp >= xpToLevelUp)
        {
            level++;
            currentXp = 0;
            xpToLevelUp += newXpRange;
            print($"You leveled up! New XP necessary: " + xpToLevelUp);
        }
        
        UIHandler.instance.UpdateXpUi(level, currentXp, xpToLevelUp);
    }
}
