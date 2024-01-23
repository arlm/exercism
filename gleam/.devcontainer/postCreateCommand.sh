#!/usr/bin/env zsh

set -ex

sudo apk add elixir erlang erlang-dev erlang-dialyzer rust cargo

git clone --branch v0.34.1 --depth 1 https://github.com/gleam-lang/gleam.git gleam
cd gleam
make install
cd -

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git "${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}"/themes/powerlevel10k

set +ex
source "$HOME/.zshrc"
set -ex

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

omz theme set powerlevel10k/powerlevel10k
