﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AutoAllocator : MonoBehaviour
{
    public GameObject pointPref;
    List<Bounds> spawnAreas = new List<Bounds>();
    Bounds selectedArea;
    bool allignAtField;
    GameObject[] spawnPoints;
    Bounds spawnPointBounds;
    public static int currentPointsAmmountOnTheField;

    private void Start()
    {
        OnAutoLocateClick();
    }

    private void Update()
    {
        if (currentPointsAmmountOnTheField == 2)
        {
            spawnAdditionalSpawnPoints();
            currentPointsAmmountOnTheField += 2;
        }
    }

    void spawnAdditionalSpawnPoints(bool allignAtField = false)
    {
        this.allignAtField = allignAtField; 
        var collider = pointPref.GetComponent<CircleCollider2D>();
        spawnPointBounds = new Bounds(GameObject.Find("Dog").transform.position, new Vector3(65, 0, 65));//collider.bounds;
        MarkupSpawnAreas(spawnPointBounds.center);
        for (int i = 0; i < 2; i++) CreateSpawnPoint(i);
        for (int i = 0; i < 2; i++) AutoLocateSpawnPoint(i);
    }

    public void OnAutoLocateClick(bool allignAtField = false)
    {
        this.allignAtField = allignAtField;
        spawnAreas.Add(new Bounds(new Vector3(0, 0, 0), new Vector3(Width(), 0, Height())));
        //spawnAreas.Add(new Bounds(new Vector3(0, 3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(0, -3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(-4, 0), new Vector3(4, Height())));
        //spawnAreas.Add(new Bounds(new Vector3(4, 0), new Vector3(4, Height())));
        spawnPointBounds = GameObject.Find("rad4").GetComponent<SphereCollider>().bounds;
        MarkupSpawnAreas(spawnPointBounds.center);

        spawnPoints = new GameObject[8];
        currentPointsAmmountOnTheField = spawnPoints.Length;
        var collider = pointPref.GetComponent<CircleCollider2D>();
        spawnPointBounds = new Bounds(new Vector3(0,0,0), new Vector3(65,0,65));//collider.bounds;
        for (int i = 0; i < spawnPoints.Length; i++) CreateSpawnPoint(i);
        for (int i = 0; i < spawnPoints.Length; i++) AutoLocateSpawnPoint(i);
    }

    float Width()
    {
        return 340;
    }

    float Height()
    {
        return 390;
    }

    void CreateSpawnPoint(int index)
    {
        var spawnPoint = Instantiate(pointPref);
        spawnPoints[index] = spawnPoint;
        //var collider = pointPref.GetComponent<CircleCollider2D>();
        //spawnPointBounds = collider.bounds;
    }

    void AutoLocateSpawnPoint(int index)
    {
        SelectArea();
        var x = Random.Range(selectedArea.min.x, selectedArea.max.x);
        var z = Random.Range(selectedArea.min.z, selectedArea.max.z);
        spawnPoints[index].transform.position = new Vector3(x,0,z);
        //Debug.Log(x + " :: " + y);
        MarkupSpawnAreas(new Vector3(x,0,z));
    }

    void SelectArea()
    {
        var areasWorkingList = CopyList(spawnAreas);
        for (int i = 0; i < 100; i++)
        {
            var areaNum = Random.Range(0, areasWorkingList.Count);
            var randomArea = areasWorkingList[areaNum];

            selectedArea = new Bounds(randomArea.center, randomArea.size);
            var isAreaAppropriate = CheckAndAdjustSpawnArea();
            if (!isAreaAppropriate) areasWorkingList.Remove(randomArea);
            else break;
        }
    }

    List<T> CopyList<T>(List<T> list)
    {
        return new List<T>(list);
    }

    bool CheckAndAdjustSpawnArea()
    {
        var canStandHorizontally = selectedArea.size.x >= spawnPointBounds.size.x;
        var canStandVertically = selectedArea.size.z >= spawnPointBounds.size.z;

        if (!canStandHorizontally || !canStandVertically)
        {
            return false;
        }
        selectedArea.Expand(-spawnPointBounds.size);
        return true;
    }


    void MarkupSpawnAreas(Vector3 position)
    {
        float x = position.x, z = position.z;
        var occupiedArea = new Bounds(position,spawnPointBounds.size);
        var spawnAreasCopy = CopyList(spawnAreas);
        int c = 0;
        for (int i = 0; i < spawnAreasCopy.Count; i++)
        {
            var area = spawnAreasCopy[i];
            if (!AreBoundsOverlap(area, occupiedArea)) continue;
            spawnAreas.Remove(area);
            SplitSpawnArea(area, occupiedArea);

            c++; if (c > 100) break;
        }
    }

    bool AreBoundsOverlap(Bounds initial, Bounds occup)
    {
        if (initial == selectedArea) return true;
        var minMaxX = Mathf.Min(initial.max.x, occup.max.x);
        var maxMinX = Mathf.Max(initial.min.x, occup.min.x);
        var minMaxY = Mathf.Min(initial.max.z, occup.max.z);
        var maxMinY = Mathf.Max(initial.min.z, occup.min.z);

        var overlap = minMaxX > maxMinX && minMaxY > maxMinY;

        //Debug.Log($"old {initial.min} {initial.max}, new {occup.min} {occup.max},  {overlap}");
        return overlap;
    }

    void SplitSpawnArea(Bounds initialArea, Bounds occupiedArea)
    {
        CreateSubarea(initialArea, initialArea.max.z, occupiedArea.max.z, false);
        CreateSubarea(initialArea, initialArea.max.x, occupiedArea.max.x, true);
        CreateSubarea(initialArea, occupiedArea.min.z, initialArea.min.z, false);
        CreateSubarea(initialArea, occupiedArea.min.x, initialArea.min.x, true);
    }

    void CreateSubarea(Bounds initArea, float max, float min, bool isVertical)
    {
        if (max - min < 1) return;
        var subArea = new Bounds();
        if (isVertical)
        {
            subArea.center = new Vector3((max + min) / 2, 0,initArea.center.z);
            subArea.size = new Vector3(max - min,0, initArea.size.z);
        }
        else
        {
            subArea.center = new Vector3(initArea.center.x,0, (max + min) / 2);
            subArea.size = new Vector3(initArea.size.x, 0, max - min);
        }
        spawnAreas.Add(subArea);
        //Debug.Log($"area created {subArea.min} {subArea.max}");
    }

    //void OnDrawGizmos()
    //{
    //    var colors = new Color[]
    //    {
    //        Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow, Color.black
    //    };
    //    int c = 0;
    //    foreach (var area in spawnAreas)
    //    {
    //        Gizmos.color = colors[c];
    //        var center = area.center * cellSize + new Vector3(bottomLeftCorner.x,
    //            bottomLeftCorner.y) - Vector3.one * Random.Range(-0.2f, 0.2f);
    //        Gizmos.DrawWireCube(center, area.size * cellSize);
    //        c++;
    //        if (c == colors.Length) c = 0;
    //    }
    //}
}