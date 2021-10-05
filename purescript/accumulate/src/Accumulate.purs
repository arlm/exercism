module Accumulate
  ( accumulate
  ) where

import Prelude

import Data.List (List)

accumulate :: forall a b. (a -> b) -> List a -> List b
accumulate f arr = (\a -> f a) <$> arr