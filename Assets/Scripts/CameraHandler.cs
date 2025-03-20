using UnityEngine;
using UnityEngine.Rendering;


public class CameraHandler : MonoBehaviour
{
    public Transform camTrans;
    public Transform pivot;
    public Transform Character;
    public Transform mTransform;

    public CharacterStatus characterStatus;
    public CameraConfig cameraConfig;
    public bool leftPivot;

    private float delta;
    private float mouseX;
    private float mouseY;
    private float smoothX;
    private float smoothY;
    private float smoothXVelocity;
    private float smoothYVelocity;
    private float lookAngle;
    private float titlAngle;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        FixedTick();
    }

    void FixedTick()
    {
        delta = Time.deltaTime;
        HandlePosition();
        HandleRotation();

        Vector3 targetPosition = Vector3.Lerp(mTransform.position, Character.position, cameraConfig.positionSmooth);
        mTransform.position = targetPosition;
    }

    void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = cameraConfig.normalZ;

        if(characterStatus.isAniming)
        {
            targetX = cameraConfig.aimX;
            targetZ = cameraConfig.aimZ;
        }

        if(leftPivot)
        {
            targetX = -targetX;
        }

        Vector3 newPivotPos = pivot.localPosition;
        newPivotPos.x = targetX;
        newPivotPos.y = targetY;

        Vector3 newCameraPos = camTrans.localPosition;
        newCameraPos.z = targetZ;

        float t = delta * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPos, 1);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPos, 1);

    }

    void HandleRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (cameraConfig.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);
        }
        else
        {
            smoothX = mouseX; 
            smoothY = mouseY;
        }

        lookAngle += smoothX * cameraConfig.Y_rot_speed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titlAngle -= smoothY * cameraConfig.X_rot_speed;
        titlAngle = Mathf.Clamp(titlAngle,cameraConfig.minAngle,cameraConfig.maxAngle);
        pivot.localRotation = Quaternion.Euler(titlAngle,0,0);

    }

    /*private void OnDrawGizmos()
    {
        Vector3 end = camTrans.GetChild(0).position;
        Vector3 e2 = pivot.position - mTransform.position;
        float distance = Vector3.Distance(camTrans.position, end);
        float d2 = Vector3.Distance(mTransform.position, pivot.position);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camTrans.position, camTrans.forward * distance);
        Gizmos.DrawRay(mTransform.position, e2.normalized * d2);
    }*/

}
