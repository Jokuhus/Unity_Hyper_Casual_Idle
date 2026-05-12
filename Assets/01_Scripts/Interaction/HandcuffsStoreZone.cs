using System.Collections;
using UnityEngine;

public class HandcuffsStoreZone : MonoBehaviour
{
	[SerializeField] private ItemStack _itemStackFrom;
	[SerializeField] private ItemStack _itemStackDest;

	private Coroutine _storeRoutine = null;

	private void OnTriggerEnter(Collider other)
	{
		_storeRoutine = StartCoroutine(StoreItem(1f));
	}

	private void OnTriggerExit(Collider other)
	{
		if (_storeRoutine != null)
		{
			StopCoroutine(_storeRoutine);
			_storeRoutine = null;
		}
	}

	private IEnumerator StoreItem(float interval)
	{
		while (true)
		{
			var obj = _itemStackFrom.Pop();
			if (obj != null) _itemStackDest.TryAdd(obj);
			yield return new WaitForSeconds(interval);
		}
	}
}