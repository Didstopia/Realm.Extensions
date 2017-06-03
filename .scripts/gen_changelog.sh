#!/bin/bash

# Enable strict error handling
set -e
set -o pipefail

# Switch working directory to the script location
cd "${0%/*}"

# Dependency validation
if [[ -z "${CHANGELOG_GITHUB_TOKEN}" ]]; then
	echo "FATAL: GitHub token not found, please generate a token using the instructions here:"
	echo "https://github.com/skywinder/github-changelog-generator#github-token"
	exit 1
fi
if ! gem -v > /dev/null 2>&1; then
	echo "FATAL: Ruby or RubyGems not found, please make sure both are installed."
	exit 1
fi
if ! gem spec github_changelog_generator > /dev/null 2>&1; then
	echo "Installing missing dependencies.."
	echo|gem install -q github_changelog_generator > /dev/null
fi

# Switch working directory to the root
cd ../

# Generate the changelog
echo "Generating CHANGELOG.md.."
github_changelog_generator > /dev/null

# Remove the last line (optional attribution)
sed -i '' -e '$ d' CHANGELOG.md

# Commit the changelog if it changed
if [[ $(git status --porcelain | grep CHANGELOG.md | wc -l) -gt 0 ]]; then
	echo "Committing modified CHANGELOG.md.."
	git add CHANGELOG.md
	git commit --amend
else
	echo "No changes in CHANGELOG.md, skipping commit.."
fi

# Clean exit
exit 0