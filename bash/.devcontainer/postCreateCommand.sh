#!/usr/bin/env bash

set -ex

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git "${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}"/themes/powerlevel10k
omz theme set powerlevel10k/powerlevel10k
