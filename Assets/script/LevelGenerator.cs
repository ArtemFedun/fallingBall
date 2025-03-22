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
    [SerializeField] private GameObject FinishSegment;

    [SerializeField] private int FloorsNumber;
    [SerializeField] private int FloorsGap;
    [SerializeField] private int SegmentsNumber;
    [SerializeField] private int AngleDiff;
    [SerializeField] private int LevelDifficulty;
    private int GapDifference;
    private int GapDifficulty;
    private int GlassDifficulty;
    private int KillDifficulty;


    private void Start()
    {
        ChangeDifficulty(LevelDifficulty);
        GenerateLevel();
    }

    private void ChangeDifficulty(int levelDifficulty)
    {
        switch (levelDifficulty)
        {
            case 1:
                GapDifference   = 2;
                GapDifficulty   = 5;
                GlassDifficulty = 0;
                KillDifficulty  = 0;
                break;
            case 2:
                GapDifference   = 4;
                GapDifficulty   = 5;
                GlassDifficulty = 0;
                KillDifficulty  = 2;
                break;
            case 3:
                GapDifference   = 6;
                GapDifficulty   = 4;
                GlassDifficulty = 2;
                KillDifficulty  = 4;
                break;
            case 4:
                GapDifference   = 8;
                GapDifficulty   = 4;
                GlassDifficulty = 4;
                KillDifficulty  = 6;
                break;
            case 5:
                GapDifference   = 10;
                GapDifficulty   = 3;
                GlassDifficulty = 6;
                KillDifficulty  = 8;
                break;
        }
    }

    private void GenerateLevel()
    {
        var levelInstance = Instantiate(Level);

        var columnInstance = Instantiate(Column, levelInstance.transform);
        columnInstance.transform.position = new Vector3(0f, FloorsGap * FloorsNumber * -0.5f, 0f);
        columnInstance.transform.localScale = new Vector3(2f, FloorsGap * FloorsNumber * 0.5f, 2f);

        SpawnFloors(levelInstance);
        SpawnFinish(levelInstance);
    }

    private void SpawnFloors(GameObject levelObject)
    {
        var gapBasis = Random.Range(0, SegmentsNumber); // Вибираємо перший рандомний індекс

        for (int floorIndex = 0; floorIndex < FloorsNumber; floorIndex++)
        {
            var floorSpawnPosition = new Vector3(0.0f, -floorIndex * FloorsGap, 0.0f);
            var floorInstance = Instantiate(Floor, floorSpawnPosition, Quaternion.identity, levelObject.transform);

        //********************* РОЗРАХУНОК GAPS *********************//
            int[] gapIndexes = new int[GapDifficulty];
            GenerateGaps(gapBasis, gapIndexes);
        //**********************************************************//

        //********************** РОЗРАХУНОК KILLBLOCKS **********************//
            int[] killIndexes = new int[KillDifficulty];
            var killBegin = (gapBasis + GapDifficulty) % SegmentsNumber;
            GenerateKill(killIndexes, killBegin);
        //*****************************************************************//
        
        //********************** РОЗРАХУНОК GLASSBLOCKS **********************/
            int[] glassIndexes = new int[GlassDifficulty];
            var glassBegin = (gapBasis + GapDifficulty) % SegmentsNumber;
            GenerateGlass(glassIndexes, glassBegin, killIndexes);
        //*****************************************************************//

        //********************** ЗАПОВНЕННЯ ПОВЕРХУ **********************//
            for (int segmentIndex = 0; segmentIndex < SegmentsNumber; segmentIndex++)
            {
                if (gapIndexes.Contains(segmentIndex))
                {
                    continue;
                }
                else if (killIndexes.Contains(segmentIndex))
                {
                    SpawnSegment(KillSegment, floorSpawnPosition, floorInstance, segmentIndex);
                }
                else if (glassIndexes.Contains(segmentIndex))
                {
                    SpawnSegment(GlassSegment, floorSpawnPosition, floorInstance, segmentIndex);
                }
                else
                {
                    SpawnSegment(BasicSegment, floorSpawnPosition, floorInstance, segmentIndex);
                }
            }
        //*****************************************************************//
        }
    }

    private void SpawnSegment(GameObject segment, Vector3 floorSpawnPosition, GameObject floorInstance, int index)
    {
        var SegmentInstance = Instantiate(segment, floorSpawnPosition, Quaternion.identity, floorInstance.transform);
        SegmentInstance.transform.Rotate(0.0f, AngleDiff * index, 0.0f, Space.Self);
        SegmentInstance.GetComponent<Segment>().Index = index;
    }

    private void GenerateGaps(int gapBasis, int[] gapIndexes){
        gapBasis = (gapBasis + Random.Range(-GapDifference, GapDifference)) % SegmentsNumber;

        for (int index = 0; index < gapIndexes.Length; index++)
        {
            gapIndexes[index] = (gapBasis + index) % SegmentsNumber;
        }
    }

    private void GenerateKill(int[] killIndexes, int killBegin){

        for (int j = 0; j < KillDifficulty; j++)
        {
            var killIndex = (killBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;

            while (killIndexes.Contains(killIndex))
            {
                killIndex = (killBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;
            }

            killIndexes[j] = killIndex;
        }
    }

    private void GenerateGlass(int[] glassIndexes, int glassBegin, int[] killIndexes){

        for (int j = 0; j < GlassDifficulty; j++)
        {
            var glassIndex = (glassBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;
            
            while (glassIndexes.Contains(glassIndex) || killIndexes.Contains(glassIndex))
            {
                glassIndex = (glassBegin + Random.Range(0, SegmentsNumber - GapDifficulty)) % SegmentsNumber;
            }

            glassIndexes[j] = glassIndex;
        }
    }

    private void SpawnFinish(GameObject levelObject)
    {
        var floorSpawnPosition = new Vector3(0.0f, FloorsNumber, 0.0f);
        var FinishInstance = Instantiate(FinishSegment, floorSpawnPosition, Quaternion.identity, levelObject.transform);

        for (int segmentIndex = 0; segmentIndex < SegmentsNumber; segmentIndex++)
        {
            SpawnSegment(FinishSegment, floorSpawnPosition, FinishInstance, segmentIndex);
        }
    }
}
