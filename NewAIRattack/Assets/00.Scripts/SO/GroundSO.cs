using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/Ground")]
public class GroundSO : ScriptableObject
{
    public TileType tileType;
    public Material material;
    public Mesh mesh;
}
