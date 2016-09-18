using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class game_Controller : MonoBehaviour {

    private string[] _words = new string[] {
        "allo","whatever","young","money","perspective","computer","java","python","random",
		"friend","stranger","why","common","laptop","success","professional","coffee","same","engine","camera","annoying","serialize","banana",
		"system","verb","risk","collection","god","greek","america","when","who","typing","pooping","toilet","television","keyboard",
		"graphic","music","piano","bottle","chair","control","project","tools","build","search","window","development","concrete"
    };
	private string _currentWord;
	public Text txtCurrentWord;
	private System.Random _rng = new System.Random();
    private int tmrCurrentWord = 0;

	public void Start() {

	}

	public void Update(){
		int tick = Environment.TickCount;
		if (tick > tmrCurrentWord) {
            GenerateNewCurrentWord();
			tmrCurrentWord = tick + 5000;
		}
	}

    private void GenerateNewCurrentWord() {
        this._currentWord = GetWord().ToLower();
        Debug.Assert(string.IsNullOrEmpty(this._currentWord.Trim()), this._currentWord);
        this.txtCurrentWord.text = "Enter the word: " + this._currentWord;
    }

		
	//getting the input from user and call the method compareGuess
	//to figure out if the number is correct
	public void getInput(string text) {

        // Focus on the textbox
        this.FocusTextInput();

        // Is the current guess the correct answer?
        if (this._currentWord == text.ToLower()) {
            this.ClearTextInput();
            GameObject.FindGameObjectWithTag("Lamp Manager").GetComponent<LampManager>().UpgradeLamps();
            this.tmrCurrentWord = Environment.TickCount + 5000;
            this.GenerateNewCurrentWord();
        }
    }

    private void FocusTextInput() {
        // Focus on the textbox.
        this.GetComponent<InputField>().ActivateInputField();
    }

    private void ClearTextInput() {
        // Reset the textbox's text.
        this.GetComponent<InputField>().text = string.Empty;
    }

    private string GetWord() {
        // This beauty can be refactored into one line.
        return this._words[this._rng.Next(0, this._words.Length)];
	}

	private IEnumerator wait(float f){
		yield return new WaitForSeconds(f);
	}
}
