#!/usr/bin/env zsh

set -ex

wget -O fpc-3.0.4.x86_64-linux.tar --progress=bar https://sourceforge.net/projects/freepascal/files/Linux/3.0.4/fpc-3.0.4.x86_64-linux.tar/download
tar -xvf fpc-3.0.4.x86_64-linux.tar
cd fpc-3.0.4.x86_64-linux
echo "choose /home/vscode as the prefix …"
./install.sh
cd -

git clone https://gitlab.com/freepascal.org/fpc/source --tag 3.3.1 fpc-3.3.1-source
cd fpc-3.3.1-source

make clean PP=/home/vscode/fpc-3.0.4/bin/fpc
make all PP=/home/vscode/fpc-3.0.4/bin/fpc
make install INSTALL_PREFIX=/usr/local
cd -

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
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
