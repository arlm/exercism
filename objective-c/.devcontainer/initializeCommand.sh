#!/usr/bin/env bash

if [ -e "$HOME/.ssh/id_rsa" ]; then
	ssh-add "$HOME/.ssh/id_rsa"
fi

if [ -e "$HOME/.ssh/github_rsa" ]; then
	ssh-add "$HOME/.ssh/github_rsa"
fi

if [ -e "$HOME/.ssh/arlm-GitHub" ]; then
	ssh-add "$HOME/.ssh/arlm-GitHub"
fi

if [ -e "$HOME/.ssh/arlm-GitLab" ]; then
	ssh-add "$HOME/.ssh/arlm-GitLab"
fi
