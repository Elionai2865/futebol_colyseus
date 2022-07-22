using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingToPlayer : MonoBehaviour
{
	public GameObject objectTaggedPlayer1;
	public GameObject objectTaggedPlayer2;
	public bool playersConnected = false;
	public int youArePlayer = 0;
	public Text myText;
	public int gameStage = 0; //0:Waiting for opponent and setting game, 1:Playing, 2:Result
	public ShootAI shootAI;
	public bool myTurn = false;
	public score MyScore;
	public GameObject outText;
	public GameObject defenseText;
	public GameObject goalText;

	public GameObject scoreCollider;
	public GameObject minhaBola;
	public GameObject bolaDeTeste;

	bool setTime = false;
	float timeTheTurnStarts;
	int oldTries;

	void Start()
    {
		myText.text = "Waiting for Opponent";
    }

    
    void Update()
    {
		if(!playersConnected)
        {
			objectTaggedPlayer1 = GameObject.FindWithTag("player1");
			objectTaggedPlayer2 = GameObject.FindWithTag("player2");
			if (objectTaggedPlayer1 != null)
            {
				youArePlayer = 1;
				playersConnected = true;
				myTurn = true;
            }
			else if (objectTaggedPlayer2 != null)
            {
				youArePlayer = 2;
				playersConnected = true;
				myTurn = false;
            }
		}
		else if(gameStage==0)
        {
			StartCoroutine(youRePlayer());
        }

		if(gameStage==1)
        {
			if(youArePlayer==1)
            {
				if (MyScore.tries == MyScore.opponentTries) myTurn = true;
				else
				{
					myTurn = false;
					outText.SetActive(false);
					defenseText.SetActive(false);
					goalText.SetActive(false);
				}
            }
			if(youArePlayer==2)
            {
				if (MyScore.tries == MyScore.opponentTries)
				{
					myTurn = false;
					outText.SetActive(false);
					defenseText.SetActive(false);
					goalText.SetActive(false);
				}
				else myTurn = true;
			}
			if (myTurn && (shootAI._enableTouch || oldTries == shootAI.tries)) itsMyTurn();
			else itsMyOpponentsTurn();

			if(MyScore.gameOver)
            {
				gameStage = 2;
            }
        }

		if(gameStage==2)
        {
			myText.text = "GAME OVER";
			gameStage = 3;
		}

    }

	void itsMyTurn()
    {
		if(!setTime)
        {
			timeTheTurnStarts = Time.time;
			setTime = true;
			oldTries = shootAI.tries;
        }
		if (Time.time < timeTheTurnStarts + 3f)
		{
			myText.text = "It's your turn";
		}
		else if (Time.time > timeTheTurnStarts + 3f && Time.time < timeTheTurnStarts + 8f)
        {
			myText.text = "You have 5 seconds to shoot";
		}
		else if(Time.time > timeTheTurnStarts + 8f && Time.time < timeTheTurnStarts + 11f && shootAI._enableTouch == true)
        {
			myText.text = "Missed your turn";
			shootAI._enableTouch = false;
		}
		else if (Time.time > timeTheTurnStarts + 11f)
		{
			shootAI._enableTouch = true;
			shootAI.tries++;
		}
	}

	void itsMyOpponentsTurn()
    {
		setTime = false;
		myText.text = "It's your opponent's turn";
	}

	IEnumerator youRePlayer()
    {
		myText.text = "You are Player " + youArePlayer;
		yield return new WaitForSeconds(3f);
		gameStage=1;
		scoreCollider.SetActive(true);
		bolaDeTeste.SetActive(false);
		minhaBola.GetComponent<Renderer>().enabled = true;
		minhaBola.GetComponent<Collider>().enabled = true;
		ExampleManager.NetSend("lockOrUnlockTheRoom", true);
		minhaBola.transform.localPosition = new Vector3(-0.09000088f, -0.6199998f, -8.7f);
	}
}
