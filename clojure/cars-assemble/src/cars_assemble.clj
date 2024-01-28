(ns cars-assemble)

(def cars-per-hour 221.0)

(defn success-rate
  "Returns the assembly line's success rate,
   taking into account its speed"
  [speed]
 (cond
   (= 0 speed)      0.00
   (<= speed 4)     1.00
   (<= speed 8)     0.90
   (= 9 speed)      0.80
   (= 10 speed)     0.77
   :else (throw (Exception. "Value should be between 0 and 10"))
   )
  )

(defn production-rate
  "Returns the assembly line's production rate per hour,
   taking into account its success rate"
  [speed]
  (* speed cars-per-hour (success-rate speed)))

(defn working-items
  "Calculates how many working cars are produced per minute"
  [speed]
  (int (/ (production-rate speed) 60)))
