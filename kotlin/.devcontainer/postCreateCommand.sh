#!/usr/bin/env zsh

set -ex

git clone --depth=1 https://github.com/romkatv/powerlevel10k.git ${ZSH_CUSTOM:-$HOME/.oh-my-zsh/custom}/themes/powerlevel10k

sdk install java 11.0.22-tem
sdk default java 21.0.2-tem

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

curl https://rakubrew.org/install-on-perl.sh | sh
echo 'eval "$(/home/vscode/.rakubrew/bin/rakubrew init Zsh)"' > "$HOME/.zshenv"
rakubrew build-zef

git clone https://github.com/ugexe/zef.git
cd zef
raku -I. bin/zef install .
cd -

echo 'export PATH=$PATH:$HOME/zef/bin' >> "$HOME/.zshrc"

ballerina dist upgrade
ballerina update

curl -O https://download.clojure.org/install/linux-install-1.11.1.1347.sh
chmod +x linux-install-1.11.1.1347.sh
sudo ./linux-install-1.11.1.1347.sh

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
