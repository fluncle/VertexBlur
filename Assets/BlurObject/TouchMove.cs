using UnityEngine;

public class TouchMove : MonoBehaviour
{
    [SerializeField]
    private Collider _touchCollider;

    private Vector3 _touchPos;

    private Vector3 _trailPos;

    private void Awake()
    {
        _touchPos = transform.position;
        _trailPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(_touchCollider.Raycast(ray, out hit, 15f))
            {
                _touchPos = hit.point;
            }
        }
        transform.position = Vector3.Lerp(transform.position, _touchPos, Time.deltaTime * 10f);
        _trailPos = Vector3.Lerp(_trailPos, transform.position, Time.deltaTime * 10f);
    }
}