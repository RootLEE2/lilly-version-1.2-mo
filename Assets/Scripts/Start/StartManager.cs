using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header ("Object Variables")]
    [SerializeField] private GameObject touchPage;
    [SerializeField] private GameObject buttonPage;
    [SerializeField] private GameObject popupPage;

    [Header ("UI Variables")]
    [SerializeField] private Button continueBtn;

    private void Start() {
        if (DataManager.gameData.newGame) {
            continueBtn.interactable = false;
        }
    }

    public void InputAnywhere() {
        touchPage.SetActive(false);
        buttonPage.SetActive(true);
    }

    public void ContinueSignal() {
        TransitionManager.instance.SceneTransition("LoadingScene");
    }

    public void NewGameSignal() {
        if (DataManager.gameData.newGame) {
            TransitionManager.instance.SceneTransition("LoadingScene");
        } else {
            buttonPage.SetActive(false);
            popupPage.SetActive(true);
        }
    }

    public void PopupAcceptSignal() {
        DataManager.instance.SetNewGame(true);
        TransitionManager.instance.SceneTransition("LoadingScene");
    }

    public void PopupCancelSignal() {
        popupPage.SetActive(false);
        buttonPage.SetActive(true);
    }

    public void SettingSignal() {
        SettingManager.instance.OpenSetting();
    }
}
