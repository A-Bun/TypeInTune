/******************************************************************************
 * Author: Alexis Peoples
 * Major: Computer Science: Software Development
 * Due Date: May 6, 2021
 * Course: CSC385-010
 * Professor Name: Dr. Schwesinger
 * Assignment: Semester Project
 * Filename: README.md
******************************************************************************/

# Specification
	"Type In Tune" is a 2D typing game about a newly hired pianist at a bar.
		You play as the pianist and type out letters to play beautiful music for the bar 
		patrons and reveal the story behind your character.
	
	** Data Structures **
		I mainly use Lists for everything in the game.
			- Each letter is composed of a list of strings for the sentences and a list
				of booleans that mark each corresponding sentence as (in)complete.
			- Each dialogue is composed of a list of strings for the sentences as well.
			- Each song uses a list of ints that holds the payment you get for the song
				based on the number of mistakes you made. Each song also uses a list of ints
				to hold the number of mistakes you must make to cause your payment to
				decrease.
			- Player data, such as the songs you currently own and the dialogues/letters you
				have completed so far, is also stored in lists which are saved/loaded/used in
				multiple places through the game.
		
	** Development Platform **
		Unity Version 2020.2.0f1 (2D Project)
		
	** Deployment Platform **
		Itch.io

# Configuration instructions
	The game works/looks the best when the resolution is set to 1920 by 1080. I apologize for
		the lack of flexibity in resolutions, but in the essence of time, I chose to focus on
		actually having a finished and functional product.

# Installation instructions
	*(Once the game is deployed)*
	1) Go to https://abun.itch.io/type-in-tune.
	2) Click download for the TypeInTune.zip file. 
	3) Once it is finished downloading, extract the files from the zip file to wherever you'd
		like to put the game.
	4) After the extraction finishes, the game will be completely ready to play.

# Operating instructions
	1) Run the TypeInTune.exe application file to start the game.

# Known bugs
	1) When the game's resolution is changed from 1920 by 1080, the text doesn't scale 
		properly, which makes the game partly unplayable. (The game runs fine when using 
		1920 by 1080 tho!)
	2) The art for the your character is not implemented into the game, so he is just a white 
		square.
		2a) You are not told to walk across the scene after the tutorial ends and your 
			character reappears at the bar scene (as the white square). 
			(You can move your character by using the "A" and "D" keys.)
	3) Once you finish the game you can still press the continue button on the main menu,
		even though you shouldn't be able to. Continuing after beating the game just makes
		you see The End text scene again and then sends you back to the main menu.
	4) The shop does not do anything past the tutorial. You can still check it to see how
		much money you have, but the money doesn't really matter (since you can't buy
		anything).
	5) For some reason, the first song's information (if you played it) in the songbook 
		doesn't update when you first open the songbook. For it to update, you either have 
		to go to the next page and go back, or exit the songbook and reopen it.

# Credits and Acknowledgements
	1) HUGE thanks to Rabidgremlin on Youtube! He helped me solve some of my resolution
		issues that I have had since I worked on JCIT at the beginning of senior sem in 
		sem in Spring 2020. The LetterBox was a quick and pretty fix.
		Here's the video: https://www.youtube.com/watch?v=hXU-ZJb6GHw&ab_channel=Rabidgremlin
	2) As always thanks to Brackeys on Youtube for the helpful tutorials and
		scripts.
	3) Thanks to https://freemusicarchive.org for some of the piano music I used for the game.
		Link to their license: https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode
	4) Thanks to Kyle Suchar on Youtube for showing me how to do 2D player movement. Here's the
		video: https://www.youtube.com/watch?v=L6Q6VHueWnU&ab_channel=KyleSuchar
	5) Thanks to user "Addyarb" from Unity Answers for teaching me how to run a function as soon
		as a scene loads. Here is a link to their answer: https://answers.unity.com/questions/1174255/since-onlevelwasloaded-is-deprecated-in-540b15-wha.html
	6) Thanks to https://www.onlinepianist.com/virtual-piano for the virtual piano. I used it to
		make the Twinkle Twinkle Little Star song.

