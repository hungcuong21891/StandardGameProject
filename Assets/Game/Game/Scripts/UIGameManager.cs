using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using BaseFramework;

namespace StandardProject {
public enum TypeOfEndGame{
	CAMPAIGN,
	HIGHSCORE,
	CAMPAIGN_HIGHSCORE
}
/// <summary>
/// User interface game manager.
/// </summary>
public class UIGameManager : MonoBehaviour {
	[Header("HasBanner Layout")]
	public Vector2 delta = new Vector2 (0, -0.5f);

	[Header("UIGame Element")]
	/// <summary>
	/// The type of end game.
	/// </summary>
	public TypeOfEndGame typeOfEndGame;
	/// <summary>
	/// The score unit.
	/// </summary>
	public string scoreUnit;
	/// <summary>
	/// The canvas.
	/// </summary>
	private GameObject canvas;
	/// <summary>
	/// The score text.
	/// </summary>
	private GameObject scoreText;
	/// <summary>
	/// The coin text.
	/// </summary>
	private GameObject coinText;
	/// <summary>
	/// The coin image.
	/// </summary>
	private GameObject coinImage;
	/// <summary>
	/// The option button.
	/// </summary>
	private GameObject optionButton;
	/// <summary>
	/// The pause popup.
	/// </summary>
	private GameObject pausePopup;
	/// <summary>
	/// The end game popup.
	/// </summary>
	private GameObject endGamePopup;
	/// <summary>
	/// The background pause button.
	/// </summary>
	private GameObject backgroundPauseButton;
	/// <summary>
	/// The campaign pause button.
	/// </summary>
	private GameObject campaignPauseButton;
	/// <summary>
	/// The retry pause button.
	/// </summary>
	private GameObject retryPauseButton;
	/// <summary>
	/// The exit pause button.
	/// </summary>
	private GameObject exitPauseButton;
	/// <summary>
	/// The close popup.
	/// </summary>
	private GameObject closePopup;
	/// <summary>
	/// The no ads button.
	/// </summary>
	private GameObject noAdsButton;
	/// <summary>
	/// The shop button.
	/// </summary>
	private GameObject shopButton;
	/// <summary>
	/// The rate button.
	/// </summary>
	private GameObject rateButton;
	/// <summary>
	/// The share button.
	/// </summary>
	private GameObject shareButton;
	/// <summary>
	/// The leaderboard button.
	/// </summary>
	private GameObject leaderboardButton;
	/// <summary>
	/// The retry end button.
	/// </summary>
	private GameObject retryEndButton;
	/// <summary>
	/// The score text end game.
	/// </summary>
	private GameObject scoreTextEndGame;
	/// <summary>
	/// The coin text end game.
	/// </summary>
	private GameObject coinTextEndGame;
	/// <summary>
	/// The best score text end game.
	/// </summary>
	private GameObject bestScoreTextEndGame;
	/// <summary>
	/// The high score sign.
	/// </summary>
	private GameObject highScoreSign;
	/// <summary>
	/// The wait video panel.
	/// </summary>
	private GameObject waitVideoPanel;
	/// <summary>
	/// The wait button1.
	/// </summary>
	private GameObject watchButton1;
	/// <summary>
	/// The wait button2.
	/// </summary>
	private GameObject watchButton2;
	/// <summary>
	/// The continue popup.
	/// </summary>
	private GameObject continuePopup;
	/// <summary>
	/// The campaign end button.
	/// </summary>
	private GameObject campaignEndButton;
	/// <summary>
	/// The next end button.
	/// </summary>
	private GameObject nextEndButton;
	/// <summary>
	/// The exit end button.
	/// </summary>
	private GameObject exitEndButton;
	/// <summary>
	/// The star 1.
	/// </summary>
	private GameObject star1;
	/// <summary>
	/// The star 2.
	/// </summary>
	private GameObject star2;
	/// <summary>
	/// The star 3.
	/// </summary>
	private GameObject star3;
	/// <summary>
	/// The has coin.
	/// </summary>
	public bool hasCoin;
	/// <summary>
	/// The has score.
	/// </summary>
	public bool hasScore;
	/// <summary>
	/// Start this instance.
	/// </summary>
	private bool hasChangeLayout = false;
	void Awake(){
		AutoFindElementsByType ();
	}

