using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;

    [SerializeField] float controlPitchFactor = 18f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;

    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    // Update is called once per frame
    void Start()
    {

    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXposition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXposition, -xClampRange, xClampRange);

        float yOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawYposition = transform.localPosition.x + xOffset;
        float clampedYPosition = Mathf.Clamp(rawXposition, -xClampRange, xClampRange);

        transform.localPosition = new Vector3(transform.localPosition.x + xOffset, transform.localPosition.y + yOffset, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -controlRollFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -controlRollFactor * movement.x);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
