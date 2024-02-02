#!/usr/bin/env zsh

set -ex

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

set +ex
source "$HOME/.zshrc"
set -ex

mkdir -p "$HOME/.config/exercism"
cp "/home/vscode/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

set +ex
cat << EOF
# Enable Powerlevel10k instant prompt. Should stay close to the top of ~/.zshrc.'
# Initialization code that may require console input (password prompts, [y/n]
# confirmations, etc.) must go above this block; everything else may go below.
if [[ -r "${XDG_CACHE_HOME:-$HOME/.cache}/p10k-instant-prompt-${(%):-%n}.zsh" ]]; then
  source "${XDG_CACHE_HOME:-$HOME/.cache}/p10k-instant-prompt-${(%):-%n}.zsh"
fi

EOF >"$HOME/.zshrc-tmp"

cat "$HOME/.zshrc" >> "$HOME/.zshrc-tmp"

cat << EOF

# pnpm
export PNPM_HOME="/home/node/.local/share/pnpm"
case ":$PATH:" in
  *":$PNPM_HOME:"*) ;;
  *) export PATH="$PNPM_HOME:$PATH" ;;
esac
# pnpm end

# To customize prompt, run $(p10k configure) or edit ~/.p10k.zsh.
[[ ! -f ~/.p10k.zsh ]] || source ~/.p10k.zsh"

EOF >>"$HOME/.zshrc-tmp"

cp  "$HOME/.zshrc-tmp" "$HOME/.zshrc"
rm "$HOME/.zshrc-tmp"

source "$HOME/.zshrc"
set -ex

nvm install stable
nvm install lts/hydrogen

npm install -g npm@latest
npm remove yarn -g

pnpm setup
pnpm add -g pnpm
pnpm add coffee-script -g
pnpm add jasmine-node -g

omz theme set powerlevel10k/powerlevel10k
