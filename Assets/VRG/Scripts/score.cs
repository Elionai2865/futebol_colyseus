using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Colyseus;
using Colyseus.Schema;

public class score : MonoBehaviour
{
	public score otherScore;
	public ShootAI shootAI;
	public  GameObject scoreCount; 
    public  GameObject goalAlert;
	public GameObject outAlert;
	public GameObject defenseAlert;
	public int scorePlayer1;
	public int scorePlayer2;
    public Text scoreText;
	public Text scoreP2;
	public int tries;
	public int opponentTries;
	public int opponentScoreI;
	public GameObject youWin;
	public GameObject youLose;
	public GameObject itsADraw; 
	public GameObject opponentScore;
	public bool gameOver = false;
	public GameObject playAgain;
	public GameObject manager;

	bool goalWasScored = false;
	
    void Start()
    {
        scorePlayer1 = 0;
		scorePlayer2 = 0;
	}

  
    void Update()
    {
		manager = GameObject.Find("Manager");
		tries = shootAI.tries;
		if(opponentScore==null)
        {
			opponentScore = GameObject.FindWithTag("score");
			scoreP2.text = "OpponentScore: 0";
		}
		else
        {
			opponentScoreI = arredondamento(float.Parse(opponentScore.GetComponent<TextMesh>().text));
			scoreP2.text = "OpponentScore: " + opponentScoreI;
			opponentTries = arredondamento(opponentScore.transform.localPosition.y);
		}
        scoreText.text = "MyScore: " + scorePlayer1;
		if (shootAI.tries == shootAI.maxTries && opponentTries == shootAI.maxTries && !gameOver)
        {
			gameOver = true;
			//Destroy(manager);
			playAgain.SetActive(true);
			if (scorePlayer1 == opponentScoreI)
				itsADraw.SetActive(true);
			else if (scorePlayer1 > opponentScoreI)
				youWin.SetActive(true);
			else
				youLose.SetActive(true);
		}
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Ball")
        {
				scorePlayer1++;
				StartCoroutine(enableScore());
		}
		else if (collision.tag == "out")
        {
			StartCoroutine(coOut());
        }
    }

	void OnCollisionEnter(Collision theColider)
    {
		if(theColider.gameObject.tag == "keeperOpponent" && (!goalWasScored || !otherScore.goalWasScored))
        {
			StartCoroutine(savedByKeeper());
        }
    }

	public void scoreIncrement()
    {
		scorePlayer1++;
		StartCoroutine(enableScore());
	}

	IEnumerator savedByKeeper()
	{
		defenseAlert.SetActive(true);
		outAlert.SetActive(false);
		goalAlert.SetActive(false);
		yield return new WaitForSeconds(3f);
		defenseAlert.SetActive(false);
	}

	IEnumerator coOut()
    {
		outAlert.SetActive(true);
		goalAlert.SetActive(false);
		defenseAlert.SetActive(false);
		yield return new WaitForSeconds(3f);
		Debug.Log("out over");
		outAlert.SetActive(false);
    }

    IEnumerator enableScore()
    {
		goalWasScored = true;
        goalAlert.SetActive(true);
		outAlert.SetActive(false);
		defenseAlert.SetActive(false);
		scoreCount.SetActive(false);
        yield return new WaitForSeconds(3f);
		goalAlert.SetActive(false);
		scoreCount.SetActive(true);
		goalWasScored = false;
	}

	private int arredondamento(float valor)
    {
		valor += 0.4f;
		if (valor < 0.41f)
			return 0;
		else if (valor < 1.41f)
			return 1;
		else if (valor < 2.41f)
			return 2;
		else if (valor < 3.41f)
			return 3;
		else if (valor < 4.41f)
			return 4;
		else if (valor < 5.41f)
			return 5;
		else
			return 0;
	}
}
