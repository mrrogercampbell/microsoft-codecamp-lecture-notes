# Chapter 2: Introduction to Bash



## Walkthrough: Navigating The File System With Bash

## Walkthrough: Substitutions & Scripting in Bash
### Variable Substitution
* Give students context that they are creating an actual file that can be ran in the terminal as a script
  * Reference back to earlier notes where I take about what a script is and how it functions
  * Let students know they can use a text editor such as `VS Code`, `Visual Studio`, and or any other editor they have used in the past
* The file they will be creating should be called: `~/bash-examples/variable-substitution.sh`
```sh
target_path=/tmp/dir-name

# ~ is a shorthand for /home/<username>
destination_path=~/dir-name

# mkdir /tmp/dirname
mkdir "$target_path"

# mv /tmp/dir-name ~/dir-name
mv "$target_path" "$destination_path"

# $HOME is an environment variable with a value of /home/<username>
# ls /home/<username>
ls "$HOME"
```
* Once the file is created save it and run it with the following command:
```sh
$ bash ~/bash-examples/variable-substitution.sh
```
* For more context provide link to how script work and what the `bash` command actually does