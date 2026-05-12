using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> _miners;

	private int _currentMiningLevel = 0;
	private bool _isMining = false;

	public void IncreaseMiningLevel()
	{
		_miners[_currentMiningLevel].SetActive(false);
		if (_currentMiningLevel + 1 < _miners.Count)
		{
			_currentMiningLevel++;
		}
		
		if (_isMining)
		{
			_miners[_currentMiningLevel].SetActive(true);
		}
	}

	public void StartMining()
	{
		_isMining = true;
		_miners[_currentMiningLevel].SetActive(true);
	}

	public void StopMining()
	{
		_isMining = false;
		_miners[_currentMiningLevel].SetActive(false);
	}
}