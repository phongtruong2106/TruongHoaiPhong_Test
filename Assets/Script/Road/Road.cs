using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private SO_SPAWNPREFAB sO_SPAWNPREFAB;
    [SerializeField] private SO_ROAD sO_ROAD;
    [SerializeField] private SO_MEOW sO_MEOW;
    [SerializeField] private SO_AREASPAWNMEOW sO_AREASPAWNMEOW;
    [SerializeField] private SO_Cabinet sO_Cabinet;

    private GameObject startLine;

    private void Start()
    {
        GameObject road1 = SpawnRoad(sO_ROAD.phase1Length, sO_ROAD.startPosition);

        float road1StartZ = road1.transform.position.z - (sO_ROAD.phase1Length / 2f) + sO_ROAD.offset;
        Vector3 road1StartPosition = new Vector3(sO_ROAD.startPosition.x, sO_ROAD.startPosition.y, road1StartZ);
        float road1EndZ = road1.transform.position.z + (sO_ROAD.phase1Length / 2f);
        float road2StartZ = road1EndZ + (sO_ROAD.phase2Length / 2f);
        
        Vector3 road2StartPosition = new Vector3(sO_ROAD.startPosition.x, sO_ROAD.startPosition.y, road1EndZ);
    
        Vector3 phase2Position = new Vector3(sO_ROAD.startPosition.x, sO_ROAD.startPosition.y, road2StartZ);
        SpawnRoad(sO_ROAD.phase2Length, phase2Position);
        SpawnStartLine(road1StartPosition);
        SpawnPlayerAtStartLine(road1StartPosition);
        SpawnZonesAndCats(road1StartPosition, sO_MEOW.spawnPositions, sO_ROAD.phase1Length,sO_AREASPAWNMEOW.spawnRadius);
        
        Vector3 roadDecorPosition = road1StartPosition * 1.275f;
        
        SpawnSandAndBeachAlongRoad(road1StartPosition * 1.1f, sO_SPAWNPREFAB.road1Length, sO_SPAWNPREFAB.roadWidth, sO_SPAWNPREFAB.SandPrefab);
        SpawnSandAndBeachAlongRoad(road2StartPosition, sO_SPAWNPREFAB.road2Length, sO_SPAWNPREFAB.roadWidth, sO_SPAWNPREFAB.SandPrefab);
        SpawnSandAndBeachAlongRoad(road1StartPosition * 1.1f, sO_SPAWNPREFAB.road1Length, sO_SPAWNPREFAB.roadWidth * 2, sO_SPAWNPREFAB.BeachPrefab);
        SpawnSandAndBeachAlongRoad(road2StartPosition, sO_SPAWNPREFAB.road2Length, sO_SPAWNPREFAB.roadWidth * 2, sO_SPAWNPREFAB.BeachPrefab);

        SpawnRoadDecorAtStart(roadDecorPosition * 1.275f, sO_SPAWNPREFAB.SandDecorPrefab);
        SpawnRoadDecorAtStart(road1StartPosition * 1.295f, sO_SPAWNPREFAB.road);
        SpawnRoadDecorAtStart(roadDecorPosition * 1.45f, sO_SPAWNPREFAB.BeachDecorPrefab);

        SpawnTsunami(road1StartPosition * 2, -150, sO_SPAWNPREFAB.TsunamiPrefab);

        float road2EndZ = road2StartZ + (sO_ROAD.phase2Length / 2f);
        Vector3 road2EndPosition = new Vector3(sO_ROAD.startPosition.x, sO_ROAD.startPosition.y, road2EndZ);
        SpawnEndPoint(road2EndPosition, sO_SPAWNPREFAB.EndPoint);
        SpawnListDecor(road1StartPosition, sO_ROAD.phase1Length, sO_SPAWNPREFAB.roadWidth, sO_SPAWNPREFAB.DecordPrefab, 10);
        SpawnListDecor(road2StartPosition, sO_ROAD.phase2Length, sO_SPAWNPREFAB.roadWidth, sO_SPAWNPREFAB.DecordPrefab, 10); 

        SpawnObstaclesAndZones(road1StartPosition, sO_Cabinet.spawnPositions, sO_ROAD.phase1Length, sO_AREASPAWNMEOW.spawnRadius);
        SpawnObstaclesAndZones(road2StartPosition, sO_Cabinet.spawnPositions, sO_ROAD.phase2Length, sO_AREASPAWNMEOW.spawnRadius);
  
        
    }

    private GameObject SpawnRoad(float length, Vector3 position)
    {
        if (sO_SPAWNPREFAB.roadPrefab != null)
        {
            GameObject road = Instantiate(sO_SPAWNPREFAB.roadPrefab, position, Quaternion.identity);
            Vector3 newScale = road.transform.localScale;
            newScale.z = length;
            road.transform.localScale = newScale;
            return road;
        }
        else
        {
            Debug.LogError("Road Prefab is not assigned!");
            return null;
        }
    }
    private void SpawnStartLine(Vector3 position)
    {
        startLine = GameObject.CreatePrimitive(PrimitiveType.Cube);
        startLine.transform.position = position;
        startLine.transform.localScale = new Vector3(10f, 0.1f, 0.5f);
        startLine.GetComponent<Renderer>().material.color = Color.red;
    }

    private void SpawnPlayerAtStartLine(Vector3 position)
    {
        if (sO_SPAWNPREFAB.playerPrefab != null)
        {
            Vector3 playerPosition = new Vector3(position.x, position.y + 1f, position.z);
            Instantiate(sO_SPAWNPREFAB.playerPrefab, playerPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player Prefab is not assigned!");
        }
    }
   private void SpawnZonesAndCats(Vector3 phase1StartPosition, List<Vector3> spawnPositions, float phase1Length, float radius)
    {
        if (sO_MEOW.catPrefabs.Count == 0) 
        {
            Debug.LogWarning("No cat prefabs assigned, no cats will be spawned.");
        }
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 zoneCenter = phase1StartPosition + spawnPositions[i];
            GameObject zoneVisual = DrawZone(zoneCenter, radius);
            if (sO_MEOW.catPrefabs.Count > 0)
            {
                SpawnCatsInZone(zoneCenter, radius);
            }
        }
    }

    private void SpawnCatsInZone(Vector3 zoneCenter, float radius)
    {
        int catCount = 1;

        for (int i = 0; i < catCount; i++)
        {
            Vector3 randomPosition = zoneCenter + new Vector3(
                Random.Range(-radius, radius), 
                0, 
                Random.Range(-radius, radius)
            );

            // Random chọn mèo từ danh sách catPrefabs
            GameObject randomCatPrefab = sO_MEOW.catPrefabs[Random.Range(0, sO_MEOW.catPrefabs.Count)];
            Instantiate(randomCatPrefab, randomPosition, Quaternion.identity);
        }
    }
    private GameObject DrawZone(Vector3 center, float radius)
    {
        GameObject zoneVisual = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        zoneVisual.transform.position = center;
        zoneVisual.transform.localScale = new Vector3(radius * 2, 0.1f, radius * 2);
        zoneVisual.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.3f);
        Destroy(zoneVisual,1f);

        return zoneVisual;
    }

    
    private void SpawnRoadDecorAtStart(Vector3 startPosition, GameObject decorPrefab)
    {
        if (decorPrefab == null)
        {
            Debug.LogError("Decor Prefab is not assigned!");
            return;
        }
        Quaternion rotation = Quaternion.Euler(0, 90, 0);
        Instantiate(decorPrefab, startPosition, rotation);
    }

    private void SpawnEndPoint(Vector3 startPosition, GameObject decorPrefab)
    {
        if (decorPrefab == null)
        {
            Debug.LogError("Decor Prefab is not assigned!");
            return;
        }
        Instantiate(decorPrefab, startPosition, Quaternion.identity);
    }
    private void SpawnSandAndBeachAlongRoad(Vector3 roadStartPosition, float roadLength, float roadWidth, GameObject sandBeachPrefab)
    {
        if (sandBeachPrefab == null)
        {
            Debug.LogError("SandBeach Prefab is not assigned!");
            return;
        }
        Vector3 leftPosition = roadStartPosition + new Vector3(-roadWidth / 2 - 2f, 0, roadLength / 2);
        Vector3 rightPosition = roadStartPosition + new Vector3(roadWidth / 2 + 2f, 0, roadLength / 2);
        GameObject leftSandBeach = Instantiate(sandBeachPrefab, leftPosition, Quaternion.identity);
        leftSandBeach.transform.localScale = new Vector3(leftSandBeach.transform.localScale.x, leftSandBeach.transform.localScale.y, roadLength);
        GameObject rightSandBeach = Instantiate(sandBeachPrefab, rightPosition, Quaternion.identity);
        rightSandBeach.transform.localScale = new Vector3(rightSandBeach.transform.localScale.x, rightSandBeach.transform.localScale.y, roadLength);
    }
    private void SpawnTsunami(Vector3 phase1StartPosition, float distance, GameObject tsunamiPrefab)
    {
        if (tsunamiPrefab == null)
        {
            Debug.LogError("Tsunami Prefab is not assigned!");
            return;
        }   
        Vector3 tsunamiPosition = phase1StartPosition + new Vector3(0, 0, distance);
        Instantiate(tsunamiPrefab, tsunamiPosition, Quaternion.identity);
    }

    private void SpawnListDecor(Vector3 phaseStartPosition, float phaseLength, float roadWidth, List<GameObject> decorPrefabs, int decorCountPerSide)
    {
        if (decorPrefabs == null || decorPrefabs.Count == 0)
        {
            Debug.LogError("Decor Prefab List is empty or null!");
            return;
        }
        float currentZ = 0f;
        float maxZ = phaseLength; 

        for (int i = 0; i < decorCountPerSide; i++)
        {
            float randomSpacing = Random.Range(30f, 70f);
            currentZ += randomSpacing;
            if (currentZ > maxZ) break;
            GameObject randomDecorPrefab = decorPrefabs[Random.Range(0, decorPrefabs.Count)];
            Vector3 leftPosition = phaseStartPosition + new Vector3(
                -roadWidth / 2 - 2f,
                0, 
                currentZ 
            );
            Vector3 rightPosition = phaseStartPosition + new Vector3(
                roadWidth / 2 + 2f, 
                0, 
                currentZ
            );
            Instantiate(randomDecorPrefab, leftPosition, Quaternion.identity);
            Instantiate(randomDecorPrefab, rightPosition, Quaternion.identity);
        }
    }
    private void SpawnObstaclesAndZones(Vector3 phaseStartPosition, List<Vector3> spawnPositions, float phaseLength, float radius)
    {
        if (sO_Cabinet.cabinetPrefabs == null || sO_Cabinet.cabinetPrefabs.Count == 0)
        {
            Debug.LogError("Obstacle prefabs are not assigned in SO_OBSTACLE!");
            return;
        }
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Vector3 zoneCenter = phaseStartPosition + spawnPositions[i];
            GameObject zoneVisual = DrawZone(zoneCenter, radius); 
            int obstacleCount = Random.Range(1, 3); 

            for (int j = 0; j < obstacleCount; j++)
            {
                SpawnObstacleInZone(zoneCenter, radius); 
            }
        }
    }
    private void SpawnObstacleInZone(Vector3 zoneCenter, float radius)
    {
        Vector3 randomPosition = zoneCenter + new Vector3(
            Random.Range(-radius, radius),
            0,
            Random.Range(-radius, radius)
        );
        GameObject randomObstaclePrefab = sO_Cabinet.cabinetPrefabs[Random.Range(0, sO_Cabinet.cabinetPrefabs.Count)];

        // Random rotation cho vật cản
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        Instantiate(randomObstaclePrefab, randomPosition, randomRotation);
    }


}
