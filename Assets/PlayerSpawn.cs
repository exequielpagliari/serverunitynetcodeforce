using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NetworkObject>().SpawnAsPlayerObject(1);
        GetComponent<NetworkObject>().SpawnAsPlayerObject(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
