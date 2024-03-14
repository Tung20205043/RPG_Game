using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
    public Image iconImg = null;

    public bool HasItem { get; private set; }
    public itemModel itemModel = null;
    public ItemObject itemObj = null;

    public static UnityEvent<InventorySlot> EquipEvent = new UnityEvent<InventorySlot>();
    private Button showItem;


    private RectTransform rect = null;


    private void Awake() {
        EquipEvent.AddListener(OnEquip);
        rect = GetComponent<RectTransform>();
        showItem = GetComponent<Button>();
        showItem.onClick.AddListener(ShowViewItem);
    }

    public void Attach(itemModel data) {
        this.itemModel = data;
        HasItem = true;
        itemObj = Resources.Load<ItemObject>("Object/Items/" + data.itemName);
        iconImg.sprite = itemObj.itemIcon;
        iconImg.enabled = true;
    }

    public void UnAttach() {
        HasItem = false;
    }

    private void OnEquip(InventorySlot slot) {
        if (slot == this)
            return;

        if (Vector3.Distance(transform.position, Input.mousePosition) <= rect.sizeDelta.x / 2) {
            slot.iconImg.enabled = false;
            slot.iconImg.rectTransform.anchoredPosition = Vector2.zero;
            Attach(slot.itemModel);
        }
    }
    private void ShowViewItem() {
        if (this.itemModel == null) return;
        ViewItem.Instance.ShowItem(itemObj);
    }
    public InventorySlot() {
        Delegate.sellThisItem = SellItem;
    }

    public void SellItem() {
        CharacterStats.Instance.ChangeGold(GameConstants.goldSell[(int)itemObj.ItemLevel], "plus");
    }

}
