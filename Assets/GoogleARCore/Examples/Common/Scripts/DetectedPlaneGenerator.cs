

namespace GoogleARCore.Examples.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using GoogleARCore;
    using UnityEngine;

    /// <summary>
    /// Manages the visualization of detected planes in the scene.
    /// </summary>
    public class DetectedPlaneGenerator : MonoBehaviour
    {
        /// <summary>
        /// A prefab for tracking and visualizing detected planes.
        /// </summary>
        public GameObject DetectedPlanePrefab;

        public List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();
        public List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();

        public void Update()
        {

            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }
            Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);

            for (int i = 0 ; i < m_NewPlanes.Count; i++)
            {
                
                GameObject planeObject =
                    Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
                planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[i]);

                m_AllPlanes.Add(m_NewPlanes[i]);
            }
        }        

    }    
}
