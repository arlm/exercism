_exercism () {
  local cur prev

  COMPREPLY=()   # Array variable storing the possible completions.
  cur=${COMP_WORDS[COMP_CWORD]}
  prev=${COMP_WORDS[COMP_CWORD-1]}

  commands="configure debug download open
  prepare submit troubleshoot upgrade version workspace help"

  tracks="csharp cpp clojure coffeescript lisp crystal
  dlang ecmascript elixir elm elisp erlang
  fsharp go haskell java javascript kotlin
  lfe lua mips ocaml objective-c php
  plsql perl5 python racket ruby rust scala
  scheme swift typescript bash c ceylon
  coldfusion delphi factor groovy haxe
  idris julia nim perl6 pony prolog
  purescript r sml vbnet powershell"

  version_opts="--latest"
  troubleshoot_opts="--full-api-key"
  download_opts="--exercise --team --track --uuid"
  config_opts="--api --no-verify --show --token --workspace"
  submit_opts="--test --comment"
  global_opts="--help --unmask-token --verbose --timeout"

  if [ "${#COMP_WORDS[@]}" -eq 2 ]; then
    COMPREPLY=( $( compgen -W  "${commands}" "${cur}" ) )
    return 0
  fi

  if [ "${#COMP_WORDS[@]}" -ge 3 ]; then
    prev=${COMP_WORDS[1]}
    case "${prev}" in
      configure)
        COMPREPLY=( $( compgen -W "${config_opts}" -- "${cur}" ) )
        return 0
        ;;
      fetch)
        COMPREPLY=( $( compgen -W "${tracks}" "${cur}" ) )
        return 0
        ;;
      list)
        COMPREPLY=( $( compgen -W "${tracks}" "${cur}" ) )
        return 0
        ;;
      open)
        COMPREPLY=( $( compgen -W "${tracks}" "${cur}" ) )
        return 0
        ;;
      skip)
        COMPREPLY=( $( compgen -W "${tracks}" "${cur}" ) )
        return 0
        ;;
      status)
        COMPREPLY=( $( compgen -W "${tracks}" "${cur}" ) )
        return 0
        ;;
      submit)
        if [[ ${#COMP_WORDS[@]} -eq 3 ]] ; then
          COMPREPLY=( $( compgen -f -- ${cur} ) )
        else
          COMPREPLY=( $( compgen -W "${submit_opts}" -- "${cur}" ) )
        fi
        
        return 0
        ;;
      help)
        COMPREPLY=( $( compgen -W "${commands}" "${cur}" ) )
        return 0
        ;;
      *)
        return 0
        ;;
    esac
  fi

  return 0
}

complete -F _exercism exercism

