using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }
    void OnEquipmentChanged(Equipment newitem, Equipment olditem) {
        if(newitem != null) {
            armor.AddModifier(newitem.armorModifier);
            damage.AddModifier(newitem.damageModifier);
        }
        if(olditem != null) {
            armor.RemoveModifier(olditem.armorModifier);
            damage.RemoveModifier(olditem.damageModifier);
        }
    }
}
