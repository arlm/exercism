module Pangram
  ( isPangram
  ) where

import Prelude

import Data.Array (filter)
import Data.Set (fromFoldable, size)
import Data.String (toUpper)
import Data.String.CodeUnits (toCharArray)

isPangram :: String -> Boolean

isPangram text = (size $ fromFoldable letters) == 26
  where
    letters = uniqueLetters text

    uniqueLetters :: String -> Array Char
    uniqueLetters str = filter isLetter $ toCharArray $ toUpper str

    isLetter :: Char → Boolean
    isLetter char = (char >= 'A' && char <= 'Z')
