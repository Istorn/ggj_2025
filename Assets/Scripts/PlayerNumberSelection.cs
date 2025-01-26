using UnityEngine;

public class PlayerNumberSelection : MonoBehaviour
{
    public int numberOfPlayers;
    
    void Start()
    {
        numberOfPlayers = 1;
    }

    public void met_AddPlayer()
    {
        if(numberOfPlayers<4)
        {
            numberOfPlayers++;
        }
    }
    public void met_RemovePlayer()
    {
        if(numberOfPlayers>0)
        {
            numberOfPlayers--;
        }    
    }
}
