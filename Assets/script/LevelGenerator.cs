using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Level;
    [SerializeField] private GameObject Column;
    [SerializeField] private GameObject Floor;
    [SerializeField] private GameObject BasicSegment;
    [SerializeField] private GameObject KillSegment;
    [SerializeField] private GameObject GlassSegment;

    [SerializeField] private int FloorsNumber;
    [SerializeField] private int FloorsGap;
    [SerializeField] private int SegmentsNumber;
    [SerializeField] private int AngleDiff;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        var levelInstance = Instantiate(Level);

        var columnInstance = Instantiate(Column, levelInstance.transform);
        columnInstance.transform.position = new Vector3(0f, FloorsGap * FloorsNumber * 0.5f, 0f);
        columnInstance.transform.localScale = new Vector3(2f, FloorsGap * FloorsNumber * 0.5f, 2f);

        GenerateFloors(levelInstance);
    }


    private void GenerateFloors(GameObject levelObject)
    {
        for (int i = 0; i < FloorsNumber; i++)
        {
            var floorSpawnPosition = new Vector3(0.0f, i * FloorsGap, 0.0f);
            var floorInstance = Instantiate(Floor, floorSpawnPosition, Quaternion.identity, levelObject.transform);

            var gapBasis = Random.Range(0, SegmentsNumber); // switch to level difficulty
            int[] gapIndexes = new int[5];
            int indexIncrement = -2;

            for (int index = 0; index < gapIndexes.Length; index++)
            {
                gapIndexes[index] = gapBasis - indexIncrement;
                indexIncrement++;
            }

            for (int j = 0; j < SegmentsNumber; j++)
            {
                if (gapIndexes.Contains(j))
                {
                    continue;
                }
                else
                {
                    var floorSegmentInstance = Instantiate(BasicSegment, floorSpawnPosition, Quaternion.identity, floorInstance.transform);
                    floorSegmentInstance.transform.Rotate(0.0f, AngleDiff * j, 0.0f, Space.Self);
                }
            }
        }
    }

}
