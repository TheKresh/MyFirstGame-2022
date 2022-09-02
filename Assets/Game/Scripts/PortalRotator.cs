using UnityEngine;

public class PortalRotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    void Update()
    {
        transform.eulerAngles += new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime;
    }
}
