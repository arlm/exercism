#!/usr/bin/env bash

set -ex

luarocks install --local busted
echo -n 'export PATH=$HOME/.luarocks/bin:$PATH' >> ~/.zshrc
git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k
omz theme set powerlevel10k/powerlevel10k
