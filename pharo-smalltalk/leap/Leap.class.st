Class {
	#name : #Leap,
	#superclass : #Object,
	#category : #'Exercise@Leap'
}

{ #category : #example }
Leap >> leapYear [
	| year |
	^ ((year rem: 100) = 0
        ifTrue: [ (year rem: 400) = 0. ]
        ifFalse: [ (year rem: 4) = 0. ]).
]

{ #category : #example }
Leap >> leapYear: year [
	^ ((year rem: 100) = 0
        ifTrue: [ (year rem: 400) = 0. ]
        ifFalse: [ (year rem: 4) = 0. ]).
]
