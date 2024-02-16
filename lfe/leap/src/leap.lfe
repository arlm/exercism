(defmodule leap
  (export (leap-year 1)))
(defun leap-year (year)
    (if (== (rem year 100) 0)
        (== (rem year 400) 0)
        (== (rem year 4) 0)
    )
)