using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    public Spawner GameController;
    public GameObject Ramps;

    private Quaternion _baseRotation;

    private void Start()
    {
        if (Ramps != null)
            _baseRotation = Ramps.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 currentOffset = Camera.main.transform.position - other.transform.position;
            other.transform.position = GameController.RespawnPoint.position;
            Camera.main.transform.position = other.transform.position + currentOffset;
            other.transform.GetComponent<Rigidbody>().velocity = new Vector3(0, other.transform.GetComponent<Rigidbody>().velocity.y, 0);
            Ramps.transform.rotation = _baseRotation;
        }
    }
}
