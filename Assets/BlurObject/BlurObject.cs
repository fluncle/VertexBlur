using UnityEngine;

public class BlurObject : MonoBehaviour
{
    /// <summary> BlurシェーダーのプロパティID </summary>
    private static readonly int PROPERTY_TRAIL_DIR = Shader.PropertyToID("_TrailDir");

    [SerializeField]
    private Renderer _renderer;

    private Material _material;

    private Vector3 _trailPos;

    [SerializeField]
    private Transform _rotationRoot;

    /// <summary> 残像の尻尾の追従スピード </summary>
    [SerializeField]
    private float _trailRate = 10f;

    private void Awake()
    {
        // materialにアクセスして、複製されたマテリアルを変数に入れる
        _material = _renderer.material;
        _trailPos = transform.position;
    }

    private void Update()
    {
        _trailPos = Vector3.Lerp(_trailPos, transform.position, Mathf.Clamp01(Time.deltaTime * _trailRate));
        Transform root = _rotationRoot != null ? _rotationRoot : transform;
        // オブジェクトの回転を考慮してローカル方向に変換する
        Vector3 dir = root.InverseTransformDirection(_trailPos - transform.position);
        _material.SetVector(PROPERTY_TRAIL_DIR, dir);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(_trailPos, 0.2f);
    }
}
