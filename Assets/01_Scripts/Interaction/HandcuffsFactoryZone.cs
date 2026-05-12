using System.Collections;
using UnityEngine;

public class HandcuffsFactoryZone : MonoBehaviour
{
	[SerializeField] private ItemStack _itemStackFrom;
	[SerializeField] private ItemStack _itemStackDest;
	[SerializeField] private ItemStack _itemStackFinal;

	private Coroutine _storeRoutine = null;
	private Coroutine _moveRoutine = null;
	private Resources _resources;

	private void Start()
	{
		_storeRoutine = StartCoroutine(StoreItem(1f));
		_resources = Resources.Instance;
	}

	private void OnTriggerEnter(Collider other)
	{
		_moveRoutine = StartCoroutine(MoveItem(1f));
	}

	private void OnTriggerExit(Collider other)
	{
		if (_moveRoutine != null)
		{
			StopCoroutine(_moveRoutine);
			_moveRoutine = null;
		}
	}

	private void Oestroy()
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
			if (obj != null) 
			{
				_resources.StonePool.Return(obj);
				var newObj = _resources.HandcuffsPool.Get(gameObject.transform.position);
				_itemStackDest.TryAdd(newObj);
			}
			yield return new WaitForSeconds(interval);
		}
	}

	private IEnumerator MoveItem(float interval)
	{
		while (true)
		{
			var obj = _itemStackDest.Pop();
			if (obj != null) _itemStackFinal.TryAdd(obj);
			yield return new WaitForSeconds(interval);
		}
	}
}