using UnityEngine;

namespace FMP.ARPG
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3 offset = new Vector3();
        [SerializeField] private float pitch = 2f;
        RaycastHit hit;

        private void LateUpdate()
        {
            transform.position = target.position - offset;
            transform.LookAt(target.position + Vector3.up * pitch);
        }

        private void Update()
        {
            
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, hit.transform.position);
        }
    }
}
