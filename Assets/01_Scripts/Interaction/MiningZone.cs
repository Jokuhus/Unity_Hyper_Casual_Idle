using System.Collections.Generic;
using UnityEngine;

public class MiningZone : MonoBehaviour
{
    [SerializeField] List<GameObject> _rockStack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out var player))
        {
            player.StartMining();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerManager>(out var player))
        {
            player.StopMining();
        }
    }
}