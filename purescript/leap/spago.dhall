{-
Welcome to a Spago project!
You can edit this file as you like.
-}
{ name = "leap"
, dependencies =
  [ "effect"
  , "prelude"
  , "psci-support"
  , "test-unit"
  ]
, packages = ./packages.dhall
, sources = [ "src/**/*.purs", "test/**/*.purs" ]
}
