using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;				// Item icon
	public bool isDefaultItem = false;      // Is the item default wear?

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		// Use the item
		// Something might happen

		Debug.Log("Using " + name);
	}

	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}
	
}// public class Item {
//     StatsModifier mod1, mod2;
//     public void Equip(Character character) {
//         character.Strength.AddModifier(new StatsModifier(10, StatModType.Flat, this));
//         character.Strength.AddModifier(new StatsModifier(0.1f, StatModType.PercentMult, this));
//     }

//     public void Unequip(Character character) {
//         character.Strength.RemoveAllModifiersFromSource(this);
//     }

// }