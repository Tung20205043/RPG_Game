using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayScreenUI : MonoBehaviour {
    [SerializeField] private Button AttackButton;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Button openButton;
    [SerializeField] private Button claimButton;

    [SerializeField] private itemModel item;
    public void Awake() {
        AttackButton.onClick.AddListener(AttackButtonClick);
        openButton.onClick.AddListener(OpenChestUI);
        claimButton.onClick.AddListener(ClaimItem);
    }

    private void AttackButtonClick() {
        playerController.Attack(); 
    }
    private void OpenChestUI() {
        ChestManager.Instance.OpenChest();
        claimButton.gameObject.SetActive(true);
    }
    private void ClaimItem() { 
        claimButton.gameObject.SetActive(false);
        SetActiveItem();
    }
    public void SetActiveItem() {
        item.ClaimItem();
    }
}
