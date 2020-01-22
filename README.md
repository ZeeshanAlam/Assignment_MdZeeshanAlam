# Md-Zeeshan-Alam
video link
https://cl.ly/03eaf0cdf6db

game_dev_challenge

Main scene script just contains code for changing scene when button is pressed and highscore is displayed using playerprefs.
Player Manager deals with the collision of snake with food or wall. If its wall it calls a method in gamemanager and says gameover, and if its food new food is spawned randomly by calling a method in gamemanager.
When game start gamemanager calls awake function first which sets the properties of food by reading txt file.
In txt file property can be defined as "Color Point" format. Food is spawn randomly on the map also onscore method is called which increments the score and multiply it by number of streak. Food is identified by its index on list so whenever same index food is eaten streak is incremented by 1 otherwise 0.
For player movement arrow keys are used, when a button is pressed player direction will be changed, also if moving forwrd snake can't go suddenly backward so booleans horizontal and vertical are used. Movement is incremented by a step at a defined frequency using update method.
I haven't focused much on graphics, I can do if necessary. Also any feedback is appreciated.

Thanks
Zeeshan

