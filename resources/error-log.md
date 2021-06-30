# Error Log
This document is a repo of common errors we have encountered during the course. You can you it to help you debug.

* Error: `Git - fatal: Unable to create '/path/my_project/.git/index.lock': File exists`
  * Fix: `rm -f ./.git/index.lock`
  * [Fix Source](https://stackoverflow.com/questions/7860751/git-fatal-unable-to-create-path-my-project-git-index-lock-file-exists)