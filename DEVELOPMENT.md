# Developing for Realm.Extensions

## Basic setup

_TODO_

## Automatic change log generation

[CHANGELOG.md](https://github.com/Didstopia/Realm.Extensions/blob/master/CHANGELOG.md) is generated automatically when you run the `.scripts/gen_changelog.sh` script.

When developing, this can be triggered automatically by using a `post-commit` hook in your local git repository.

To do so, create a new file at `.git/hooks/post-commit` with the following contents:
```
#!/bin/bash
set -e
set -o pipefail
cd "${0%/*}/../../"
./.scripts/gen_changelog.sh
```
Note: Remember to run `chmod +x .git/hooks/post-commit` to make it executable.