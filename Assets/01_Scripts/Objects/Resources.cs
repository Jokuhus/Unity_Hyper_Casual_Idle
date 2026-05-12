using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resources : Singleton<Resources>
{
	[SerializeField] private GameObject _stonePrefab;
	[SerializeField] private GameObject _handcuffsPrefab;
	[SerializeField] private GameObject _moneyPrefab;

	public ObjectPool StonePool => _stonePool;
	public ObjectPool HandcuffsPool => _handcuffsPool;
	public ObjectPool MoneyPool => _moneyPool;

	private ObjectPool _stonePool;
	private ObjectPool _handcuffsPool;
	private ObjectPool _moneyPool;

	private void Start()
	{
		_stonePool = new(_stonePrefab);
		_handcuffsPool = new(_handcuffsPrefab);
		_moneyPool = new(_moneyPrefab);
	}

	protected override void OnSceneLoad(Scene scene, LoadSceneMode mode)
	{
	}
}