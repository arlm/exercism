#!/usr/bin/env zsh

set -ex

sudo apk add erlang erlang-dev erlang-dialyzer rust cargo

git clone --branch v0.34.1 --depth 1 https://github.com/gleam-lang/gleam.git gleam
cd gleam
make install
cd -

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git "${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}"/themes/powerlevel10k
source "$HOME/.zshrc"
omz theme set powerlevel10k/powerlevel10k
