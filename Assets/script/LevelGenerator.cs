using System.Collections;
using System.Linq;
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
    [SerializeField] private int AngleDelta;
    [SerializeField] private int GapDifficulty;
    [SerializeField] private int KillDifficulty;
    [SerializeField] private int LevelDifficulty;
    [SerializeField] private int ChangeDifficulty;

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
        for(int i = 0; i < FloorsNumber; i++)
        {
            var GlassDifficulty = 0;
            var GapDifference = 0;
            var LevelDifficulty = 0;
            
            var floorSpawnPosition = new Vector3(0.0f, i * FloorsGap, 0.0f);
            var floorInstance = Instantiate(Floor, floorSpawnPosition, Quaternion.identity, levelObject.transform);

            switch (ChangeDifficulty)
            {
                case 1:
                    GlassDifficulty = 0;
                    GapDifference = 2;
                    LevelDifficulty = 5;
                    Debug.Log("1");
                    break;
                case 2:
                    GlassDifficulty = 0;
                    GapDifference = 4;
                    LevelDifficulty = 5;
                    Debug.Log("2");
                    break;
                case 3:
                    GlassDifficulty = 2;
                    GapDifference = 6;
                    LevelDifficulty = 4;
                    Debug.Log("3");
                    break;
                case 4:
                    GlassDifficulty = 4;
                    GapDifference = 8;
                    LevelDifficulty = 4;
                    Debug.Log("4");
                    break;
                default:
                    if (ChangeDifficulty >= 1 && ChangeDifficulty <= 5)
                    {
                        GlassDifficulty = 6;
                        GapDifference = 10;
                        LevelDifficulty = 3;
                        Debug.Log("5");
                    }
                    break;
            }

            var gapBasis = Random.Range(0, SegmentsNumber); 
            int[] gapIndexes = new int[GapDifficulty];
            int[] killIndexes = new int[KillDifficulty];
            var killBegin = (gapBasis + GapDifficulty) % SegmentsNumber;

            for (int j = 0; j < KillDifficulty; j++)
            {
                var killIndex = (killBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;

                while (killIndexes.Contains(killIndex))
                {
                    killIndex = (killBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;
                }

                killIndexes[j] = killIndex;
            }

            for (int index = 0; index < gapIndexes.Length; index++)
            {
                gapIndexes[index] = (gapBasis + index) % SegmentsNumber;
            }

            for (int j = 0; j < SegmentsNumber; j++)
            {
                if (gapIndexes.Contains(j))
                {
                    continue;
                }
                else if (killIndexes.Contains(j))
                {
                    var killSegmentInstance = Instantiate(KillSegment, floorSpawnPosition, Quaternion.identity, floorInstance.transform);
                    killSegmentInstance.transform.Rotate(0.0f, AngleDelta * j, 0.0f, Space.Self);
                }
                else
                {
                    var floorSegmentInstance = Instantiate(BasicSegment, floorSpawnPosition, Quaternion.identity, floorInstance.transform);
                    floorSegmentInstance.transform.Rotate(0.0f, AngleDelta * j, 0.0f, Space.Self);
                }
            }
        }
    }

}
