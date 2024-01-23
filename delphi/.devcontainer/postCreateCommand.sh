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

set +ex
source "$HOME/.zshrc"
set -ex

mkdir -p "$HOME/.config/exercism"
cp "$HOME/.exercism-config/user.json" "$HOME/.config/exercism/user.json"
exercism configure -w /workspaces/exercism

omz theme set powerlevel10k/powerlevel10k
