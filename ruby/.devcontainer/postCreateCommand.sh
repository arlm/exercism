#!/usr/bin/env zsh

set -ex

gem install minitest rubocop debug

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k
omz theme set powerlevel10k/powerlevel10k
