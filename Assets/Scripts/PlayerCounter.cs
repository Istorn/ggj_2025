using UnityEngine;
using UnityEngine.UI;

public class PlayerCounter : MonoBehaviour
{
    int numberOfPlayers;
    Text playerNumber;
    private void Start()
    {
        playerNumber = gameObject.GetComponent<Text>();
        numberOfPlayers = 1;
        playerNumber.text = "1";
    }
    public void met_PlayerAdd()
    {
        if (numberOfPlayers < 4)
        {
            numberOfPlayers++;
            UpdateNumber();
        }
    }
    public void met_PlayerRemove()
    {
        if(numberOfPlayers > 1)
        {
            numberOfPlayers--;
            UpdateNumber();
        }
    }
    void UpdateNumber()
    {
        playerNumber.text = numberOfPlayers.ToString();
    }
}
