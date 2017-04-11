using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class generateRooms : MonoBehaviour
{
    public int numRooms = 5;
    public GameObject[] rooms;
    public GameObject[] bossRooms;
    public float roomSize = 20;

    public GameObject door;
    public GameObject blocker;
    //public GameObject blocker;

    private Vector3[] roomLocations;
    private List<Vector3> doorLocations;
    private List<Vector3> doorRotations;
    // Use this for initialization

    void Start()
    {
        int i;
        roomLocations = new Vector3[numRooms + 2];
        roomLocations[0] = this.transform.position;
        doorLocations = new List<Vector3>();
        doorRotations = new List<Vector3>();
        //Random room generation
        for (int n = 1; n < numRooms; n++)
        {
            roomLocations[n] = this.transform.position;
            for (int j = 0; j < n; j++)
            {
                if (roomLocations[n] == roomLocations[j])
                {
                    roomLocations[n] = roomLocations[n - 1] + movement();
                    j = -1;
                }
            }
            i = Random.Range(0, rooms.Length);
            Instantiate(rooms[i], roomLocations[n], Quaternion.identity);
        }
        //Create doors
        doorGeneration();
        //Create random boss room
        roomLocations[numRooms + 1] = bossLocation();
        blockGeneration();
        Destroy(this);
    }
    

    private Vector3 movement()
    {
        Vector3 move = new Vector3(0, 0, 0);
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0:
                move = new Vector3(1, 0, 0)*roomSize;
                break;
            case 1:
                move = new Vector3(-1, 0, 0) * roomSize;
                break;
            case 2:
                move = new Vector3(0, 0, 1) * roomSize;
                break;
            case 3:
                move = new Vector3(0, 0, -1) * roomSize;
                break;
            default:
                move = new Vector3(1, 0, 0) * roomSize;
                break;
        }
        return move;
    }

    private Vector3 findangle(Vector3 move)
    {
        Vector3 rotation = new Vector3(0, 0, 0);
        if (move / move.magnitude == new Vector3(0, 0, 1))
        {

        }
        else if (move / move.magnitude == new Vector3(0, 0, -1))
        {
            rotation = new Vector3(0, -180, 0);
        }
        else if (move / move.magnitude == new Vector3(1, 0, 0))
        {
            rotation = new Vector3(0, 90, 0);
        }
        else if (move / move.magnitude == new Vector3(-1, 0, 0))
        {
            rotation = new Vector3(0, -90, 0);
        }
        return rotation;
    }


    private Vector3 bossLocation()
    {
        Vector3 boss = new Vector3(0, 0, 0);
        Vector3 lastRoom = new Vector3(0, 0, 0);
        int i; 
        Vector3 move = new Vector3(0, 0, 0);
        for (int n = 1; n <= numRooms; n++)
        {
            if (Vector3.Distance(lastRoom, this.transform.position) < Vector3.Distance(roomLocations[n], this.transform.position))
            {
                lastRoom = roomLocations[n];
            }
        }
        for (int j = 0; j <= numRooms; j++)
        {
            if (boss == roomLocations[j])
            {
                move = movement();
                boss = lastRoom + move;
                j = -1;
            }
        }
        doorLocations.Add(lastRoom + (move/2));
        i = Random.Range(0, bossRooms.Length);
        Instantiate(bossRooms[i], boss, Quaternion.Euler(findangle(move)));
        return boss;
    }


    private void doorGeneration()
    {
        int length = 0;
        Vector3 roomDif = new Vector3(0, 0, 0);

        for (int m = 0; m<=numRooms; m++)
        {
            for(int n = 0; n<=numRooms; n++)
            {
                roomDif = roomLocations[m] - roomLocations[n];
                if (roomDif.magnitude == roomSize)
                {
                    doorRotations.Add(findangle(roomDif));
                    
                    doorLocations.Add(roomLocations[n] + roomDif / 2);
                    

                }
            }
        }
        
        length = doorLocations.Count;
        for (int i = 0; i< length; i++)
        {
            for (int j = 0; j<length; j++)
            {
                if ((doorLocations[i] == doorLocations[j])&(i != j)){
                    doorLocations.RemoveAt(j);
                    doorRotations.RemoveAt(j);
                    j = j - 1;
                }
                length = doorLocations.Count;
            }
            Instantiate(door,doorLocations[i],Quaternion.Euler(doorRotations[i]));
        }
    }

    private void blockGeneration()
    {
        Vector3 check = new Vector3(0, 0, 0);
        for(int m = 0; m<roomLocations.Length; m++)
        {
            check = roomLocations[m] + (new Vector3(0, 0, 1) * (roomSize / 2));
            if (addBlock(check))
            {
                Instantiate(blocker,check , Quaternion.Euler(0,0,0));
            }
            check = roomLocations[m] + (new Vector3(0, 0, -1) * (roomSize / 2));
            if (addBlock(check))
            {
                Instantiate(blocker, check, Quaternion.Euler(0, -180, 0));
            }
            check = roomLocations[m] + (new Vector3(1, 0, 0) * (roomSize / 2));
            if (addBlock(check))
            {
                Instantiate(blocker, check, Quaternion.Euler(0, 90, 0));
            }
            check = roomLocations[m] + (new Vector3(-1, 0, 0) * (roomSize / 2));
            if (addBlock(check))
            {
                Instantiate(blocker, check, Quaternion.Euler(0, -90, 0));
            }
        }
    }

    private bool addBlock(Vector3 loc)
    {
        bool block = true;
        for(int n = 0; n< doorLocations.Count; n++)
        {
            if(loc == doorLocations[n])
            {
                block = false;
            }
        }
        return block;
    }

}
