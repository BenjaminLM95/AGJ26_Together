using UnityEngine;

public class CameraFollowMe : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraMoveSpeed = 5f;
    [SerializeField] private float cameraDistance;

    [SerializeField] private bool lockRotation;
    void Start()
    {
        mainCamera ??= Camera.main;
    }

    void Update()
    {
        FollowMe();
    }

    private void FollowMe()
    {
        Vector3 targetPosition = transform.position;

        targetPosition.z = cameraDistance;

        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,
            targetPosition,
            cameraMoveSpeed * Time.deltaTime
        );

        if ( lockRotation ) mainCamera.transform.rotation = Quaternion.identity;
    }
}
