#!/usr/bin/env bash

if [ -e "~/.ssh/id_rsa" ]; then
    ssh-add ~/.ssh/id_rsa
fi

if [ -e "~/.ssh/github_rsa" ]; then
    ssh-add ~/.ssh/github_rsa
fi

if [ -e "~/.ssh/arlm-GitHub" ]; then
    ssh-add ~/.ssh/arlm-GitHub
fi

if [ -e "~/.ssh/arlm-GitLab" ]; then
    ssh-add ~/.ssh/arlm-GitLab
fi
