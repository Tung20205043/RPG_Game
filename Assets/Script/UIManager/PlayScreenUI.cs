using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayScreenUI : MonoBehaviour {
    
    [SerializeField] private PlayerController playerController;
    [Header("Button")]
    [SerializeField] private Button AttackButton;
    [SerializeField] private Button openButton;
    [SerializeField] private Button claimButton;
    [SerializeField] private Button bagButton;
    [SerializeField] private Button xButton;
    [Header("")]
    [SerializeField] private itemModel item;
    [SerializeField] private TextMeshProUGUI currentGold;
    public void Awake() {
        AttackButton.onClick.AddListener(AttackButtonClick);
        openButton.onClick.AddListener(OpenChestUI);
        claimButton.onClick.AddListener(ClaimItem);
        bagButton.onClick.AddListener(() => BagView(true));
        xButton.onClick.AddListener(() =>BagView(false));    
    }
    private void Update() {
        currentGold.text = CharacterStats.Instance.CurrentGold.ToString();
    }
    private void AttackButtonClick() {
        playerController.Attack(); 
    }
    private void OpenChestUI() {
        ChestManager.Instance.OpenChest();
        claimButton.gameObject.SetActive(true);
        item.gameObject.SetActive(true);
    }
    private void ClaimItem() { 
        claimButton.gameObject.SetActive(false);
        SetActiveItem();
    }
    public void SetActiveItem() {
        item.ClaimItem();
    }
    private void BagView(bool view) {
        if (view) {
            InventoryManager.Instance.Show();
        } else {
            InventoryManager.Instance.Hide();
        }
        bagButton.interactable = !view;
    }
}