	void Start(){
		//reset pause game status
		if (GameManager.GetInstance () != null) {
			GameManager.GetInstance ().isPauseGame = false;
		}
		//customize 
		if (!hasCoin) {
			if (coinText != null) {
				coinText.SetActive (false);
				coinImage.SetActive (false);
			}
		} else {
			coinText.SetActive (true);
			coinImage.SetActive (true);
			coinText.GetComponent<Text> ().text = PlayerManager.GetInstance ().playerCoin.ToString();
		}
		if (!hasScore) {
			if (scoreText != null) {
				scoreText.SetActive (false);
			}
		} else {
			scoreText.SetActive (true);
		}
		//add button listener
		if (optionButton != null) {
			optionButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OpenPausePopup ();	
			});
		}
		if (campaignPauseButton != null) {
			campaignPauseButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnCampaign ();	
			});
		}
		if (retryPauseButton != null) {
			retryPauseButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnRetry ();	
			});
		}
		if (exitPauseButton != null) {
			exitPauseButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnExitMenu ();	
			});
		}
		if (closePopup != null) {
			closePopup.GetComponent<Button> ().onClick.AddListener (delegate {
				ClosePausePopup ();	
			});
		}
		if (noAdsButton != null) {
			noAdsButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnNoAds ();	
			});
		}
		if (shopButton != null) {
			shopButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnShop ();	
			});
		}
		if (rateButton != null) {
			rateButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnRate ();	
			});
		}
		if (shareButton != null) {
			shareButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnShare ();	
			});
		}
		if (leaderboardButton != null) {
			leaderboardButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnLeaderboard ();	
			});
		}
		if (retryEndButton != null) {
			retryEndButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnRetry ();	
			});
		}
		if (campaignEndButton != null) {
			campaignEndButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnCampaign ();	
			});
		}
		if (nextEndButton != null) {
			nextEndButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnNext ();	
			});
		}
		if (exitEndButton != null) {
			exitEndButton.GetComponent<Button> ().onClick.AddListener (delegate {
				OnExitMenu();	
			});
		}	
		//register listening
		EventManager.StartListening("EndGame", EndGame);
		EventManager.StartListening ("ShowWaitVideo", ShowWaitVideo);
		EventManager.StartListening ("HideWaitVideo", HideWaitVideo);
		EventManager.StartListening ("UpdateUIScore", UpdateUIScore);
		EventManager.StartListening ("UpdateUICoin", UpdateUICoin);
		EventManager.StartListening ("UpdateEndGameCoin", UpdateEndGameCoin);
		EventManager.StartListening ("ShowContinuePopup", ShowContinuePopup);
		EventManager.StartListening ("ShowWatchButton1", ShowWatchButton1);
		EventManager.StartListening ("ShowWatchButton2", ShowWatchButton2);
		EventManager.StartListening ("HideWatchButton1", HideWatchButton1);
		EventManager.StartListening ("HideWatchButton2", HideWatchButton2);

		if (AdController.GetInstance () != null) {
			if (AdController.GetInstance ().isShowingBanner) {
				Debug.Log ("Load UI layout that has banner");
				EventInfo eventInfo = new EventInfo ();
				eventInfo.eventFloat.Add ("deltaX", delta.x);
				eventInfo.eventFloat.Add ("deltaY", delta.y);
				EventManager.TriggerEvent ("LoadUIHasBanner", eventInfo);

				hasChangeLayout = true;
			} else {
				Debug.Log ("Load UI layout that doesn't have banner");
			}
		}
	}
	/// <summary>
	/// Opens the pause popup.
	/// </summary>
	void OpenPausePopup() {
		Debug.Log ("OpenMenu");
		SoundManager.GetInstance ().PlayOpenMenu ();
		GameManager.GetInstance ().isPauseGame = true;
		//Time.timeScale = 0;
		pausePopup.SetActive (true);
		Time.timeScale = 0;
	}
	/// <summary>
	/// Closes the pause popup.
	/// </summary>
	void ClosePausePopup() {
		SoundManager.GetInstance ().PlayClickSound ();
		GameManager.GetInstance ().isPauseGame = false;
		pausePopup.SetActive (false);
		Time.timeScale = 1;
	}
	/// <summary>
	/// Raises the campaign event.
	/// </summary>
	void OnCampaign() {
		Time.timeScale = 1;
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("ChooseCampaign", null);
	}
	/// <summary>
	/// Raises the retry event.
	/// </summary>
	void OnRetry() {
		Time.timeScale = 1;
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("EnterMap", null);
	}
	/// <summary>
	/// Raises the exit menu event.
	/// </summary>
	void OnExitMenu() {
		Time.timeScale = 1;
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("Menu", null);
	}
	/// <summary>
	/// Raises the no ads event.
	/// </summary>
	void OnNoAds() {
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("RemoveAds", null);
	}
	/// <summary>
	/// Raises the shop event.
	/// </summary>
	void OnShop() {
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("Shop", null);
	}
	/// <summary>
	/// Raises the share event.
	/// </summary>
	void OnShare() {		
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("Share", null);
	}
	/// <summary>
	/// Raises the rate event.
	/// </summary>
	void OnRate() {
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("Rate", null);
	}
	/// <summary>
	/// Raises the leaderboard event.
	/// </summary>
	void OnLeaderboard() {
		SoundManager.GetInstance ().PlayClickSound ();
		EventManager.TriggerEvent ("Leaderboard", null);
	}
	/// <summary>
	/// Raises the next event.
	/// </summary>
	void OnNext() {
		SoundManager.GetInstance ().PlayClickSound ();
		if (GameManager.GetInstance ().gameInformation.currentCampaign < GameManager.GetInstance ().gameInformation.numberCampaign) {
			GameManager.GetInstance ().gameInformation.currentCampaign += 1;
			EventManager.TriggerEvent ("EnterMap", null);
		} else {
			EventManager.TriggerEvent ("ChooseCampaign", null);
		}
	}
	/// <summary>
	/// Ends the game.
	/// </summary>
	/// <param name="eventInfo">Event info.</param>
	void EndGame(EventInfo eventInfo) {
		if (typeOfEndGame == TypeOfEndGame.CAMPAIGN) {
			SoundManager.GetInstance ().PlayClearCampaign ();
			if (GameManager.GetInstance().gameInformation.currentCampaign > PlayerManager.GetInstance ().bestCampaign) {
				PlayerManager.GetInstance ().UpdateBestCampaign (GameManager.GetInstance().gameInformation.currentCampaign);
			}
			if (GameManager.GetInstance().gameInformation.currentCampaign >= GameManager.GetInstance().gameInformation.numberCampaign) {
				EventManager.TriggerEvent ("Congratulations", null);
			}
		} else if (typeOfEndGame == TypeOfEndGame.HIGHSCORE) {
			int score;
			int coin;
			eventInfo.eventInteger.TryGetValue ("score", out score);
			eventInfo.eventInteger.TryGetValue ("coin", out coin);
			if (!GameManager.GetInstance().gameInformation.smallerScoreIsBetter) {
				if (score > PlayerManager.GetInstance ().bestScore) {
					SoundManager.GetInstance ().PlayHighScore ();
					PlayerManager.GetInstance ().UpdateBestScore (score);
					if (highScoreSign != null) {
						highScoreSign.SetActive (true);
					}
				} else {
					if (highScoreSign != null) {
						highScoreSign.SetActive (false);
					}
				}
			} else {
				if (score < PlayerManager.GetInstance ().bestScore) {
					SoundManager.GetInstance ().PlayHighScore ();
					PlayerManager.GetInstance ().UpdateBestScore (score);
					if (highScoreSign != null) {
						highScoreSign.SetActive (true);
					}
				} else {
					if (highScoreSign != null) {
						highScoreSign.SetActive (false);
					}
				}
			}
			PlayerManager.GetInstance ().AddCoin (coin);
			if (scoreTextEndGame != null) {
				scoreTextEndGame.GetComponent<Text> ().text = score.ToString ();
			}
			if (coinTextEndGame != null) {
				coinTextEndGame.GetComponent<Text> ().text = coin.ToString ();
			}
			if (bestScoreTextEndGame != null) {
				bestScoreTextEndGame.GetComponent<Text> ().text = PlayerManager.GetInstance ().bestScore.ToString ();
			}
		} else if (typeOfEndGame == TypeOfEndGame.CAMPAIGN_HIGHSCORE) {
			SoundManager.GetInstance ().PlayClearCampaign ();
			int score;
			int coin;
			int star;
			bool hasScore;
			bool hasCoin;
			bool hasStar;
			hasScore = eventInfo.eventInteger.TryGetValue ("score", out score);
			hasCoin = eventInfo.eventInteger.TryGetValue ("coin", out coin);
			hasStar = eventInfo.eventInteger.TryGetValue ("star", out star);
			if (GameManager.GetInstance().gameInformation.currentCampaign > PlayerManager.GetInstance ().bestCampaign) {
				PlayerManager.GetInstance ().UpdateBestCampaign (GameManager.GetInstance().gameInformation.currentCampaign);
			}
			if (hasScore) {
				if (!GameManager.GetInstance ().gameInformation.smallerScoreIsBetter) {
					if (score > PlayerManager.GetInstance ().bestScoreLevel [GameManager.GetInstance ().gameInformation.currentCampaign]) {
						SoundManager.GetInstance ().PlayHighScore ();
						PlayerManager.GetInstance ().UpdateBestScoreLevel (GameManager.GetInstance ().gameInformation.currentCampaign, score);
						highScoreSign.SetActive (true);
					} else {
						highScoreSign.SetActive (false);
					}
				} else {
					if (score < PlayerManager.GetInstance ().bestScoreLevel [GameManager.GetInstance ().gameInformation.currentCampaign]) {
						SoundManager.GetInstance ().PlayHighScore ();
						PlayerManager.GetInstance ().UpdateBestScoreLevel (GameManager.GetInstance ().gameInformation.currentCampaign, score);
						highScoreSign.SetActive (true);
					} else {
						highScoreSign.SetActive (false);
					}
				}
				string bestScoreString = PlayerManager.GetInstance ().bestScoreLevel [GameManager.GetInstance ().gameInformation.currentCampaign].ToString () + scoreUnit;
				bestScoreTextEndGame.GetComponent<Text> ().text = bestScoreString;
				string scoreString = score.ToString () + scoreUnit;
				scoreTextEndGame.GetComponent<Text> ().text = scoreString;
			}
			if (hasCoin) {
				PlayerManager.GetInstance ().AddCoin (coin);
				coinTextEndGame.GetComponent<Text> ().text = coin.ToString ();
			}
			if (hasStar) {
				if (star == 1) {
					star1.SetActive (true);
					star2.SetActive (false);
					star3.SetActive (false);
				} else if (star == 2) {
					star1.SetActive (false);
					star2.SetActive (true);
					star3.SetActive (false);
				} else if (star == 3) {
					star1.SetActive (false);
					star2.SetActive (false);
					star3.SetActive (true);
				}
			}

		}
		endGamePopup.SetActive (true);
	}

	void ShowWatchButton1(EventInfo info){
		watchButton1.SetActive (true);
	}

	void ShowWatchButton2(EventInfo info){
		watchButton2.SetActive (true);
	}

	void HideWatchButton1(EventInfo info){
		watchButton1.SetActive (false);
	}

	void HideWatchButton2(EventInfo info){
		watchButton2.SetActive (false);
	}
	/// <summary>
	/// Updates the user interface score.
	/// </summary>
	/// <param name="info">Info.</param>
	void UpdateUIScore(EventInfo info){
		//get current score
		int currentScore;
		info.eventInteger.TryGetValue ("score", out currentScore);
		//change text
		if (scoreText != null) {
			scoreText.GetComponent<Text> ().text = currentScore.ToString ();
		}
	}
	/// <summary>
	/// Updates the user interface coin.
	/// </summary>
	/// <param name="info">Info.</param>
	void UpdateUICoin(EventInfo info){
		int currentCoin;
		info.eventInteger.TryGetValue ("coin", out currentCoin);
		int totalCoin = PlayerManager.GetInstance ().playerCoin + currentCoin;
		//change text
		if (coinText != null) {
			coinText.GetComponent<Text> ().text = totalCoin.ToString ();
		}
	}
	/// <summary>
	/// Updates the end game coin.
	/// </summary>
	/// <param name="info">Info.</param>
	void UpdateEndGameCoin(EventInfo info){
		int currentCoin;
		info.eventInteger.TryGetValue ("coin", out currentCoin);
		//change text
		if (coinTextEndGame != null) {
			coinTextEndGame.GetComponent<Text> ().text = currentCoin.ToString ();
		}
	}
	/// <summary>
	/// Shows the wait video.
	/// </summary>
	/// <param name="info">Info.</param>
	void ShowWaitVideo(EventInfo info){
		#if !UNITY_EDITOR
		waitVideoPanel.SetActive (true);
		#endif
		HideWatchButton1 (null);
		HideWatchButton2 (null);
	}
	/// <summary>
	/// Hides the wait video.
	/// </summary>
	/// <param name="info">Info.</param>
	void HideWaitVideo(EventInfo info){
		#if !UNITY_EDITOR
		waitVideoPanel.SetActive (false);
		#endif

	}
	/// <summary>
	/// Shows continue popup
	/// </summary>
	/// <param name="info">Info.</param>
	void ShowContinuePopup(EventInfo info){
		if (continuePopup != null) {
			continuePopup.SetActive (true);
		}
	}
	/// <summary>
	/// Hides the continue popup
	/// </summary>
	/// <param name="info">Info.</param>
	public void HideContinuePopup(){
		if (continuePopup != null) {
			continuePopup.SetActive (false);
		}
	}
	/// <summary>
	/// Checks the list user interface contains point.
	/// </summary>
	/// <returns><c>true</c>, if list user interface contains point was checked, <c>false</c> otherwise.</returns>
	/// <param name="objects">Objects.</param>
	/// <param name="point">Point.</param>
	bool CheckListUIContainsPoint(List<GameObject> objects, Vector2 point){
		foreach (GameObject uiObject in objects) {
			if (uiObject != null) {
				RectTransform rect = uiObject.GetComponent<Image> ().rectTransform;
				Debug.Log ("Rect: " + rect.position.x + ", " + rect.position.y);
				if (rect != null) {
					if (RectTransformUtility.RectangleContainsScreenPoint (rect, point, null)) {
						return true;
					}
				}
			}
		}
		return false;
	}


	void Update() {
		if (AdController.GetInstance () != null) {
			if (!hasChangeLayout) {
				if (AdController.GetInstance ().isShowingBanner) {
					Debug.Log ("Load UI layout that has banner");
					EventInfo eventInfo = new EventInfo ();
					eventInfo.eventFloat.Add ("deltaX", delta.x);
					eventInfo.eventFloat.Add ("deltaY", delta.y);
					EventManager.TriggerEvent ("LoadUIHasBanner", eventInfo);
				}
				hasChangeLayout = true;
			}
		}
	}

	void AutoFindElementsByType(){
		canvas = GameObject.FindObjectOfType<UI_MainCanvas> ().gameObject;
		scoreText = GetElement(typeof(Gameplay_ScoreText));
		coinText = GetElement(typeof(Gameplay_CoinText));
		coinImage = GetElement(typeof(Gameplay_CoinImage));
		pausePopup = GetElement(typeof(Gameplay_PausePopup));
		optionButton = GetElement(typeof(Gameplay_OptionButton));
		endGamePopup = GetElement(typeof(Gameplay_EndGamePopup));
		backgroundPauseButton = GetElement(typeof(Gameplay_PauseBackground));
		campaignPauseButton = GetElement(typeof(Gameplay_CampaignPauseButton));
		retryPauseButton = GetElement(typeof(Gameplay_RetryPauseButton));
		exitPauseButton = GetElement(typeof(Gameplay_ExitPauseButton));
		closePopup = GetElement(typeof(Gameplay_ClosePopup));
		noAdsButton = GetElement(typeof(Gameplay_NoAdsButton));
		shopButton = GetElement(typeof(Gameplay_ShopButton));
		rateButton = GetElement(typeof(Gameplay_RateButton));
		shareButton = GetElement(typeof(Gameplay_ShareButton));
		leaderboardButton = GetElement(typeof(Gameplay_LeaderboardButton));
		retryEndButton = GetElement(typeof(Gameplay_RetryEndButton));
		scoreTextEndGame = GetElement(typeof(Gameplay_CurrentScoreEndGame));
		coinTextEndGame = GetElement(typeof(Gameplay_CurrentCoinEndGame));
		bestScoreTextEndGame = GetElement(typeof(Gameplay_BestScoreEndGame));
		highScoreSign = GetElement(typeof(Gameplay_HighScoreSignEndGame));
		waitVideoPanel = GetElement(typeof(Gameplay_WaitVideoPanel));
		watchButton1 = GetElement(typeof(Gameplay_WatchButton1));
		watchButton2 = GetElement(typeof(Gameplay_WatchButton2));
		continuePopup = GetElement(typeof(Gameplay_ContinuePopup));
		campaignEndButton = GetElement(typeof(Gameplay_CampaignEndButton));
		nextEndButton = GetElement(typeof(Gameplay_NextEndButton));
		exitEndButton = GetElement(typeof(Gameplay_ExitEndButton));
		star1 = GetElement (typeof(Gameplay_1Star));
		star2 = GetElement (typeof(Gameplay_2Star));
		star3 = GetElement (typeof(Gameplay_3Star));
	}

	GameObject GetElement(System.Type type){
		if (canvas.transform.GetComponentInChildren (type, true) != null) {
			return canvas.transform.GetComponentInChildren (type, true).gameObject;
		} else {
			return null;
		}
	}

}
}