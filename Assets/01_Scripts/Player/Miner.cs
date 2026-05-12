using Unity.VisualScripting;
using UnityEngine;

public class Miner : MonoBehaviour
{
	[SerializeField] private ItemStack _itemStack;

	public ItemStack GetItemStack()
	{
		return _itemStack;
	}
}