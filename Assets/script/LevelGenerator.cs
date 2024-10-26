using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Column;
    [SerializeField] private GameObject ColumnParent;
    [SerializeField] private GameObject Floor;
    [SerializeField] private GameObject FloorSegment;
    [SerializeField] private GameObject Kill;
    [SerializeField] private GameObject Glass;
    [SerializeField] private int SegmentsQuantity;
    [SerializeField] private int AngleDiff;
    [SerializeField] private int Difficulty;

    private void Start()
    {
        for(int k = 0; k < 10; k++){
        
            var columnIns = Instantiate(Column);
            var parentFloorInstance = Instantiate(Floor);
            var rand = Random.Range(0, 24);
            var rand2 = Random.Range(0, 24);
            var rand3 = Random.Range(0, 24);
            var rand4 = Random.Range(0, 24);
            var diff = 0;
            var of = 0;
            var go = 0;
            var pass = 0;
            if(Difficulty > 0 && Difficulty <= 5){
                diff = 1;
            } else if(Difficulty > 5){
                diff = 0;
            }


            var spawnPosition = new Vector3(0.0f, 0.0f+7*k, 0.0f);
            for (int i = 0; i < 24; i++)
            {
                if(rand == of){
                    go++;
                    of++;
                    continue;
                } else {
                    if(go == 1 && diff == 1){
                        of++;
                        diff--;
                        continue;
                    } else {
                        if(rand2 == of){ 
                            var killSegmentInstance = Instantiate(Kill, spawnPosition, Quaternion.identity, parentFloorInstance.transform);
                            killSegmentInstance.transform.Rotate(0.0f, AngleDiff * i, 0.0f, Space.Self);
                            of++;
                            pass = i + 1;
                            killSegmentInstance = Instantiate(Kill, spawnPosition, Quaternion.identity, parentFloorInstance.transform);
                            killSegmentInstance.transform.Rotate(0.0f, AngleDiff * pass, 0.0f, Space.Self);
                            of++;
                            i++;
                            pass = 0;
                        } else if(rand3 == of) {
                            var glassSegmentInstance = Instantiate(Glass, spawnPosition, Quaternion.identity, parentFloorInstance.transform);
                            glassSegmentInstance.transform.Rotate(0.0f, AngleDiff * i, 0.0f, Space.Self);
                            of++;
                            pass = i + 1;
                            glassSegmentInstance = Instantiate(Glass, spawnPosition, Quaternion.identity, parentFloorInstance.transform);
                            glassSegmentInstance.transform.Rotate(0.0f, AngleDiff * pass, 0.0f, Space.Self);
                            of++;
                            i++;
                            pass = 0;
                            continue;
                        } else {
                            var floorSegmentInstance = Instantiate(FloorSegment, spawnPosition, Quaternion.identity, parentFloorInstance.transform);
                            floorSegmentInstance.transform.Rotate(0.0f, AngleDiff * i, 0.0f, Space.Self);
                            of++;
                        }
                    }
                }
            }
            var columnSegmentInstance = Instantiate(Column, spawnPosition, Quaternion.identity, ColumnParent.transform);
        }
    }
}
