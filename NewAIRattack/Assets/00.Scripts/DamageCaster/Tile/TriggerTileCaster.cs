using UnityEngine;

public class TriggerTileCaster : MonoBehaviour
{
    [SerializeField]
    private float Power = 0.5f;
    [SerializeField]
    private bool _isAffectDistance=false;
    [SerializeField]
    private float _maxDistance = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            if(other.TryGetComponent<Tile>(out Tile tile))
            {
                if(_isAffectDistance)
                {
                    tile.DownTile(Power * Mathf.Lerp(0, 1, (_maxDistance*transform.localScale.x - Vector3.Distance(transform.position, other.transform.position))));
                }
                else
                {
                    tile.DownTile(Power);
                }
            }
        }
    }
}