# Changelog
2021-05-05		Alexis Peoples		<alexisp30ples@gmail.com>
 * Now multiple letters (3, to be exact) can be typed per day (except during the tutorial/training day).
 * All the letters have been added to the game.
 * Now twinkle twinkle little star is a tutorial only song (since it is so short).
 * An ending is now in the game. (  no spoilers (: )

2021-05-04		Alexis Peoples		<alexisp30ples@gmail.com>
 * Almost finished the bar art for the intro/bar scene.
	* The bar shelves are filled with bottles and glasses.
	* There is a painting on the wall now, and the beginning of another painting.
	* The floor is now completed.

2021-04-24		Alexis Peoples		<alexisp30ples@gmail.com>
* The boss art is now complete and in the game (goodbye white placeholder box)!
* The boss now fades away when he leaves in the tutorial.

2021-04-23		Alexis Peoples		<alexisp30ples@gmail.com>
* Updated the save/load system so that all the currently owned songs, all the completed dialogues, and all the completed letters can be saved and loaded.
* When a new game is started, all player progress is reset, including all songs' owned status and stats; all dialogues and letters are set to incomplete as well.
* Restyled main menu with simple animations and new buttons (Load and Settings).
* Game saves between scenes, when the player quits through the pause menu, or when the player saves through the pause menu.
* The option to load from the pause menu has been removed since the game saves between scenes. It was a pointless option.

2021-04-22		Alexis Peoples		<alexisp30ples@gmail.com>
* Added scene that wraps up each day after the player clocks out.
	* The day you're currently on is displayed and marked as completed.
	* The amount of money you earned for the day is displayed.
	* The amount of money you've earned in total ia displayed.
	* Once every amount is displayed, a "click anywhere to continue" message appears.
		* When you click, the next day of work begins.

2021-04-21		Alexis Peoples		<alexisp30ples@gmail.com>
* Implemented a bare-boned save/load system.

2021-04-20		Alexis Peoples		<alexisp30ples@gmail.com>
* The player now shows up in the bar scene after the intro is completed.
* When the player reaches the piano (when walking in the bar scene), the scene transitions to the "at piano" scene automatically.
* If the tutorial is complete, each letter that appears when the laptop is clicked has a random song attached to it.
	* If the tutorial isn't complete, the tutorial letter appears when the laptop is clicked and has the tutorial song ("Twinkle Twinkle Little Star") attached to it.

2021-04-13		Alexis Peoples		<alexisp30ples@gmail.com>
* I finished more of the boss' artwork.

2021-04-09		Alexis Peoples		<alexisp30ples@gmail.com>
* Added a quit button to the main menu screen (duh).
* I did a quick fix (hardcoding values) for the textbox repositioning for the tutorial so it'd be ready in time. I plan to go back and figure out a better way after today.
* Added audio I made for the song "twinkle twinkle little star." This song is used in the tutorial letter.
* Added a clock out button to end the tutorial and transition to the more to come scene.
* Finished the prototype.

2021-04-07		Alexis Peoples		<alexisp30ples@gmail.com>
* A "More to Come" scene has been added to the game for the prototype.

2021-04-06		Alexis Peoples		<alexisp30ples@gmail.com>
* The pause menu and its animations are now in the game, however certain buttons (Save, Load, and Settings) have no functionality yet.
* The tutorial is complete (apart from some textbox repositioning that needs to be done).

2021-03-30		Alexis Peoples		<alexisp30ples@gmail.com>
* 3/4 of the tutorial is now complete.
	* Now, the songbook part and the shop part of the tutorial are done.
	* All that's left to connect to the tutorial is the explanation of the letter typing.
* The boss art is coming together nicely so far. I'm not the best artist, so it is challenging but also worth it.

2021-03-29		Alexis Peoples		<alexisp30ples@gmail.com>
* The tutorial is halfway complete.
	* If the tutorial was not played when the "at piano" scene starts, the tutorial begins.
	* The boss' dialogue appears and red boxes appear around what the player should click on next as he talks.
	* Red boxes appear around some objects (that the player should pay attention to) that the boss refers to in his dialogue.
	* Buttons that shouldn't be pressed during certain times in the tutorial are disabled.
	* So far only the songbook part of the tutorial is done.

2021-03-20		Alexis Peoples		<alexisp30ples@gmail.com>
* The intro to the game is complete (except the image for the boss isn't in yet). The intro includes:
	* Opening dialogue with the boss on a black screen; when the dialogue ends, the boss fades away.
	* After the complete black screen, a flickering light animation plays, which unviels the bar for the first time.
	* After the bar is visible for a few seconds, the boss appears again and completes his intro dialogue.
	* Once the boss is finished his dialogue, the scene changes to the "at piano" scene (where the tutorial will start).
* Added some of the tutorial dialogue to the game.
* If the next sentence button is pressed before the dialogue is finished animating, the full sentence is displayed and the player must press the next button again to go to the next sentence.

2021-03-17		Alexis Peoples		<alexisp30ples@gmail.com>
* Implemented fade in/out for scenes.
* Added Bar scene (skeleton).
* Added dialogue system (skeleton).
* Added player movement and collision for bar scene (skeleton).

2021-03-16		Alexis Peoples		<alexisp30ples@gmail.com>
* Wrote most/all of the letters out for the story.
* Completed more of the bar background art.
* Added the (unfinished) scene transition to the game.
Note: Not much was updated this week due to the 4 exams, 1 project, and 2 papers I had to do.
	  I'll do much more in the next progress report.

2021-03-03		Alexis Peoples		<alexisp30ples@gmail.com>
* The songbook's play, pause, stop, and restart buttons now have images signifying which is which.
* The shop layout has been established in game, however, it doesn't have full functionality yet.
* The Player object was created to hold information about the player, which is only the current amount of money so far.
* The player's current amount of money can be incremented, decremented, and outputted.
* The songs in the shop can be "bought," (meaning a debug message pops up) and the player's money will be updated.
* The songbook has been updated to only show songs that the player owns (excludes the ones not yet bought from the shop).

2021-02-26		Alexis Peoples		<alexisp30ples@gmail.com>
* When pressed, the songbook button now pulls up an expanded image of the songbook, which displays each song the player currently has unlocked as well as each song's info.
* The songbook can play, pause, stop, and restart each song within it.
* When a letter is being typed, all characters that have already been typed are displayed in green, the next character to be typed is displayed in red, and all other characters not yet typed are displayed in black.

2021-02-23		Alexis Peoples		<alexisp30ples@gmail.com>
* I created and pushed the PROGRESSLOG, TODO, and README files to the repository.
* Overall explanation of what’s been done so far:
   * I have made a Letter object, a Song object, and their respective handlers. The handlers have functions that return the title/name, the (in)complete status, etc.
   * A letter (all of the sentences) can appear and as you type the characters out correctly, they turn from black to green.
   * A song can be attached to each letter.
   * Each letter can be given its own paper sprite (which changes the appearance of the paper that the sentences appear on).
   * When a sentence is completed (sentence is a misnomer because in the letters, a sentence is actually a sentence fragment), the letter’s connected song plays for a predetermined amount of time. You can’t continue typing until the song pauses again. Every time a sentence is completed, the song plays from the time it last stopped at.
   * If you mistype a character in the letter, a “WRONG!” image appears on screen and doesn’t go away until you type the correct character and the number of mistakes you made in the letter is incremented.
   * Each song can be given a cost (the price to buy it from the shop). Each song has a salary (the amount of money to be paid to you when you play the song). The salary of each song can be incrementally decreased based on a predetermined number of mistakes.
   * The more mistakes you make when typing the letter, the less money you get for playing the connected song.
   * Once the letter is set to complete (meaning all sentences have been typed/completed), the song plays from its current position until it ends.
   * The early layout and basic functionality of the “sitting at the piano” scene is done.
   * Part of the script for the intro and the tutorial is written.
   * Part of the art for the intro scene is completed.
   * Multiple purchasable cosmetics are completed (ex. different themed piano keys).
   * A few other things I can’t fit here.