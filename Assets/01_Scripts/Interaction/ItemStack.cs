using System.Collections.Generic;
using UnityEngine;

public class ItemStack : MonoBehaviour
{
	[SerializeField] private Transform _anchor;
	[SerializeField] private int _maxCapacity;

	private const float StackOffset = 0.15f;

	private readonly List<GameObject> _stack = new();

	public int Count => _stack.Count;

	public bool TryAdd(GameObject item)
	{
		if (_stack.Count >= _maxCapacity) return false;
		PlaceOnAnchor(item, _anchor, _stack);
		return true;
	}

	public GameObject Pop()
	{
		if (_stack.Count == 0) return null;
		GameObject top = _stack[^1];
		_stack.RemoveAt(_stack.Count - 1);
		top.transform.SetParent(null);
		return top;
	}

	private void PlaceOnAnchor(GameObject item, Transform anchor, List<GameObject> stack)
	{
		item.transform.SetParent(anchor);
		item.transform.localPosition = Vector3.up * (stack.Count * StackOffset);
		item.transform.localRotation = Quaternion.identity;
		stack.Add(item);
	}
}