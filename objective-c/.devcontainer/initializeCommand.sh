#!/usr/bin/env bash

if [ ! -e "~/.ssh/github_rsa" ]
then
ssh-add ~/.ssh/github_rsa
fi

if [ ! -e "~/.ssh/arlm-GitHub" ]
then
ssh-add ~/.ssh/arlm-GitHub
fi
