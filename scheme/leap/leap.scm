(import (rnrs))

(define (leap-year? year)
    (if (zero? (modulo year 100))
    (zero? (modulo year 400))
    (zero? (modulo year 4))
    )
  )

