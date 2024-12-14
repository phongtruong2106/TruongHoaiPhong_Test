using UnityEngine;

public class CameraFollows : NewMonoBehaviour
{
    [SerializeField] protected PlayerController playerController;
    [SerializeField] protected SO_Camera sO_Camera;
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected Quaternion targetRotation;
    [SerializeField] public float zoom;
    private bool isLoad;
    protected override void Start()
    {
        base.Start();
        this.isLoad = false;
    }
    private  void Update()
    {
        if(!this.isLoad)
        {
            this.LoadPlayerController();
            Debug.Log("asdad");
            this.isLoad = true;
        }
        this.FollowCamera();
    }
    private void LoadPlayerController()
    {
        if(this.playerController != null) return;
        this.playerController = FindAnyObjectByType<PlayerController>();
    }

    private void FollowCamera()
    {
        this.Position();
        this.Rotation();
    }

    protected virtual void Position()
    {
        if(this.playerController != null)
        {
            targetPosition = new Vector3(playerController.transform.position.x + sO_Camera.xOffset, playerController.transform.position.y + sO_Camera.yOffset, playerController.transform.position.z + sO_Camera.zOffset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, sO_Camera.followSpeed * Time.deltaTime);
        }
        
    }

    protected virtual void Rotation()
    {
        if(this.playerController != null)
        {
            targetRotation = Quaternion.Euler(playerController.transform.rotation.x + sO_Camera.xRosOffset, playerController.transform.rotation.y + sO_Camera.yRosOffset, playerController.transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, sO_Camera.followSpeed * Time.deltaTime);
        }
    }
}