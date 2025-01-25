using UnityEngine;

public class RopeSegment : MonoBehaviour
{
    public GameObject ropeSegmentPrefab; // Prefab for a single rope segment
    public Transform anchorPoint;       // The anchor point at the top of the rope
    public GameObject bridge;           // The bridge object
    public int segmentCount = 10;       // Number of rope segments

    private void Start()
    {
        Vector3 anchorPosition = anchorPoint.position;
        Vector3 bridgePosition = bridge.transform.position;

        float totalDistance = Vector3.Distance(anchorPosition, bridgePosition);
        float segmentLength = totalDistance / segmentCount;

        Rigidbody2D previousRb = anchorPoint.GetComponent<Rigidbody2D>();
        Vector3 segmentPosition = anchorPosition;

        for (int i = 0; i < segmentCount; i++)
        {
            GameObject segment = Instantiate(ropeSegmentPrefab, segmentPosition, Quaternion.identity);
            Rigidbody2D currentRb = segment.GetComponent<Rigidbody2D>();
            DistanceJoint2D joint = segment.GetComponent<DistanceJoint2D>();

            joint.connectedBody = previousRb;
            joint.autoConfigureDistance = false;
            joint.distance = segmentLength;

            previousRb = currentRb;
            segmentPosition = Vector3.Lerp(anchorPosition, bridgePosition, (float)(i + 1) / segmentCount);
        }

        DistanceJoint2D bridgeJoint = bridge.AddComponent<DistanceJoint2D>();
        bridgeJoint.connectedBody = previousRb;
        bridgeJoint.autoConfigureDistance = false;
        bridgeJoint.distance = segmentLength;

        // Adjust the joint anchor to attach properly
        bridgeJoint.anchor = new Vector2(0, -bridge.GetComponent<SpriteRenderer>().bounds.size.y / 2);
    }
}
