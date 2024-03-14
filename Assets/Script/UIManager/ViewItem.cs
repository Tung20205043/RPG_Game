using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ViewItem : MonoBehaviour {
    private CanvasGroup cvGr = null;
    public static ViewItem Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        sellButton.onClick.AddListener(SellItem);
        returnButton.onClick.AddListener(Return);
    }
    private void Start() {
        cvGr = GetComponent<CanvasGroup>();
    }
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI nameItem;
    [SerializeField] private TextMeshProUGUI[] stats;
    [SerializeField] private TextMeshProUGUI sellPrice;
    [SerializeField] private TextMeshProUGUI upgradePrice;

    [Header("Button")]
    [SerializeField] private Button sellButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button returnButton;
    public void ShowItem(ItemObject itemObj) {
        cvGr.Show();
        nameItem.text = itemObj.itemName;
        foreach (var attribute in itemObj.attributes) {
            stats[itemObj.attributes.IndexOf(attribute)].text = attribute.value.ToString();
        }
        
        sellPrice.text = GameConstants.goldSell[(int)itemObj.ItemLevel].ToString();
        upgradePrice.text = GameConstants.goldToUpgradeItem[(int)itemObj.ItemLevel].ToString(); 
    }
    public void SellItem() {
        cvGr.Hide();
        Delegate.sellThisItem();
    }
    public void Return() {
        cvGr.Hide(); 
    }
 
}
