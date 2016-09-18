using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class game_Controller : MonoBehaviour {
	
	public string[] word = new string[]{"allo","whatever","young","money","perspective","computer","java","python","random",
		"friend","stranger","why","common","laptop","success","professional","coffee","same","engine","camera","annoying","serialize","banana",
		"system","verb","risk","collection","god","greek","america","when","who","typing","pooping","toilet","television","keyboard",
		"graphic","music","piano","bottle","chair","control","project","tools","build","search","window","development","concret"};
	public int num;
	public string currentWord;
	public Text displayWord;
	System.Random rand = new System.Random();
	public float x = -150f;
	public float y = 0f;
	public float z = 0f;
	public int tmr1000 = 0;
	public int counterRight = 0;
	public int counterWrong = 0;

	//the easier way of doing it
	//this will take the input, print it and remove it
	[SerializeField]
	private InputField input;

	[SerializeField]
	private Text text_3;

	[SerializeField]
	private Text text_2;

	[SerializeField]
	private Text text_1;

	public void Start(){
	 	//this is a one way of doing it(longer)
		//input = GameObject.Find ("Input_From_User").GetComponent<InputField> ();
		text_1.text = "Match the word";
		text_2.text = "right count " + counterRight;
		text_3.text = "wrong count " + counterWrong;
		currentWord = getWord ();
		displayWord.text = getWord ();
	}

	public void Update(){
		x += 0.5f;
		int tick = Environment.TickCount;
		if (tick > tmr1000) {
			displayWord.rectTransform.position.Set(x, 0, 0);
			string newWord = getWord ();
			displayWord.text = newWord;
			currentWord = newWord;
			tmr1000 = tick + 2000;
		}
	}

		
	//getting the input from user and call the method compareGuess
	//to figure out if the number is correct
	public void getInput(string input_1){
		input.GetComponent<InputField> ().ActivateInputField ();
		compareGuess (input_1);
		text_2.text = "right count " + counterRight;
		text_3.text = "wrong count " + counterWrong;
		input.text = "";
	}
	//comparing the number if it is correct
	public void compareGuess(string input_1){
		if (currentWord.Equals(input_1)) {
			text_1.text = "CORRECT";
			counterRight++;
		} else {
			text_1.text = "INCORRECT";
			counterWrong++;
		}
	}

	public string getWord(){
		string word_2;
		num = rand.Next (this.word.Length);
		word_2 = word [num];
		wait (100f);
		return word_2;
	}

	public IEnumerator wait(float f){
		yield return new WaitForSeconds(f);
	}
}
