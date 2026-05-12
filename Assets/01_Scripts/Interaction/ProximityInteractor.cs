using UnityEngine;

// 각 상호작용 Zone이 구현할 인터페이스
public interface IInteractable
{
    void OnPlayerEnter(ItemStack inventory);
    void OnPlayerStay();
    void OnPlayerExit();
}

// Zone 오브젝트에 부착
[RequireComponent(typeof(Collider))]
public class InteractionZone : MonoBehaviour
{
    // Inspector에서 IInteractable 구현체 할당
    [SerializeReference] private IInteractable _handler;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ItemStack>(out var inv))
            _handler?.OnPlayerEnter(inv);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<ItemStack>(out var inv))
            _handler?.OnPlayerStay();
    }

    private void OnTriggerExit(Collider other)
    {
        _handler?.OnPlayerExit();
    }
}