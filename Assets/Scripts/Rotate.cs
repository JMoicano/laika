using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Range(0, 100)]
    public float RotationSpeed = 10f;
    
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, (transform.rotation.z + RotationSpeed) * Time.deltaTime % 360));
    }
}
