
public enum AnimationState { Movement, Attack, Jump }

public enum MovementType { Idle,Walk, Run }

public enum AttackType { Normally}

public enum ItemType {
    Sword
}
public enum AttributeType {
    ATK,
    DEF,
    SP,
    HP
}

public delegate void SellItem ();
public class Delegate {
    public static SellItem sellThisItem;
}