using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AutoAllocator : MonoBehaviour
{
    public GameObject pointPref;
    List<Bounds> spawnAreas = new List<Bounds>();
    Bounds selectedArea;
    bool allignAtField;
    List<GameObject> spawnPoints;
    Bounds spawnPointBounds;
    public static int currentPointsAmmountOnTheField;
    GameObject[] collisonObjects;
    List<Bounds> staticBounds = new List<Bounds>();

    #region Other Collisions
    // Bounds rock1ColliderBounds, rock2ColliderBounds, rock3ColliderBounds, tree1ColliderBounds;
    // GameObject rock1, rock2, rock3, tree1;
    #endregion

    private void Start()
    {
        OnAutoLocateClick();
        Klad_Up.OnSpawnPointFound += OnSpawnPointFound;
        #region Сollision assigner
        // tree1 = GameObject.Find("TreeTrunk");
        // rock1 = GameObject.Find("Cube (7)");
        // rock2 = GameObject.Find("Cube (8)");
        // rock3 = GameObject.Find("Cube (5)");

        // rock1ColliderBounds = rock1.GetComponent<BoxCollider>().bounds;
        // rock2ColliderBounds = rock2.GetComponent<BoxCollider>().bounds;
        // rock3ColliderBounds = rock3.GetComponent<BoxCollider>().bounds;
        // tree1ColliderBounds = tree1.GetComponent<BoxCollider>().bounds;
        #endregion
    }

    void OnSpawnPointFound(GameObject spawnPoint){
        spawnPoints.Remove(spawnPoint);
    }

    public void OnAutoLocateClick()
    {
        spawnAreas.Add(new Bounds(new Vector3(0, 0, 0), new Vector3(Width(), 0, Height())));
        //spawnAreas.Add(new Bounds(new Vector3(0, 3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(0, -3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(-4, 0), new Vector3(4, Height())));
        //spawnAreas.Add(new Bounds(new Vector3(4, 0), new Vector3(4, Height())));
        spawnPointBounds = new Bounds(GameObject.Find("Dog").transform.position, new Vector3(65, 0, 65));//collider.bounds;
        MarkupSpawnAreas(spawnPointBounds.center);

        // if (GameObject.Find("rad4") != null)
        // {
        //     spawnPointBounds = GameObject.Find("rad4").GetComponent<SphereCollider>().bounds;
        //     MarkupSpawnAreas(spawnPointBounds.center);
        // }

        SetsStaticObjectsBounds();

        currentPointsAmmountOnTheField = 6;
        spawnPoints = new List<GameObject>(currentPointsAmmountOnTheField);
        var collider = pointPref.GetComponent<CircleCollider2D>();
        spawnPointBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(65, 0, 65));//collider.bounds;
        for (int i = 0; i < currentPointsAmmountOnTheField; i++) CreateSpawnPoint(i);
        for (int i = 0; i < currentPointsAmmountOnTheField; i++) AutoLocateSpawnPoint(i);
    }

    private void Update()
    {
        if (currentPointsAmmountOnTheField == 2)
        {
            spawnAdditionalSpawnPoints();
        }
    }

    void SetsStaticObjectsBounds()
    {
        #region in case if something will go wrong with an array
        // spawnPointBounds = new Bounds(rock1ColliderBounds.center, rock1ColliderBounds.size);//collider.bounds;
        // MarkupSpawnAreas(spawnPointBounds.center);

        // spawnPointBounds = new Bounds(rock2ColliderBounds.center, rock2ColliderBounds.size);//collider.bounds;
        // MarkupSpawnAreas(spawnPointBounds.center);

        // spawnPointBounds = new Bounds(rock3ColliderBounds.center, rock3ColliderBounds.size);//collider.bounds;
        // MarkupSpawnAreas(spawnPointBounds.center);

        // spawnPointBounds = new Bounds(tree1ColliderBounds.center, tree1ColliderBounds.size);//collider.bounds;
        // MarkupSpawnAreas(spawnPointBounds.center);
        #endregion

        collisonObjects = GameObject.FindGameObjectsWithTag("CollisionObject");
        for (int i = 0; i < collisonObjects.Length; i++)
        {
            spawnPointBounds = new Bounds(collisonObjects[i].GetComponent<BoxCollider>().bounds.center,
                collisonObjects[i].GetComponent<BoxCollider>().bounds.size);//collider.bounds;
            MarkupSpawnAreas(spawnPointBounds.center);
        }

        staticBounds.AddRange(spawnAreas);
    }

    void spawnAdditionalSpawnPoints()
    {
        spawnAreas.Clear();

        spawnAreas.AddRange(staticBounds);

        spawnPointBounds = new Bounds(GameObject.Find("Dog").transform.position, new Vector3(65, 0, 65));//collider.bounds;
        MarkupSpawnAreas(spawnPointBounds.center);
        foreach (var oldSpawnPoint in spawnPoints)
        {
            MarkupSpawnAreas(oldSpawnPoint.transform.position);
        }
        spawnPointBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(65, 0, 65));
        for (int i = 0; i < 2; i++) CreateSpawnPoint(i);
        for (int i = 2; i < 4; i++) AutoLocateSpawnPoint(i);
        currentPointsAmmountOnTheField += 2;
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
        spawnPoints.Add(spawnPoint);
        //var collider = pointPref.GetComponent<CircleCollider2D>();
        //spawnPointBounds = collider.bounds;
    }

    void AutoLocateSpawnPoint(int index)
    {
        SelectArea();
        var x = Random.Range(selectedArea.min.x, selectedArea.max.x);
        var z = Random.Range(selectedArea.min.z, selectedArea.max.z);
        spawnPoints[index].transform.position = new Vector3(x, 0, z);
        //Debug.Log(x + " :: " + y);
        MarkupSpawnAreas(new Vector3(x, 0, z));
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
        var occupiedArea = new Bounds(position, spawnPointBounds.size);
        var spawnAreasCopy = CopyList(spawnAreas);
        int c = 0;
        for (int i = 0; i < spawnAreasCopy.Count; i++)
        {
            var area = spawnAreasCopy[i];
            if (!AreBoundsOverlap(area, occupiedArea)) continue;
            spawnAreas.Remove(area);
            SplitSpawnArea(area, occupiedArea);

            c++; if (c > 200000) break;
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
            subArea.center = new Vector3((max + min) / 2, 0, initArea.center.z);
            subArea.size = new Vector3(max - min, 0, initArea.size.z);
        }
        else
        {
            subArea.center = new Vector3(initArea.center.x, 0, (max + min) / 2);
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