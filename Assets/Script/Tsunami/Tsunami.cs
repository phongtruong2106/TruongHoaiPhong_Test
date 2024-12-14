using UnityEngine;

public class Tsunami : NewMonoBehaviour
{
    [SerializeField] protected Transform transformTsunami;
    [SerializeField] protected SO_TSUNAMI sO_TSUNAMI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTransformTsunami();
    }

    private void LoadTransformTsunami()
    {
        if(this.transformTsunami != null) return;
        this.transformTsunami = gameObject.GetComponent<Transform>();
    }
}