using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{
	private ItemStack _currentStack;
	private bool _isActive;
	private Renderer _renderer;

	private void Start()
	{
		_renderer = GetComponent<Renderer>();
		_isActive = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Miner>(out var miner))
		{
			_currentStack = miner.GetItemStack();
		}
	}

	private void OnTriggerExit()
	{
		_currentStack = null;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!_isActive) return;
		if (_currentStack == null) return;

		GameObject obj = Resources.Instance.StonePool.Get(gameObject.transform.position);
		if (!_currentStack.TryAdd(obj))
			Resources.Instance.StonePool.Return(obj);

		StartCoroutine(Respawn());
	}

	private IEnumerator Respawn()
	{
		_isActive = false;
		_renderer.enabled = false;

		yield return new WaitForSeconds(3f);
		_renderer.enabled = true;
		_isActive = true;
	}
}