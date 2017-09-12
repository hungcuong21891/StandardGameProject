using UnityEngine;
using System.Collections;
using BaseFramework;

public class IAPAction : MonoBehaviour {
	void Start(){
		EventManager.StartListening ("removeAds", RemoveAds);
		EventManager.StartListening ("coinPack1", BuyCoinPack1);
		EventManager.StartListening ("coinPack2", BuyCoinPack2);
		EventManager.StartListening ("coinPack3", BuyCoinPack3);
	}

	void RemoveAds(EventInfo info){
		AdController.GetInstance ().RemoveAd ();
		PlayerManager.GetInstance().RemoveAds();
	}

	void BuyCoinPack1(EventInfo info){
		PlayerManager.GetInstance ().AddCoin (GameManager.GetInstance ().coinPackInformation.coinPack1.addedCoin);
	}

	void BuyCoinPack2(EventInfo info){
		PlayerManager.GetInstance ().AddCoin (GameManager.GetInstance ().coinPackInformation.coinPack2.addedCoin);
	}

	void BuyCoinPack3(EventInfo info){
		PlayerManager.GetInstance ().AddCoin (GameManager.GetInstance ().coinPackInformation.coinPack3.addedCoin);
	}
}
