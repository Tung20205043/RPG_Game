using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float rotationSpeed = 100f;

    void Update() {
        // Nội suy vị trí camera tới vị trí của target
        Vector3 targetPosition = target.position;
        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.position = newPosition;

        // Xác định di chuyển của chuột khi nhấn nút phải
        if (Input.GetMouseButton(1)) {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 newRotation = transform.eulerAngles + new Vector3(-mouseY, mouseX, 0) * rotationSpeed * Time.deltaTime;
            transform.eulerAngles = newRotation;
        }
    }
}
