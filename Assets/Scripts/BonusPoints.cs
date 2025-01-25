using UnityEngine;

public class BonusPoints : MonoBehaviour
{
    public float minPoints;
    public float maxPoints;
    public float actualPoints;
    // Start is called before the first frame update
    void Start()
    {
        actualPoints = Random.Range(minPoints, maxPoints);
    }
}
