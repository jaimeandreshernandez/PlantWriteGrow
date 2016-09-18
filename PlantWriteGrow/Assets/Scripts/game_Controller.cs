using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_Controller : MonoBehaviour {

	private int num;
	private int count = 0;

	//the easier way of doing it
	//this will take the input, print it and remove it
	[SerializeField]
	private InputField input;

	[SerializeField]
	private Text text_1;

	[SerializeField]
	private GameObject btn;

	public void Awake(){
	 	//this is a one way of doing it(longer)
		//input = GameObject.Find ("Input_From_User").GetComponent<InputField> ();
		num = Random.Range(0,100);
		text_1.text = "Guess the a number between 0 to 100";
	}
	//getting the input from user and call the method compareGuess
	//to figure out if the number is correct
	public void getInput(string input_1){
		input.GetComponent<InputField> ().ActivateInputField ();
		compareGuess (int.Parse(input_1));
		input.text = "";
		count++;
	}
	//comparing the number if it is correct
	public void compareGuess(int input_1){
		if (num == input_1) {
			text_1.text = "you guessed the number correctly the number was " + input_1 
				+ " and it took you " + count + " time(s) to figure it out. Do you want to play again? ";
			btn.SetActive (true);
		} else if (input_1 < num) {
			text_1.text = "your number is less than the number you are trying to guess";
		} else if (input_1 > num) {
			text_1.text = "your number is greater than the number you are trying to guess";
		}
	}

	//if the user wants to play again
	public void playAgain(){
		num = Random.Range(0,100);
		text_1.text = "Guess the a number between 0 to 100";
		count = 0;
		btn.SetActive (false);
	}

}
