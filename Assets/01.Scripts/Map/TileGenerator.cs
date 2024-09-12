using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    private Tilemap _tilemap;

    [SerializeField]
    private RuleTile _backGroundTiles, _obstacleTiles;

    [SerializeField]
    private AnimatedTile _animationTile;

    public void PlaceColliderTile(Vector3Int position)
    {
        TileBase tileToPlace = GetRandomTile();
        _tilemap.SetTile(position, tileToPlace);
    }

    private TileBase GetRandomTile()
    {
        int randomValue = UnityEngine.Random.Range(1, 6);

        if (randomValue < 5)
        {
            return _obstacleTiles;
        }
        else
        {
            return _animationTile;
        }
    }

    private void GenerateTile()
    {
        for (int i = 0; i < 15; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                
            }
        }
    }
}
