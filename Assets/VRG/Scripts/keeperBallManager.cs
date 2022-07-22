using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keeperBallManager : MonoBehaviour
{

	public TalkingToPlayer iTalkToMyPlayer;
	public GameObject myKeeper;
	public GameObject myBall;
	public GameObject myFootball;
	public GameObject opponentsKeeper;
	private bool previousTurnState=false;
	private float myBallInicialZPosition = -14.0f;
	private bool onlyOnce = true;
	public ShootAI myShootAI;

	void Start()
    {
        
    }

	IEnumerator ball1()
    {
		iTalkToMyPlayer.objectTaggedPlayer1.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(1.0f);
		iTalkToMyPlayer.objectTaggedPlayer1.GetComponent<Renderer>().enabled = true;
	}


	IEnumerator ball2()
	{
		iTalkToMyPlayer.objectTaggedPlayer2.GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds(1.0f);
		iTalkToMyPlayer.objectTaggedPlayer2.GetComponent<Renderer>().enabled = true;
	}

	IEnumerator myBallWait()
    {
		myShootAI._enableTouch = false;
		yield return new WaitForSeconds(1.5f);
		myShootAI._enableTouch = true;
	}

	void Update()
    {
		///////////////////////////////////////////////MANAGING THE BALLS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		if (previousTurnState != iTalkToMyPlayer.myTurn || (iTalkToMyPlayer.MyScore.opponentTries == 0 && iTalkToMyPlayer.MyScore.tries == 0 && onlyOnce))
		{
			if (iTalkToMyPlayer.youArePlayer == 1)
			{
				onlyOnce = false;
				if (iTalkToMyPlayer.myTurn)
				{
					iTalkToMyPlayer.objectTaggedPlayer1.SetActive(false);
					myBall.SetActive(true);
					StartCoroutine(myBallWait());
					if (iTalkToMyPlayer.MyScore.opponentTries == 0 && iTalkToMyPlayer.MyScore.tries == 0)
                    {
						myFootball.GetComponent<ShootAI>().reset();
                    }
				}
				else
				{
					myBall.SetActive(false);
					StartCoroutine(ball1());
					iTalkToMyPlayer.objectTaggedPlayer1.SetActive(true);
					iTalkToMyPlayer.objectTaggedPlayer1.transform.position = new Vector3(0.0f, 0.34f, -8.7f);
					iTalkToMyPlayer.objectTaggedPlayer1.transform.localEulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
					iTalkToMyPlayer.objectTaggedPlayer1.GetComponent<Rigidbody>().velocity = Vector3.zero;
					iTalkToMyPlayer.objectTaggedPlayer1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				}
			}
			else if (iTalkToMyPlayer.youArePlayer == 2)
			{
				onlyOnce = false;
				if (iTalkToMyPlayer.myTurn)
				{
					iTalkToMyPlayer.objectTaggedPlayer2.SetActive(false);
					myBall.SetActive(true);
					StartCoroutine(myBallWait());
					if (iTalkToMyPlayer.MyScore.opponentTries == 1 && iTalkToMyPlayer.MyScore.tries == 0)
					{
						myFootball.GetComponent<ShootAI>().reset();
					}
				}
				else
				{
					myBall.SetActive(false);
					StartCoroutine(ball2());
					iTalkToMyPlayer.objectTaggedPlayer2.SetActive(true);
					iTalkToMyPlayer.objectTaggedPlayer2.transform.position = new Vector3(0.0f, 0.34f, -8.7f);
					iTalkToMyPlayer.objectTaggedPlayer2.transform.localEulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
					iTalkToMyPlayer.objectTaggedPlayer2.GetComponent<Rigidbody>().velocity = Vector3.zero;
					iTalkToMyPlayer.objectTaggedPlayer2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				}
			}
		}


		///////////////////////////////////////////////MANAGING THE KEEPERS\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		if (opponentsKeeper == null)
		{
			opponentsKeeper = GameObject.FindWithTag("keeperOpponent");
		}
		else if (previousTurnState != iTalkToMyPlayer.myTurn || (iTalkToMyPlayer.MyScore.opponentTries==0 && iTalkToMyPlayer.MyScore.tries == 0))
		{
			if (iTalkToMyPlayer.myTurn)
			{
				opponentsKeeper.SetActive(true);
			}
			else
			{
				opponentsKeeper.SetActive(false);
			}
		}

		if (previousTurnState != iTalkToMyPlayer.myTurn)
		{
			if (iTalkToMyPlayer.myTurn)
			{
				myKeeper.SetActive(false);
			}
			else
			{
				myKeeper.SetActive(true);
			}
		}
		previousTurnState = iTalkToMyPlayer.myTurn;
	}
}
