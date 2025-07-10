using System.Collections;
using UnityEngine;

public class Tile : DamageCaster
{
    [SerializeField]
    private TileType _tileType;
    [SerializeField]
    private MeshRenderer _meshRenderer;
    [SerializeField]
    private MeshFilter _meshfilter;
    private float _time = 0;


    [SerializeField]
    private Collider _collider;

    public MeshFilter GetMeshFilter() {return _meshfilter; }

    private void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    public void ChangeTile(TileType type)
    {
        _meshfilter.mesh = MapGenerator.Instance.TileTypeSO[(int)type].mesh;
        _meshRenderer.material = MapGenerator.Instance.TileTypeSO[(int)type].material;
        _tileType = type;
        //print(type.ToString());
    }

    public void DownTile(float value)
    {
        StartCoroutine(DownCorutin(value));
    }

    private IEnumerator DownCorutin(float value)
    {
        float a = value > 0 ? 1 : -1;

        value = Mathf.Abs(value);
        for (float i = 0; i < value; i+=0.02f)
        {
            transform.position += new Vector3(0,0.05f*a,0);
            yield return new WaitForSeconds(0.02f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (_tileType == TileType.Lava)
        {
            DamageCast(collision.gameObject, 0.1f);
        }

    }
}
