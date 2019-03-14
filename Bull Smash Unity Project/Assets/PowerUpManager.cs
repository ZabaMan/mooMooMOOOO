using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _powerUpList;
    [SerializeField] private List<Transform> _respawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        int l = Random.Range(0, _respawnLocations.Count);
        int p = Random.Range(0, _powerUpList.Count);
        Instantiate(_powerUpList[p], _respawnLocations[l]);
    }



    public void NewPowerUp()
    {
        int l = Random.Range(0, _respawnLocations.Count);
        int p = Random.Range(0, _powerUpList.Count);
        Instantiate(_powerUpList[p], _respawnLocations[l]);
    }

    public GameObject indexToOverheadItem(int index)
    {
        return _powerUpList[index];
    }
}
