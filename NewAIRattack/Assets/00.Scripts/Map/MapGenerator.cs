using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//R:Height
//G:Enemy
//1~10

//B:--¤¡
//  0~ :dirt  
//  50~:grass
//  100~:stone
//  150~:Ice
//  200~:Lava
//  250~:snow
//A:Player
//1~10


public enum TileType
{
    Dirt,
    Grass,
    Stone,
    Ice,
    Lava,
    Snow
}

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator Instance;

    [SerializeField]
    private Texture2D _test;
    [SerializeField]
    private int _size = 50;
    [SerializeField]
    private float _tileSize = 2, _height = 225,_terraineHeight=0.01f,_terraineOffset =5, _speed = 100, _ditherIntensity=10, _depth =10;

    public List<GroundSO> TileTypeSO = new();

    [SerializeField]
    private float _UnitheightOffset = 4,_blockHeightOffset;

    public Tile[,] Tiles = new Tile[64, 64];
    public Vector3[,] TargetPoses = new Vector3[64, 64];

    [SerializeField]
    private Tile _pref;
    [SerializeField]
    private Texture2D[] _mapImgs;
    private int _mapIdx = 0;

    [SerializeField]
    private AgentManager _playerAgentManager;

    [SerializeField]
    private Terrain _terrain;
    private TerrainData _terrainData;

    //[SerializeField]
    //private MeshCollider _realMapMeshCollider;
    //[SerializeField]
    //private MeshFilter _realMapMeshFilter;

    //private MeshFilter[,] _childmeshFilters;

    private float _time = 0;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    private void Start()
    {
        //_childmeshFilters = new MeshFilter[_size,_size];
        //var bArray1 = _test.GetRawTextureData<Color32>();
        //var bArray = _test.GetPixels32(0);
        //string texAsString = Convert.ToBase64String(bArray);
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                //float heighttmp = (float)(bArray[(_size) * i + j]).r;
                Tiles[i, j] = Instantiate(_pref, transform.position + new Vector3(i * _tileSize, 0, j * _tileSize), Quaternion.identity, transform);
                TargetPoses[i, j] = transform.position + new Vector3(i * _tileSize, 0, j * _tileSize);
                //_childmeshFilters[i, j] = Tiles[i, j].GetMeshFilter();
            }
        }
        StartCoroutine(ChangeMapCorutin(_test));
        //ChangeMap(_test);
    }

    // Update is called once per frame
    private void Update()
    {

        if (_time > 0)
        {
            _time -= Time.deltaTime;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_time <= 0)
                    {
                        Tiles[i, j].transform.position = TargetPoses[i, j];
                    }
                    else
                    {
                        Tiles[i, j].transform.position = Vector3.Lerp(Tiles[i, j].transform.position, TargetPoses[i, j], _speed * Time.deltaTime);

                    }
                }
            }

            //if (_time <= 0)
            //{
            //    CombineInstance[] combines = new CombineInstance[_size*_size];

            //    int i = 0;
            //    while (i < combines.Length)
            //    {
            //        combines[i].mesh = _childmeshFilters[i/_size,i%_size].sharedMesh;
            //        combines[i].transform = _childmeshFilters[i / _size, i % _size].transform.localToWorldMatrix;
            //        //_childmeshFilters[i / _size, i % _size].gameObject.SetActive(false);
            //        i++;
            //    }
            //    Mesh mesh = new Mesh();
            //    mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            //    mesh.CombineMeshes(combines);

            //    _realMapMeshCollider.sharedMesh = mesh;
            //    _realMapMeshFilter.sharedMesh = mesh;
            //}
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //ChangeMap(_test);
            ming();
        }
    }
    [ContextMenu("asdfdfsa")]
    public void ming()
    {
        _mapIdx = ++_mapIdx % _mapImgs.Length;
        //ChangeMap(_mapImgs[_mapIdx]);
        StartCoroutine(ChangeMapCorutin(_mapImgs[_mapIdx]));
        //ChangeMapCorutin(_mapImgs[_mapIdx]);

    }
    public void ChangeMap(Texture2D targetmap)
    {
        //var bArray1 = _test.GetRawTextureData<Color32>();
        var bArray = targetmap.GetPixels32(0);
        //string texAsString = Convert.ToBase64String(bArray);
        int playerCnt = 0;

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                float heighttmp = (float)(bArray[(_size) * i + j]).r;
                TargetPoses[i, j] = transform.position + new Vector3(i * _tileSize, heighttmp == 0 ? -6 : (Mathf.Floor(heighttmp/_ditherIntensity)*_ditherIntensity) * _height, j * _tileSize);
                int a = (int)((float)(bArray[(_size) * i + j]).b) / 50;
                Tiles[i, j].ChangeTile(TileType.Dirt + a);

                if ((bArray[(_size) * i + j]).g == 255)
                {
                    if (playerCnt < GameManager.Instance.PlayerManagerCompos[0].GetCompo<PlayerAgentManager>().Units.Count)
                    {
                        AgentForceMoveCompo forceMov = _playerAgentManager.Units[playerCnt++].GetCompo<AgentForceMoveCompo>();
                        forceMov.SetTargetPos(transform.position + new Vector3(i * _tileSize, _UnitheightOffset, j * _tileSize));
                        forceMov.SetMoveTime(0.8f);

                    }
                }

                if ((bArray[(_size) * i + j]).g != 0)
                {
                    //if (((bArray[(_size) * i + j]).a) < GameManager.Instance.PlayerManagerCompos[1].GetCompo<EnemyGenerator>().CurrentGenEnemyList.Units.Count)
                    GameManager.Instance.PlayerManagerCompos[1].GetCompo<EnemyGenerator>().GenEnemyies(transform.position +  new Vector3(i * _tileSize, _UnitheightOffset, j * _tileSize), (int)(bArray[(_size) * i + j]).g / 50);
                }
                //tiles[i, j].material = _tileMats[];
            }
        }
        _time = 1.5f / _speed;
    }
    private IEnumerator ChangeMapCorutin(Texture2D targetmap)
    {
        //var bArray1 = _test.GetRawTextureData<Color32>();
        var bArray = targetmap.GetPixels32(0);
        //string texAsString = Convert.ToBase64String(bArray);
        int playerCnt = 0;

        TerrainData terrainData = _terrain.terrainData;
        terrainData.heightmapResolution = _size;
       // terrainData.size = new Vector3(90, _height, _depth);



        float[,] heightmapfloat = new float[_size,_size];

        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                Color targetPixel = targetmap.GetPixel(i,j);
                Color targetPixel2 = targetmap.GetPixel(j, i);
                heightmapfloat[i, j] = targetPixel2.r * _terraineHeight + _terraineOffset;
                TargetPoses[i, j] = transform.position + new Vector3(i * _tileSize, targetPixel.r * _height + _blockHeightOffset, j * _tileSize);



                int a = (int)((float)(targetPixel.b)*255 / 50);
                Tiles[i, j].ChangeTile(TileType.Dirt + a);

                if (targetPixel.g == 255)
                {
                    if (playerCnt < GameManager.Instance.PlayerManagerCompos[0].GetCompo<PlayerAgentManager>().Units.Count)
                    {
                        AgentForceMoveCompo forceMov = _playerAgentManager.Units[playerCnt++].GetCompo<AgentForceMoveCompo>();
                        forceMov.SetTargetPos(transform.position + new Vector3(i * _tileSize, _UnitheightOffset, j * _tileSize));
                        forceMov.SetMoveTime(1.5f);

                    }
                }

                //float heighttmp = (float)(bArray[(_size) * i + j]).r;
                //TargetPoses[i, j] = transform.position + new Vector3(i * _tileSize, heighttmp == 0 ? -6 : heighttmp * _height + _blockHeightOffset, j * _tileSize);
                //heightmapfloat[_size-i-1,_size-j-1] = heighttmp == 0 ? -6 : heighttmp * _terraineHeight + _terraineOffset;
                //int a = (int)((float)(bArray[(_size) * i + j]).b) / 50;
                //Tiles[i, j].ChangeTile(TileType.Dirt + a);

                //if ((bArray[(_size) * i + j]).g == 255)
                //{
                //    if (playerCnt < GameManager.Instance.PlayerManagerCompos[0].GetCompo<PlayerAgentManager>().Units.Count)
                //    {
                //        AgentForceMoveCompo forceMov = _playerAgentManager.Units[playerCnt++].GetCompo<AgentForceMoveCompo>();
                //        forceMov.SetTargetPos(transform.position + new Vector3(i * _tileSize, _UnitheightOffset, j * _tileSize));
                //        forceMov.SetMoveTime(1.5f);

                //    }
                //}
                //else
                //if ((bArray[(_size) * i + j]).g != 0)
                //{
                //    //if (((bArray[(_size) * i + j]).a) < GameManager.Instance.PlayerManagerCompos[1].GetCompo<EnemyGenerator>().CurrentGenEnemyList.Units.Count)
                //    GameManager.Instance.PlayerManagerCompos[1].GetCompo<EnemyGenerator>().GenEnemyies(transform.position + new Vector3(i * _tileSize, _UnitheightOffset, j * _tileSize), (int)(bArray[(_size) * i + j]).g / 50);
                //}
            }
        }

        terrainData.SetHeights(0,0,heightmapfloat);
        //terrainData.SetAlphamaps()
        //GameObject terrainGO = Terrain.CreateTerrainGameObject(terrainData);

        //TerrainCollider col = terrainGO.GetComponent<TerrainCollider>();
        //_terrain.terrainData = terrainData;

        yield return null;
        _time = 1.5f / _speed;
    }
}