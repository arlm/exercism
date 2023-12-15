_exercism()
            {
    local cur prev

    COMPREPLY=() # Array variable storing the possible completions.
    cur=${COMP_WORDS[COMP_CWORD]}
    prev=${COMP_WORDS[COMP_CWORD - 1]}

    commands="configure debug download open
  prepare submit troubleshoot upgrade version workspace help"

    tracks="8th abap awk ballerina bash c cfml clojure cobol coffeescript
    common-lisp cpp crystal csharp d dart delphi
    elixir elm emacs-lisp erlang
    fortran fsharp gleam go groovy haskell
    java javascript jq julia kotlin lfe lua
    mips nim objective-c ocaml perl5 pharo-smalltalk php plsql
    powershell prolog purescript python r racket raku
    reasonml red ruby rust scala scheme sml swift tcl typescript
    unison vbnet vimscript vlang wasm wren x86-64-assembly zig"

    # shellcheck disable=SC2034
    version_opts="--latest"
    # shellcheck disable=SC2034
    troubleshoot_opts="--full-api-key"
    # shellcheck disable=SC2034
    download_opts="--exercise --team --track --uuid"
    config_opts="--api --no-verify --show --token --workspace"
    submit_opts="--test --comment"
    # shellcheck disable=SC2034
    global_opts="--help --unmask-token --verbose --timeout"

    if [ "${#COMP_WORDS[@]}" -eq 2 ]; then
        COMPREPLY=($(compgen -W "${commands}" "${cur}"))
        return 0
    fi

    if [ "${#COMP_WORDS[@]}" -ge 3 ]; then
        prev=${COMP_WORDS[1]}
        case "${prev}" in
            configure)
                COMPREPLY=($(compgen -W "${config_opts}" -- "${cur}"))
                return 0
                ;;
            fetch)
                COMPREPLY=($(compgen -W "${tracks}" "${cur}"))
                return 0
                ;;
            list)
                COMPREPLY=($(compgen -W "${tracks}" "${cur}"))
                return 0
                ;;
            open)
                COMPREPLY=($(compgen -W "${tracks}" "${cur}"))
                return 0
                ;;
            skip)
                COMPREPLY=($(compgen -W "${tracks}" "${cur}"))
                return 0
                ;;
            status)
                COMPREPLY=($(compgen -W "${tracks}" "${cur}"))
                return 0
                ;;
            submit)
                if [[ ${#COMP_WORDS[@]} -eq 3 ]]; then
                    COMPREPLY=($(compgen -f -- ${cur}))
                else
                    COMPREPLY=($(compgen -W "${submit_opts}" -- "${cur}"))
                fi

                return 0
                ;;
            help)
                COMPREPLY=($(compgen -W "${commands}" "${cur}"))
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
