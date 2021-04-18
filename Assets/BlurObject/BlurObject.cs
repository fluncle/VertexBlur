using UnityEngine;

public class BlurObject : MonoBehaviour
{
    private static readonly int PROPERTY_TRAIL_DIR = Shader.PropertyToID("_TrailDir");

    [SerializeField]
    private Renderer _renderer;

    private Material _material;

    private Vector3 _trailPos;

    [SerializeField]
    private float _trailRate = 10f;

    void Awake()
    {
        _material = _renderer.material;
        _trailPos = transform.position;
    }

    void Update()
    {
        _trailPos = Vector3.Lerp(_trailPos, transform.position, Mathf.Clamp01(Time.deltaTime * _trailRate));
        _material.SetVector(PROPERTY_TRAIL_DIR, _trailPos - transform.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_trailPos, 0.2f);
    }
}
