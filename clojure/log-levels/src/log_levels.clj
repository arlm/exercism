(ns log-levels)
(use 'clojure.string)

(defn message
  "Takes a string representing a log line
   and returns its message with whitespace trimmed."
  [log-message]
  (trim (join #" " (rest (split log-message #" "))))
  )

(defn log-level
  "Takes a string representing a log line
   and returns its level in lower-case."
  [log-message]
  (lower-case (replace (trim (first (split log-message #" "))) #"[\[\]:]" ""))
  )

(defn reformat
  "Takes a string representing a log line and formats it
   with the message first and the log level in parentheses."
  [log-message]
  (str 
    (message log-message)
     " ("
     (log-level log-message)
     ")"
  )
)

