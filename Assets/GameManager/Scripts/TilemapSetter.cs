using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapSetter : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private string[] tileNames;
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private Transform objParent;

    [ContextMenu("DebugTest")]
    void CreateGameObject()
    {
        foreach( var pos in GetTilePos( tilemap ) )
        {
            var tileBase = GetTileBase(pos);
            if (tileBase == null) continue;

            var name = tileBase.name;
            for( int i=0; i<tileNames.Length; ++i )
            {
                if( name == tileNames[i] )
                {
                    tilemap.SetTile(pos, null);
                    var obj = GameObject.Instantiate(gameObjects[i], tilemap.GetCellCenterWorld(pos), Quaternion.identity );
                    obj.transform.SetParent(objParent);
                }
            }
        }
    }

    IEnumerable<Vector3Int> GetTilePos( Tilemap tilemap )
    {
        var bounds = tilemap.cellBounds;
        for (int y = bounds.yMin; y < bounds.yMax; ++y)
        {
            for (int x = bounds.xMin; x < bounds.xMax; ++x)
            {
                yield return new Vector3Int(x, y, 0);
            }
        }
    }

    TileBase GetTileBase( Vector3Int pos )
    {
        var tile = tilemap.GetTile(pos);
        if (tile == null) return null;
        var tileBase = tilemap.GetTile<TileBase>(pos);
        if (tileBase == null) return null;
        return tileBase;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
