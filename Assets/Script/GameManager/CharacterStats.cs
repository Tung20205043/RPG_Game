using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Singleton
    public static CharacterStats Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [Header("Player Stat")]
    [SerializeField] private float playerAtk = 10f;
    [SerializeField] private float playerHp = 100f;
    [SerializeField] private float playerDef = 0f;
    [SerializeField] private float playerAtkSpd  = 1f;
    [SerializeField] private float playerMoveSpd = 5f;

    private float currentGold = 2000f;

    [Header("Enemy Stat")]
    [SerializeField] private float enemyAtk;
    [SerializeField] private float enemyHp;
    [SerializeField] private float enemyDef;
    [SerializeField] private float enemywalkSpd = 2f;
    [SerializeField] private float enemyRunSpd = 5f;
    [SerializeField] private float enemyAtkSpd = 3f;

    public float PlayerAtk => playerAtk;
    public float PlayerHp => playerHp;
    public float PlayerDef => playerDef;    
    public float PlayerAtkSpd => playerAtkSpd;
    public float PlayerMoveSpd => playerMoveSpd;

    public float CurrentGold => currentGold;
    public float EnemyAtk => enemyAtk;
    public float EnemyHp => enemyHp;
    public float EnemyDef => enemyDef;

    public float EnemyWalkSpd => enemywalkSpd;
    public float EnemyRunSpd => enemyRunSpd;
    public float EnemyAtkSpd => enemyAtkSpd;

    public void PlusGold(float gold) { 
        currentGold += gold;
    }
}
