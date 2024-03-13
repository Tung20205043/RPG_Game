using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Item", fileName = "NewItem")]
public class ItemObject : ScriptableObject {
    public string itemName;
    public Sprite itemIcon;
    public List<ItemAttribute> attributes;
    public float ItemLevel;
                                    
    [Serializable]

    public class ItemAttribute {
        public AttributeType type;
        public float value;
    }
}
