using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScreenUI : MonoBehaviour {
    [SerializeField] private Button AttackButton;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Button openButton;
    public void Awake() {
        AttackButton.onClick.AddListener(AttackButtonClick);
        openButton.onClick.AddListener(OpenChestUI);
    }

    private void AttackButtonClick() {
        playerController.Attack(); 
    }
    private void OpenChestUI() {
        ChestManager.Instance.OpenChest();

    }
}
