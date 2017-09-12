using UnityEngine;
using System.Collections;
using BaseFramework;

namespace StandardProject{
/// <summary>
/// Game controller.
/// </summary>
public class GameController : MonoBehaviour {
	/// <summary>
	/// The score.
	/// </summary>
	public int score = 0;
	/// <summary>
	/// The coin.
	/// </summary>
	public int coin = 0;
	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
	
	}
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
	
	}

	void Score(){
		score += 1;
		EventInfo scoreInfo = new EventInfo ();
		scoreInfo.eventInteger.Add ("score", score);
		EventManager.TriggerEvent ("UpdateUIScore", scoreInfo);
	}

	void EatCoin(){
		coin += 1;
		EventInfo coinInfo = new EventInfo ();
		coinInfo.eventInteger.Add ("coin", coin);
		EventManager.TriggerEvent ("UpdateUICoin", coinInfo);
	}

	void EndGame(){
		EventInfo endGameInfo = new EventInfo ();
		endGameInfo.eventInteger.Add ("score", score);
		endGameInfo.eventInteger.Add ("coin", coin);
		EventManager.TriggerEvent ("EndGame", endGameInfo);
	}
}
}
