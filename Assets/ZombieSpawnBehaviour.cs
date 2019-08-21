using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;


public class ZombieSpawnBehaviour : MonoBehaviour
{
    public DetectedPlane _detectedPlane;
    public GameObject _zombie;
    private GameController _control;
    float _delayTime = 0;
    float _delay = 10f;


    // Start is called before the first frame update
    void Start()
    {
        _control = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (/*_control._isStarted && */Time.time > _delayTime)
        {
            ZombieSpawn();
            _delayTime = Time.time + _delay;
        }
    }

    private void ZombieSpawn()
    {
        StartCoroutine(ZombieSpawnRoutine());
    }

    IEnumerator ZombieSpawnRoutine()
    {
        Debug.Log("im here");
        int rndX = Random.Range(-5, 5);
        int rndZ = Random.Range(0, 5);
        yield return new WaitForSeconds(3f);
        Instantiate(_zombie, transform.position + new Vector3(rndX, transform.position.y, rndZ), Quaternion.identity);
    }
}
//if (_detectedPlane == null)
//      {
//          return;
//      }

//      if (_detectedPlane.TrackingState != TrackingState.Tracking)
//      {
//          return;
//      }
//      while (_detectedPlane.SubsumedBy != null)
//      {
//          _detectedPlane = _detectedPlane.SubsumedBy;
//      }



//void SpawnInstance()
//{
//    // Pick a location.  This is done by selecting a vertex at random and then
//    // a random point between it and the center of the plane.
//    List<Vector3> vertices = new List<Vector3>();
//    _detectedPlane.GetBoundaryPolygon(vertices);
//    Vector3 pt = vertices[Random.Range(0, vertices.Count)];
//    float dist = Random.Range(1f, 4f);
//    Vector3 position = Vector3.Lerp(pt, _detectedPlane.CenterPose.position, dist);
//    // Move the object above the plane.
//    //position.y += .05f;


//    Anchor anchor = _detectedPlane.CreateAnchor(new Pose(position, Quaternion.identity));

//    _zombie = Instantiate(_zombie, position, Quaternion.identity, anchor.transform);

//    // Set the tag.
//    _zombie.tag = "food";

//    _zombie.transform.localScale = new Vector3(.025f, .025f, .025f);
//    _zombie.transform.SetParent(anchor.transform);

//}

//public void SetSelectedPlane(DetectedPlane selectedPlane)
//{
//    _detectedPlane = selectedPlane;
//}