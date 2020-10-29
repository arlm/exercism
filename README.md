# exercism
http://exercism.io/ practice

# How to use

1. Install the exercism CLI client as described on the website
2. Copy the file `exercism_completion.bash` to `~/.config/exercism/exercism_completion.bash `
3. Add these lines to the `.bash_profile` on your home directory:

```bash
if [ -f ~/.config/exercism/exercism_completion.bash ]; then
  source ~/.config/exercism/exercism_completion.bash
fi
```

To activate the auto-completion on the same terminal type:
* `source ~/.config/exercism/exercism_completion.bash`