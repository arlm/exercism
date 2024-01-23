#!/usr/bin/env zsh

set -ex

wget -O /home/vscode/Mars4_5.jar --progress=bar https://courses.missouristate.edu/kenvollmar/mars/MARS_4_5_Aug2014/Mars4_5.jar

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

set +ex
source "$HOME/.zshrc"
set -ex

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

omz theme set powerlevel10k/powerlevel10k
