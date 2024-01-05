## Overview

This is used for the CRC cards for the Object-Oriented Design section of level 24.

## Purpose - Rock-Paper-Scissors
### Class - Match
#### Responsibilities
- Records player choice (Rock, Paper, or Scissors) for each player
- Returns winner, or if there was a draw
#### Collaborators
- Total class

### Class - Total
#### Responsibilities
- Records wins for each player
- Records draws
#### Collaborators
- Match class

## Purpose - 15-Puzzle
### Class - Board
#### Responsibilities
- Needs to display board
- Needs to allow board to be rearranged
- Needs to be able to detect if board has been won

#### Collaborators
- RandomInput
- PlayerStats

### Class - RandomInput
#### Responsibilities
- Needs to generate random numbers
#### Collaborators
- Board

### Class - PlayerStats
#### Responsibilities
- Needs to track how many moves have been made
- Needs to display these moves to the player
#### Collaborators
- Board

## Purpose - Hangman
### Class - Game
#### Responsibilities
- Needs to display game state to player
- Needs to allow player to pick a letter, prompting to pick again if they chose a letter that has already been picked
- Needs to update its state from the player's pick
#### Collaborators
- RandomWord
- CheckState

### Class - RandomWord
#### Responsibilities
- Needs to pick a random word from a given list of words
#### Collaborators
- Game

### Class CheckState
#### Responsibilities
- Needs to check if the player has won (all letters guessed)
- Needs to check if the player has lost (out of incorrect guesses)
#### Collaborators
- Game