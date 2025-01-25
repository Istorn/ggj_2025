using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public GameObject ropeSegmentPrefab; // Prefab for a single rope segment
    public Transform anchorPoint;       // The anchor point at the top of the rope
    public GameObject bridge;           // The bridge object
    public int segmentCount = 10;       // Number of rope segments

    private void Start()
    {
        // Get the distance between the anchor and the bridge
        Vector3 anchorPosition = anchorPoint.position;
        Vector3 bridgePosition = bridge.transform.position;

        float totalDistance = Vector3.Distance(anchorPosition, bridgePosition);
        float segmentLength = totalDistance / segmentCount;

        Rigidbody2D previousRb = anchorPoint.GetComponent<Rigidbody2D>();
        Vector3 segmentPosition = anchorPosition;

        // Create rope segments
        for (int i = 0; i < segmentCount; i++)
        {
            // Instantiate and position each segment
            GameObject segment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity);
            Rigidbody2D currentRb = segment.GetComponent<Rigidbody2D>();
            DistanceJoint2D joint = segment.GetComponent<DistanceJoint2D>();

            // Connect the segment to the previous Rigidbody
            joint.connectedBody = previousRb;
            joint.autoConfigureDistance = false;
            joint.distance = segmentLength;

            // Update previous Rigidbody for the next segment
            previousRb = currentRb;

            // Move to the next segment position
            segmentPosition = Vector3.Lerp(anchorPosition, bridgePosition, (float)(i + 1) / segmentCount);
        }

        // Attach the bridge to the last segment
        DistanceJoint2D bridgeJoint = bridge.AddComponent<DistanceJoint2D>();
        bridgeJoint.connectedBody = previousRb;
        bridgeJoint.autoConfigureDistance = false;
        bridgeJoint.distance = segmentLength;
    }
}
