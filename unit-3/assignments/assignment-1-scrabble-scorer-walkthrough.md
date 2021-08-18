# Assignment 1 Walkthrough: Scrabble Scorer
- [Assignment 1 Walkthrough: Scrabble Scorer](#assignment-1-walkthrough-scrabble-scorer)
  - [Part A: Initial Prompt](#part-a-initial-prompt)
  - [Part B: Add and Organize Scoring Algorithms](#part-b-add-and-organize-scoring-algorithms)
  - [Part C: Transform Scrabble Scoring](#part-c-transform-scrabble-scoring)
    - [Transform the Object](#transform-the-object)
  - [Solution: Before Bonus](#solution-before-bonus)
  - [Part D: Bonus Missions](#part-d-bonus-missions)

## Part A: Initial Prompt
1. Modify the provided initial_prompt() function to prompt the user to enter a word to score. The function should return the text inputted by the user.
```python
def initial_prompt():
    print("Let's play some Scrabble!\n")
    print("Enter a word to score: ")
    user_input = input()

    return user_input
```

2. Use the `old_scrabble_scorer()` function provided to score the word provided by the user. To do this, invoke `old_scrabble_scorer()` inside of the final function in the file, run_program(). `old_scrabble_scorer()` will take the return value of initial_prompt(). Print the result.
```python
def run_program():
    word = initial_prompt()

    older_score = old_scrabble_scorer(word)

    print(older_score)
# Outputs:
```
* **Gotchas**:
  * I did have to change the name of `OLD_POINT_STRUCTURE` to `old_point_structure` so that it matched the variable being called in the `old_scrabble_scorer()`
  * I also changed the `letterPoints` variable to only store the actual score for the `old_scrabble_scorer()`
    * This is how my `old_scrabble_scorer()` looks:
```python
def old_scrabble_scorer(word):
    word = word.upper()
    letterPoints = 0

    for char in word:

        for point_value in old_point_structure:

            if char in old_point_structure[point_value]:
                letterPoints += point_value

    return letterPoints
```
  *  I just removed the strings they were appending to the variable `lettersPoints` because it was giving way more data that was needed and didn't fit in with the other two scoring algorithms

## Part B: Add and Organize Scoring Algorithms
Your job here is to write two other scoring algorithms for the Scrabble player.
* **Note**: Make each scoring algorithm case insensitive, meaning that they should all ignore case when assigning points.

1. `simple_scorer`: Define a function that takes a word as a parameter and returns a numerical score. Each letter within the word is worth 1 point.
```python
def simple_scorer(word):
    score = 0
    for letter in word.lower():
        score += 1

    return score

simple_score = simple_scorer('wizard')

print(simple_score)
# Outputs:
# 6
```

2. `vowel_bonus_scorer`: Define a function that takes a word as a parameter and returns a score. Each vowel within the word is worth 3 points, and each consonant is worth 1 point.
```python
def vowel_bonus_scorer(word):
    vowels = 'aeiou'
    score = 0

    for letter in word.lower():
        point = 3 if letter in vowels else 1
        score += point

    return score

vowel_score = vowel_bonus_scorer('wizard')

print(vowel_score)

# Outputs:
# 10
```

3. Once you’ve written these scoring functions, organize all three of the scoring options into a tuple called scoring_algorithms. Your program will use this tuple to retrieve information about the three scoring algorithms and convey that information to the user.
```python
scoring_algorithms = (old_scrabble_scorer, simple_scorer, vowel_bonus_scorer)
# Outputs:
```
   * I placed this above the `def run_program()`

4. Finish writing the `scoring_algorithms` tuple. It should be populated with three dictionary objects, one for each of the three scoring options. Each dictionary should contain three keys: `name`, `description`, and `scoring_function`.

5. Examine the table for the information to store in `name` and `description`. The `scoring_function` for each object should be the name of one of the three scoring algorithms already defined.
```python
old_scrabble_scorer_dict = {
    'name': 'Scrabble',
    'description': 'The traditional scoring algorithm.',
    'score_function': old_scrabble_scorer
}
simple_scorer_dict = {
    'name': 'Simple Score',
    'description': 'Each letter is worth 1 point. A function with a parameter for user input that returns a score.',
    'score_function': simple_scorer
}
vowel_bonus_scorer_dict = {
    'name': 'Bonus Vowels',
    'description': 'Vowels are 3 pts, consonants are 1 pt.',
    'score_function': vowel_bonus_scorer
}

scoring_algorithms = (
    old_scrabble_scorer_dict,
    simple_scorer_dict,
    vowel_bonus_scorer_dict
)
```
6. Finish writing `scorer_prompt()` so that the user can select which scoring algorithm to use when the program scores their word. Use the selected algorithm to determine the score for the word:
   1. If the user enters `0`, have the program output a score using the simple scorer.
   2. If the user enters `1`, use the vowel bonus scoring function.
   3. If the user enters `2`, use the Scrabble scoring option.
   4. `scorer_prompt()` should return the whole dictionary object the user has selected.
```python
def scorer_prompt():
    score_prompt = 'Which scoring algorithm would you like to use?'

    for index, algorithm in enumerate(scoring_algorithms):
         print(f'{index} - {algorithm["name"]}: {algorithm["description"]}')

         user_selection = int(input('Enter 0, 1, or 2:'))

    selected_score_algorithm_dict = scoring_algorithms[user_selection]

    return selected_score_algorithm_dict
```
7. Inside of `run_program()`, remove the `old_scrabble_scorer()` call. Replace it with a call to `scorer_prompt()` so that the program asks the user for a scoring algorithm after prompting for a word. Use the scoring object returned from `scorer_prompt()` to score the user’s word and let the user know what score their word receives.
```python
def run_program():
    word = initial_prompt()

    selected_score_algorithm_dict = scorer_prompt()

    score = selected_score_algorithm_dict['score_function'](word)

    print(
        f'''
The word you entered was "{word}".
You selected the "{selected_score_algorithm_dict["name"]}" scoring algorithm which {selected_score_algorithm_dict["description"]}.
Your word is worth {score} points!'''
    )
```
## Part C: Transform Scrabble Scoring
### Transform the Object
1. Write the rest of the `transform()` function. It will need to take a dictionary object as a parameter - specifically the `OLD_POINT_STRUCTURE` object. Calling `transform(OLD_POINT_STRUCTURE)` will return a dictionary with _lowercase_ letters as keys. The value for each key will be the points assigned to that letter.
```python
def transform(provided_dict):
    new_dict = {}

    for (key, value) in provided_dict.items():
        for letter in value:
            new_dict[letter.lower()] = key

    return new_dict
```
2. Create a new variable called `new_point_structure` underneath your `transform()` function. Assign the value of new_point_structure to be the result `transform(OLD_POINT_STRUCTURE).`
```python
new_point_structure = transform(old_point_structure)
```
3. Once you’ve defined `new_point_structure`, use it to finish writing the `scrabble_scorer()` function and then replace the `old_scrabble_scorer()` function in `scoring_algorithms` with this new function.
```python
def scrabble_scorer(word):
    score = 0

    for letter in word:
        if letter in new_point_structure:
            score += new_point_structure[letter]

    return score
```

## Solution: Before Bonus
```python
# scrabble_scorer.py

old_point_structure = {
    1: ['A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'],
    2: ['D', 'G'],
    3: ['B', 'C', 'M', 'P'],
    4: ['F', 'H', 'V', 'W', 'Y'],
    5: ['K'],
    8: ['J', 'X'],
    10: ['Q', 'Z']
}


def old_scrabble_scorer(word):
    word = word.upper()
    letterPoints = 0

    for char in word:

        for point_value in old_point_structure:

            if char in old_point_structure[point_value]:
                letterPoints += point_value

    return letterPoints

def initial_prompt():
    print("Let's play some Scrabble!\n")
    user_input = input("Enter a word to score: ")

    return user_input


def simple_scorer(word):
    score = 0
    for letter in word.lower():
        score += 1

    return score


def vowel_bonus_scorer(word):
    vowels = 'aeiou'
    score = 0

    for letter in word.lower():
        point = 3 if letter in vowels else 1
        score += point

    return score


def scrabble_scorer(word):
    score = 0

    for letter in word.lower():
        if letter in new_point_structure:
            score += new_point_structure[letter]

    return score


scoring_algorithms = ()


def scorer_prompt():
    score_prompt = 'Which scoring algorithm would you like to use?'
    user_selection = 3

    while user_selection > 2:
        for index, algorithm in enumerate(scoring_algorithms):
            print(f'{index} - {algorithm["name"]}: {algorithm["description"]}')

        user_selection = int(input('Enter 0, 1, or 2:'))

    selected_score_algorithm_dict = scoring_algorithms[user_selection]

    return selected_score_algorithm_dict


def transform(provided_dict):
    new_dict = {}

    for (key, value) in provided_dict.items():
        for letter in value:
            new_dict[letter.lower()] = key

    return new_dict


new_point_structure = transform(old_point_structure)

simple_scorer_dict = {
    'name': 'Simple',
    'description': 'scores each letter provided is worth 1 point.',
    'score_function': simple_scorer


}

vowel_bonus_scorer_dict = {
    'name': 'Bonus Vowels',
    'description': 'gives 3 point per vowels and 1 point per consonants',
    'score_function': vowel_bonus_scorer
}

old_scrabble_scorer_dict = {
    'name': 'Scrabble',
    'description': 'uses the original Scrabble game point system',
    'score_function': scrabble_scorer
}


scoring_algorithms = (
    simple_scorer_dict,
    vowel_bonus_scorer_dict,
    old_scrabble_scorer_dict
)


def run_program():
    word = initial_prompt()

    selected_score_algorithm_dict = scorer_prompt()

    score = selected_score_algorithm_dict['score_function'](word)

    print(
        f'''
The word you entered was "{word}".
You selected the "{selected_score_algorithm_dict["name"]}" scoring algorithm which {selected_score_algorithm_dict["description"]}.
Your word is worth {score} points!'''
    )


run_program()

# Outputs:
```

## Part D: Bonus Missions
1. Currently, the prompts accept ANY input values. The user could enter something other than 0, 1, or 2 when selecting the scoring algorithm, and they could enter numbers or symbols when asked for a word. Modify your code to reject invalid inputs and then re-prompt the user for the correct information.
```python
def scorer_prompt():
    score_prompt = 'Which scoring algorithm would you like to use?'
    user_selection = 3

    while user_selection > 2:
        for index, algorithm in enumerate(scoring_algorithms):
            print(f'{index} - {algorithm["name"]}: {algorithm["description"]}')

        user_selection = int(input('Enter 0, 1, or 2:'))

    selected_score_algorithm_dict = scoring_algorithms[user_selection]

    return selected_score_algorithm_dict
```
2. Score words spelled with blank tiles by adding `' '` to the `new_point_structure` dictionary. The point value for a blank tile is `0`.
```python
def transform(provided_dict):
    new_dict = {}

    new_dict["' '"] = 0

    for (key, value) in provided_dict.items():
        for letter in value:
            new_dict[letter.lower()] = key

    return new_dict
```