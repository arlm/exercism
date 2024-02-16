Red [
	description: {"Leap" exercise solution for exercism platform}
	author: "" ; you can write your name here, in quotes
]

leap: function [
	year
] [
	either year % 100 == 0 [year % 400 == 0] [year % 4 == 0]
]

