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
    [SerializeField] private float playerAtkSpd  = 1f;
    [SerializeField] private float playerMoveSpd = 5f;


    [Header("Enemy Stat")]
    [SerializeField] private float enemywalkSpd = 2f;
    [SerializeField] private float enemyRunSpd = 5f;
    [SerializeField] private float enemyAtkSpd = 3f;

    public float PlayerAtkSpd => playerAtkSpd;
    public float PlayerMoveSpd => playerMoveSpd;

    public float EnemyWalkSpd => enemywalkSpd;
    public float EnemyRunSpd => enemyRunSpd;
    public float EnemyAtkSpd => enemyAtkSpd;

    
}
