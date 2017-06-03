# Developing for Realm.Extensions

## Basic Setup

_Todo_

## Changelog Generation

[CHANGELOG.md](https://github.com/Didstopia/Realm.Extensions/blob/master/CHANGELOG.md) is generated automatically by the [scripts/gen_changelog.sh] (https://github.com/Didstopia/Realm.Extensions/blob/master/scripts/gen_changelog.sh)script.

When developing, this can be triggered automatically by using a `post-commit` hook in your local git repository. To do so, simply run the following command at the root of the git repository:
```
ln -s scripts/gen_changelog.sh .git/hooks/post-commit
```