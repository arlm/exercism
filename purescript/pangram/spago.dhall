{-
Welcome to a Spago project!
You can edit this file as you like.
-}
{ name = "pangram"
, dependencies =
  [ "effect"
  , "arrays"
  , "prelude"
  , "psci-support"
   , "ordered-collections"
  , "strings"
  , "test-unit"
  ]
, packages = ./packages.dhall
, sources = [ "src/**/*.purs", "test/**/*.purs" ]
}
