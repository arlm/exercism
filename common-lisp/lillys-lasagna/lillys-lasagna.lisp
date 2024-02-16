(defpackage :lillys-lasagna
  (:use :cl)
  (:export :expected-time-in-oven
           :remaining-minutes-in-oven
           :preparation-time-in-minutes
           :elapsed-time-in-minutes))

(in-package :lillys-lasagna)

(defun time-per-layer () "Returns how many minutes Lilly takes to make each lasagna layer." 
  19
  )

(defun expected-time-in-oven () "Returns how many minutes the lasagna should be in the oven according to the Lisp Alien tradition (just like Lilly's parental-unit used to cook)." 
  337
  )

(defun remaining-minutes-in-oven (time-in-oven) "Takes the actual minutes the lasagna has been in the oven as a parameter and returns how many minutes the lasagna still has to remain in the oven."
  (- (expected-time-in-oven) time-in-oven)
  )

(defun preparation-time-in-minutes (layers) "Takes the number of layers Lilly added to the lasagna as a parameter and returns how many minutes Lilly spent preparing the lasagna."
  (* (time-per-layer) layers)
  )

(defun elapsed-time-in-minutes (layers time-in-oven) "Takes two parameters: the first parameter is the number of layers Lilly added to the lasagna, and the second parameter is the number of minutes the lasagna has been in the oven."
  (+ (preparation-time-in-minutes layers) time-in-oven)
  )