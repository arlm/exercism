{-
Welcome to a Spago project!
You can edit this file as you like.
-}
{ name = "accumulate"
, dependencies =
  [ "effect"
  , "lists"
  , "prelude"
  , "psci-support"
  , "strings"
  , "test-unit"
  ]
, packages = ./packages.dhall
, sources = [ "src/**/*.purs", "test/**/*.purs" ]
}
