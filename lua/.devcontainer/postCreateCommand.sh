#!/usr/bin/env bash

set -ex

luarocks install --local busted
echo -n 'export PATH=$HOME/.luarocks/bin:$PATH' >>~/.zshrc

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

set +ex
source "$HOME/.zshrc"
set -ex

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

omz theme set powerlevel10k/powerlevel10k
