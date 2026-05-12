using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Joystick _joystick;
	[SerializeField] private float _moveSpeed = 5f;
	[SerializeField] private float _rotSpeed = 10f;

	private CharacterController _cc;
	private Vector2 _inputDirection;

	private void Awake() => _cc = GetComponent<CharacterController>();

	public void OnMove(InputAction.CallbackContext ctx) => _inputDirection = ctx.ReadValue<Vector2>();

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		// Joystick 우선, 없으면 InputAction 폴백
		Vector2 raw = _joystick.Direction != Vector2.zero
				? _joystick.Direction
				: _inputDirection;

		Vector3 move = new Vector3(raw.x, 0f, raw.y);

		_cc.Move(move * (_moveSpeed * Time.deltaTime));

		// 이동 방향 회전
		if (move.x != 0f || move.z != 0f)
		{
				Vector3 flat = new Vector3(move.x, 0f, move.z);
				transform.rotation = Quaternion.Slerp(
						transform.rotation,
						Quaternion.LookRotation(flat),
						Time.deltaTime * _rotSpeed);
		}
	}
}