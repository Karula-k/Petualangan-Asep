using UnityEngine;

public class CameraControler : MonoBehaviour
{
    // Room Camera
    private float currentX;
    private Vector3 velocity = Vector3.zero;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float xMin = 0f;

    //Follow player
    [SerializeField] private Transform player;
    // Update is called once per frame
    void FixedUpdate()
    {
        /*transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        */
        Vector3 targetPos = player.position + offset;
        Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
        Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, smoothSpeed + Time.fixedDeltaTime);

        transform.position = smoothPos;
    }
}
