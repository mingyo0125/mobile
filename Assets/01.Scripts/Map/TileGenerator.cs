using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    private Tilemap _backGroundTileMap, _obstaclesTileMap, _animaionTileMap;

    [SerializeField]
    private RuleTile _backGroundTiles, _obstacleTiles;

    [SerializeField]
    private AnimatedTile _animationTile;

    private void Start()
    {
        GenerateTile();
    }

    private void PlaceColliderTile(Vector3Int position)
    {
        int randomValue = UnityEngine.Random.Range(1, 6);

        if (randomValue < 5)
        {
            _obstaclesTileMap.SetTile(position, _obstacleTiles);
        }
        else
        {
            _animaionTileMap.SetTile(position, _animationTile);
        }
    }

    private void GenerateTile()
    {
        Vector3 pivot = transform.position;
        for (int i = -10; i < 10; i++)
        {
            for(int j = 9; j > -11; j--)
            {
                Vector3Int tilePos = new Vector3Int((int)pivot.x + i, (int)pivot.y + j, 0);
                _backGroundTileMap.SetTile(tilePos, _backGroundTiles);

                if (Utils.CalculateProbability(10)) { PlaceColliderTile(tilePos); }
            }
        }
    }
}