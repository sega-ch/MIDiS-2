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

    GameObject dog;
    Vector3 debugVisionOffset = new Vector3(0, 1, 0);
    Vector3 BetweenVector = new Vector3(65, 0, 65); // Сказали по стандарту 65 0 65

    // Стандартные значения
    [Space(10)]
    [Header("Длина")]
    public float areaWidth = 340;
    [Header("Ширина")]
    public float areaHeight = 390;
    Vector3 spawnAreaCenter;
    Vector3 spawnAreaSize;

    // Тут просто задаём размеры уровня
    // Дальше устанавливаем количество заспавненных кладов
    // Задаём размеры места для спавна относительно объекта на карте
    // Тут надо подумать как получить размеры этого самого объекта?

    #region Other Collisions
    // Bounds rock1ColliderBounds, rock2ColliderBounds, rock3ColliderBounds, tree1ColliderBounds;
    // GameObject rock1, rock2, rock3, tree1;
    #endregion

    private void Start()
    {
        spawnAreaCenter = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        spawnAreaSize = new Vector3(Width(), 0, Height());

        dog = GameObject.FindGameObjectWithTag("Dog");

        InitializeLvlParameters();

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

    private void InitializeLvlParameters()
	{
        float lvlSquare = Width() * Height();
        
        if (lvlSquare >= 86000 && lvlSquare < 103000)
		{
            currentPointsAmmountOnTheField = 5;
            BetweenVector = new Vector3(65, 0, 65);
        }
        else if (lvlSquare < 120000)
        {
            currentPointsAmmountOnTheField = 6;
            BetweenVector = new Vector3(65, 0, 65);
        }
        else if (lvlSquare < 138000)
        {
            currentPointsAmmountOnTheField = 7;
            BetweenVector = new Vector3(65, 0, 65);
        }
        else if (lvlSquare < 155000)
        {
            currentPointsAmmountOnTheField = 8;
            BetweenVector = new Vector3(65, 0, 65);
        }
        else if (lvlSquare < 173000)
        {
            currentPointsAmmountOnTheField = 9;
            BetweenVector = new Vector3(65, 0, 65);
        }
        else if (lvlSquare < 190000)
        {
            currentPointsAmmountOnTheField = 10;
            BetweenVector = new Vector3(70, 0, 70);
        }
        else if (lvlSquare < 208000)
        {
            currentPointsAmmountOnTheField = 11;
            BetweenVector = new Vector3(70, 0, 70);
        }
        else if (lvlSquare < 225000)
        {
            currentPointsAmmountOnTheField = 12;
            BetweenVector = new Vector3(70, 0, 70);
        }
        else if (lvlSquare < 243000)
        {
            currentPointsAmmountOnTheField = 13;
            BetweenVector = new Vector3(70, 0, 70);
        }
        else if (lvlSquare >= 243000)
        {
            currentPointsAmmountOnTheField = 14;
            BetweenVector = new Vector3(70, 0, 70);
        }

        FindObjectOfType<Controller>().TreasureAmmount = currentPointsAmmountOnTheField;

        Debug.Log("[!] Настройки уровня [!]");
        Debug.Log("Площадь уровня: " + lvlSquare);
        Debug.Log("Количество точек спавна: " + currentPointsAmmountOnTheField);
        Debug.Log("Расстояние между точками: " + BetweenVector.x);
    }

    public void OnAutoLocateClick()
    {
        spawnAreas.Add(new Bounds(spawnAreaCenter, spawnAreaSize));
        //spawnAreas.Add(new Bounds(new Vector3(0, 3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(0, -3), new Vector3(Width(), 4)));
        //spawnAreas.Add(new Bounds(new Vector3(-4, 0), new Vector3(4, Height())));
        //spawnAreas.Add(new Bounds(new Vector3(4, 0), new Vector3(4, Height())));
        spawnPointBounds = new Bounds(dog.transform.position, BetweenVector);//collider.bounds;
        MarkupSpawnAreas(spawnPointBounds.center);
        
        SetsStaticObjectsBounds();

        spawnPoints = new List<GameObject>(currentPointsAmmountOnTheField);
        var collider = pointPref.GetComponent<CircleCollider2D>();
        spawnPointBounds = new Bounds(Vector3.zero, BetweenVector);//collider.bounds;
        for (int i = 0; i < currentPointsAmmountOnTheField; i++) CreateSpawnPoint(i);
        for (int i = 0; i < currentPointsAmmountOnTheField; i++) AutoLocateSpawnPoint(i);
    }

    private void Update()
    {
        //if (currentPointsAmmountOnTheField == 2)
        //{
        //    spawnAdditionalSpawnPoints();
        //}
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

        spawnPointBounds = new Bounds(GameObject.Find("Dog").transform.position, BetweenVector);//collider.bounds;
        MarkupSpawnAreas(spawnPointBounds.center);
        foreach (var oldSpawnPoint in spawnPoints)
        {
            MarkupSpawnAreas(oldSpawnPoint.transform.position);
        }
        spawnPointBounds = new Bounds(Vector3.zero, BetweenVector);
        for (int i = 0; i < 2; i++) CreateSpawnPoint(i);
        for (int i = 2; i < 4; i++) AutoLocateSpawnPoint(i);
        currentPointsAmmountOnTheField += 2;
    }


    float Width()
    {
        return areaWidth;
    }

    float Height()
    {
        return areaHeight;
    }

    void CreateSpawnPoint(int index)
    {
        var spawnPoint = Instantiate(pointPref);
        spawnPoints.Add(spawnPoint);
    }

    void AutoLocateSpawnPoint(int index)
    {
        SelectArea();
        var x = Random.Range(selectedArea.min.x, selectedArea.max.x);
        var z = Random.Range(selectedArea.min.z, selectedArea.max.z);
        spawnPoints[index].transform.position = new Vector3(x, pointPref.transform.position.y, z);
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
        float x = position.x;
        float z = position.z;
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

	void OnDrawGizmos()
	{
		// Отрисовка мини полей для спавна
		var colors = new Color[]
		{
			Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow, Color.black
		};
		int c = 0;
		foreach (var area in spawnAreas)
		{
			Gizmos.color = colors[c];
			Gizmos.DrawWireCube(area.center, area.size);
			c++;
			if (c == colors.Length) c = 0;
		}

		// Отрисовка поля для засеивания
		var debugCenter = new Vector3(this.transform.position.x, 0, this.transform.position.z);
		var debugSize = new Vector3(Width(), 0, Height()) + debugVisionOffset;
		Gizmos.color = new Color(255, 0, 0, 0.5f);
		Gizmos.DrawCube(debugCenter, debugSize);
	}
}