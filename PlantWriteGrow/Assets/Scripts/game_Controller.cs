using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class game_Controller : MonoBehaviour {

    private string[] _words = new string[] {
        "allo","whatever","young","money","perspective","computer","java","python","random",
		"friend","stranger","why","common","laptop","success","professional","coffee","same","engine","camera","annoying","serialize","banana",
		"system","verb","risk","collection","god","greek","america","when","who","typing","pooping","toilet","television","keyboard",
		"graphic","music","piano","bottle","chair","control","project","tools","build","search","window","development","concrete","appreciated","awesome","blissful",
		"public","private","protected","default","package","void","main","constructor","mushroom","brilliant","cheerful","comfortable","courageous","inheritance","polymorphism",
		"generic","delightful","dynamic","harmonious","assassination","minister","invigorated","irresistible","magnificent","marvellous","optimistic","passionate","peaceful",
		"refreshed","sensational","spectacular","tranquil","unlimited","vivacious","welcomed","wonderful","yummy","abstract","appropriate","compound","content","coordinate","deliberate",
		"duplicate","clone","interchange","miscount","perfect","predominate","exploding","swelling","rushing","relaxing","fluttering","bursting","disappearing","languorous","accelerating",
		"tentative","bounding","resurrection","accustomed","admittance","advantageous","acquaintance","algorithm","ambidextrous","anorexia","apostrophe","cartography","cellulose","agglomeration",
		"bankruptcy","characteristic","chromatography","chromosome","cinematographer","rosefish","mealtime","monarchy","propriety","fearfulness","farthermost","devoutness","agoraphobic","earthquake",
		"whisper","road","rain","alarm","dog","cat","pig","cow","blind","you","me","jog","seashell","cheerleader","shopping","fiddle","stick","cart","car","bus","walk","run","jump","see","watch",
		"country","four","five","six","sometimes","indian","might","hard","easy","between","exit","next","beginning","end","start","awake","mountain","family","lake","cave","feet","upper","lower",
		"spring","hot","tube","sexuality","whore","both","those","while","wash","dry","tango","charlie","bravo"};
	
	private string _currentWord;
	public Text txtCurrentWord;
	private System.Random _rng = new System.Random();
    private int tmrCurrentWord = 0;
	private int counter;
	private int lengthMax;
	private int lengthMin;

	[SerializeField]
	private Text displayDifficulty;


	public void Start() {
		counter = 0;
		displayDifficulty.text = "Level 1";

	}

	public void Update(){
		int tick = Environment.TickCount;
		if (tick > tmrCurrentWord) {
            GenerateNewCurrentWord();

            //level 1 and 4 and level 7
			if ((displayDifficulty.text == "Level 1") || (displayDifficulty.text == "Level 2") || (displayDifficulty.text == "Level 3"))
            {
				this.tmrCurrentWord = Environment.TickCount + 20000;
			}
            //level 2 and 5 and 8
            else if ((displayDifficulty.text == "Level 4") || (displayDifficulty.text == "Level 5") || (displayDifficulty.text == "Level 6")) {
				this.tmrCurrentWord = Environment.TickCount + 15000;
			}
            //level 3 and 6 and 9
            else
            {
				this.tmrCurrentWord = Environment.TickCount + 10000;
			}

		}
	}

    private void GenerateNewCurrentWord() {
        this._currentWord = GetWord().ToLower();
        this.txtCurrentWord.text = "Enter the word: " + this._currentWord;
        this.txtCurrentWord.color = new Color(0, 255, 0);
        this.ClearTextInput();
    }

		
	//getting the input from user and call the method compareGuess
	//to figure out if the number is correct
	public void getInput(string text) {

        // Focus on the textbox
        this.FocusTextInput();
        this.ClearTextInput();


        // Is the current guess the correct answer?
        if (this._currentWord == text.ToLower())
        {
            this.txtCurrentWord.color = new Color(0, 255, 0);
            counter++;
            
            if (counter == 10) {
				displayDifficulty.text = "Level 2";
			}
			if (counter == 20) {
				displayDifficulty.text = "Level 3";
			}
            if (counter == 30)
            {
                displayDifficulty.text = "Level 4";
            }
            if (counter == 40)
            {
                displayDifficulty.text = "Level 5";
            }
            if (counter == 50)
            {
                displayDifficulty.text = "Level 6";
            }
            if (counter == 60)
            {
                displayDifficulty.text = "Level 7";
            }
            if (counter == 70)
            {
                displayDifficulty.text = "Level 8";
            }
            if (counter == 80)
            {
                displayDifficulty.text = "Level 9";
            }
            //this.ClearTextInput();
            GameObject.FindGameObjectWithTag("Lamp Manager").GetComponent<LampManager>().UpgradeLamps();

            //resetting the timer to the previous time
            //level 1 and 4 and level 7
            if((displayDifficulty.text == "Level 1") || (displayDifficulty.text == "Level 4") || (displayDifficulty.text == "Level 7"))
            {
                this.tmrCurrentWord = Environment.TickCount + 10000;
            }
            //level 2 and 5 and 8
            else if ((displayDifficulty.text == "Level 2") || (displayDifficulty.text == "Level 5") || (displayDifficulty.text == "Level 8"))
            {
                this.tmrCurrentWord = Environment.TickCount + 7000;
            }
            //level 3 and 6 and 9
            else
            {
                this.tmrCurrentWord = Environment.TickCount + 4000;
            }


            this.GenerateNewCurrentWord();

        }
        else
        {
            this.txtCurrentWord.color = new Color(255, 0, 0);
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
        // This will generate a word
        
        //return word based on level.
        string tempWord = "";



        //for level 1 string less than 5
        if(displayDifficulty.text == "Level 1" )
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length>4);
        }

        // for level 2 between 5 words exact
        else if (displayDifficulty.text == "Level 2" )
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length != 5);
        }

        //for level 3 or level 4 6 words exact
        else if (displayDifficulty.text == "Level 3" || displayDifficulty.text == "Level 4")
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length != 6 );
        }



        //for level 5 7 words exact
        else if(displayDifficulty.text == "Level 5")
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length!=7);
        }

        //for level 6 or level 7 8 words exact
        else if (displayDifficulty.text == "Level 6" || displayDifficulty.text == "Level 7")
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length != 8);
        }


        //for level 8 9 words exact
        else if (displayDifficulty.text == "Level 8")
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length != 9);
        }

        //level 9 is more than 9 words
        else if(displayDifficulty.text == "Level 9")
        {
            do
            {
                tempWord = this._words[this._rng.Next(0, this._words.Length)];
            } while (tempWord.Length < 10);
        }

        return tempWord;
    }
}
