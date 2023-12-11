package sieve

import ("slices")

func Sieve(limit int) []int {
	if limit <= 1 {
        return  []int {}
    } 
    
	result := makeRange(2, limit)
    
    for i:= 0;  i < len(result); i++ {
        multiplier := result[i]
    	result = slices.DeleteFunc(result, func(value int) bool { return value != multiplier && value % multiplier == 0 })
    }
    
    return result
}

func makeRange(min, max int) []int {
    a := make([]int, max-min+1)
    for i := range a {
        a[i] = min + i
    }
    return a
}