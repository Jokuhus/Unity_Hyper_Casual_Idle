using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _joystick;
    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;
    [SerializeField] private float _radius = 75f;

    public Vector2 Direction { get; private set; }
    
    private Vector2 _initialPosition;

    private void Awake()
    {
        _initialPosition = _background.position;
    }

    public void OnPointerDown(PointerEventData e)
    {
        UpdateJoystck(e);
        _joystick.SetActive(true);
        UpdateHandle(e);
    }
    public void OnDrag(PointerEventData e)        => UpdateHandle(e);

    public void OnPointerUp(PointerEventData e)
    {
        _joystick.SetActive(false);
        _background.position = _initialPosition;
        _handle.anchoredPosition = Vector2.zero;
        Direction = Vector2.zero;
    }

    private void UpdateJoystck(PointerEventData e)
    {
        _background.position = e.position;
    }

    private void UpdateHandle(PointerEventData e)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _background, e.position, e.pressEventCamera, out Vector2 localPoint);

        Vector2 clamped = Vector2.ClampMagnitude(localPoint, _radius);
        _handle.anchoredPosition = clamped;
        Direction = clamped / _radius; // normalized [-1, 1]
    }
}