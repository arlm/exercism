module Bob
  ( hey
  ) where

import Prelude

import Data.String (null, toLower, toUpper, trim)
import Data.String.CodeUnits (takeRight)

hey :: String -> String
hey message | null (trim message) = "Fine. Be that way!"
         -- | isQuestion message &&  isUpperString message = "Calm down, I know what I'm doing!"
            | message == toUpper message && message /= toLower message= "Whoa, chill out!"
            | isQuestion message = "Sure."
            | otherwise = "Whatever."

isQuestion :: String -> Boolean
isQuestion str = takeRight 1 (trim str) == "?"