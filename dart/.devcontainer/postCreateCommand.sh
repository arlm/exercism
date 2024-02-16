#!/usr/bin/env zsh

set -ex

wget -qO- https://dl-ssl.google.com/linux/linux_signing_key.pub | sudo gpg --dearmor -o /usr/share/keyrings/dart.gpg
echo 'deb [signed-by=/usr/share/keyrings/dart.gpg arch=amd64] https://storage.googleapis.com/download.dartlang.org/linux/debian stable main' | sudo tee /etc/apt/sources.list.d/dart_stable.list
apt update
apt install dart -y

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git "${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k"

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

# To customize prompt, run $(p10k configure) or edit ~/.p10k.zsh.
[[ ! -f ~/.p10k.zsh ]] || source ~/.p10k.zsh"

EOF >>"$HOME/.zshrc-tmp"

cp  "$HOME/.zshrc-tmp" "$HOME/.zshrc"
rm "$HOME/.zshrc-tmp"

source "$HOME/.zshrc"
set -ex

omz theme set powerlevel10k/powerlevel10k
